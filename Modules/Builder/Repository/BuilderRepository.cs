using DefaultDotnetBackend.DTOs;
using DefaultDotnetBackend.Helpers;
using Npgsql;

namespace DefaultDotnetBackend.Repositories
{
    public class BuilderRepository : IBuilderRepository
    {
        private readonly IConfiguration _configuration;
        public BuilderRepository(
            IConfiguration configuration
        )
        {
            _configuration = configuration;
        }

        public async Task<List<string>> GetSchema()
        {
            var connectionString = _configuration.GetConnectionString("NpgsqlConnection");
            var schemas = new List<string>();

            await using var conn = new NpgsqlConnection(connectionString);
            await conn.OpenAsync();

            var query = @"
                SELECT 
                    schema_name 
                FROM 
                    information_schema.schemata
                WHERE
                    schema_name NOT LIKE '%pg%' AND
                    NOT schema_name = 'information_schema'
                ORDER BY schema_name ASC;
            ";
            var cmd = new NpgsqlCommand(query, conn);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                schemas.Add(reader.GetString(0));
            }

            return schemas;
        }

        public async Task<List<string>> GetTable(string schema)
        {
            var connectionString = _configuration.GetConnectionString("NpgsqlConnection");
            var tables = new List<string>();

            await using var conn = new NpgsqlConnection(connectionString);
            await conn.OpenAsync();

            var query = @"
                SELECT 
                	t.table_name
                FROM 
                	information_schema.tables t
                WHERE 
                	t.table_type = 'BASE TABLE' AND
                	t.is_insertable_into = 'YES' AND
                	t.table_name  NOT LIKE '%pg%' AND
                	t.table_name NOT LIKE '%sql%' AND
                	NOT t.table_name = '__EFMigrationsHistory' AND
                	t.table_schema = @schema
                ORDER BY t.table_name ASC;
            ";
            var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("schema", schema);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                tables.Add(reader.GetString(0));
            }

            return tables;
        }

        public async Task<List<TableDetailResponse>> GetTableDetail(string schema)
        {
            var connectionString = _configuration.GetConnectionString("NpgsqlConnection");
            var tableRespose = new List<TableDetailResponse>();
            var tables = await GetTable(schema);
            tableRespose = tables
            .Select(x => new TableDetailResponse
            {
                TableName = x,
                Columns = new List<ColumnResponse>(),
            })
            .Distinct()
            .ToList();

            await using var conn = new NpgsqlConnection(connectionString);
            await conn.OpenAsync();

            string query = @"
                SELECT
                    C.table_schema,
                    C.table_name,
                    C.column_name,
                    C.ordinal_position,
                    CASE WHEN
                        C.is_nullable = 'YES'
                        THEN TRUE ELSE FALSE
                    END AS is_nullable,
                    C.udt_name,
                    CASE WHEN 
                        I.column_name IS NOT NULL AND 
                        I.indexes LIKE '%PK%' 
                        THEN TRUE ELSE FALSE 
                    END AS is_primary_key,
                    CASE WHEN 
                        I.column_name IS NOT NULL AND 
                        I.indexes LIKE '%IX%' AND 
                        I.indexes NOT LIKE '%_id%' 
                        THEN TRUE ELSE FALSE
                    END AS is_unique,
                    CASE WHEN 
                        FK.source_column IS NOT NULL AND
                        FK.target_column IS NOT NULL
                        THEN TRUE ELSE FALSE
                    END AS is_foreign_key,
                    FK.target_table AS foreign_table,
                    FK.target_column AS foreign_column
                FROM
                    information_schema.columns C
                LEFT JOIN (
                    SELECT
                        T.relname AS table_name,
                        A.attname AS column_name,
                        STRING_AGG(I.relname, ', ') AS indexes
                    FROM
                        pg_class T
                    JOIN pg_index IX ON T.oid = IX.indrelid
                    JOIN pg_class I ON I.oid = IX.indexrelid
                    JOIN pg_attribute A ON A.attrelid = T.oid AND A.attnum = ANY(IX.indkey)
                    WHERE T.relkind = 'r'
                    GROUP BY T.relname, A.attname
                ) I ON C.table_name = I.table_name AND C.column_name = I.column_name
                LEFT JOIN (
                    SELECT
                        kcu.table_schema AS source_schema,
                        kcu.table_name AS source_table,
                        kcu.column_name AS source_column,
                        ccu.table_schema AS target_schema,
                        ccu.table_name AS target_table,
                        ccu.column_name AS target_column,
                        rc.update_rule,
                        rc.delete_rule
                    FROM
                        information_schema.table_constraints AS tc
                    LEFT JOIN
                        information_schema.key_column_usage AS kcu
                        ON tc.constraint_name = kcu.constraint_name
                        AND tc.constraint_schema = kcu.constraint_schema
                    LEFT JOIN
                        information_schema.referential_constraints AS rc
                        ON rc.constraint_name = tc.constraint_name
                        AND rc.constraint_schema = tc.constraint_schema
                    LEFT JOIN
                        information_schema.constraint_column_usage AS ccu
                        ON rc.unique_constraint_name = ccu.constraint_name
                        AND rc.unique_constraint_schema = ccu.constraint_schema
                ) FK ON C.table_name = FK.source_table AND C.column_name = FK.source_column 
                WHERE 
                    NOT C.table_schema = 'information_schema' AND
                    NOT C.table_schema LIKE '%pg%' AND
                    NOT C.table_name = '__EFMigrationsHistory' AND
                    C.table_schema = @schema
                ORDER BY 
                    C.table_name, 
                    C.ordinal_position 
                ASC;
            ";

            var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("schema", schema);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                string tableName = reader.GetString(1);
                string columnName = reader.GetString(2);
                int position = reader.GetInt32(3);
                bool isNullable = reader.GetBoolean(4);
                string dataType = reader.GetString(5);
                bool isPrimaryKey = reader.GetBoolean(6);
                bool isUnique = reader.GetBoolean(7);
                bool isForeignKey = reader.GetBoolean(8);

                var table = tableRespose.FirstOrDefault(x => x.TableName.Equals(tableName));
                if (table != null)
                {
                    var column = new ColumnResponse
                    {
                        ColumnName = columnName,
                        Position = position,
                        IsNullable = isNullable,
                        DataType = dataType,
                        IsPrimaryKey = isPrimaryKey,
                        IsUnique = isUnique,
                        IsForeignKey = isForeignKey,
                        Foreign = isForeignKey == true ? new ForeignResponse
                        {
                            ForeignTable = reader.GetString(9),
                            ForeignColumn = reader.GetString(10),
                        } : null,
                    };

                    table.Columns?.Add(column);
                }
            }

            return tableRespose;
        }

        public async Task<TableDetailResponse> GetTableDetailByName(string schema, string tableName)
        {
            var table = await GetTableDetail(schema);
            return table.FirstOrDefault(x => x.TableName.Equals(tableName));
        }
    }
}