using DefaultDotnetBackend.DTOs;
using DefaultDotnetBackend.Helpers;
using DefaultDotnetBackend.Repositories;
using Newtonsoft.Json;
using Scriban;

namespace DefaultDotnetBackend.Services
{
    public class BuilderService : IBuilderService
    {
        private readonly IBuilderRepository _builderRepository;
        public BuilderService(
            IBuilderRepository builderRepository
        )
        {
            _builderRepository = builderRepository;
        }

        public async Task<PagedResult<OptionResponse>> GetAllSchema()
        {
            var schemas = await _builderRepository.GetSchema();
            var options = schemas.Select(x => new OptionResponse
            {
                Label = x,
                Value = x,
            });

            int totalItem = options.Count();

            return new PagedResult<OptionResponse>(options.ToList(), totalItem);
        }

        public async Task<PagedResult<OptionResponse>> GetAllTable(string schema)
        {
            var tables = await _builderRepository.GetTable(schema);
            var options = tables.Select(x => new OptionResponse
            {
                Label = x,
                Value = x,
            });

            int totalItem = options.Count();

            return new PagedResult<OptionResponse>(options.ToList(), totalItem);
        }

        public async Task<TableDetailResponse> GetTableByName(string schema, string tableName)
        {
            var table = await _builderRepository.GetTableDetailByName(schema, tableName);
            return table;
        }

        public async Task<string> GenerateEntity(string schema, string tableName, string namespaceName)
        {
            var templateFile = File.ReadAllText("Templates/EntityTemplate.scriban");
            var template = Template.Parse(templateFile);

            if (template.HasErrors)
                throw new InvalidOperationException(
                    "Template parsing error: " + string.Join(", ", template.Messages));

            var table = await _builderRepository.GetTableDetailByName(schema, tableName);
            if (table == null) throw new Exception(Constants.Messages.WARN_NOT_FOUND);
            ConsoleHelper.ShowInformation(JsonConvert.SerializeObject(table));
            ConsoleHelper.ShowInformation(tableName);

            var model = new
            {
                @namespace = namespaceName,
                schema = schema,
                tablename = table.TableName,
                columns = table.Columns?.Select(x => new
                {
                    columnname = x.ColumnName,
                    position = x.Position,
                    isnullable = x.IsNullable,
                    datatype = x.DataType,
                    isprimarykey = x.IsPrimaryKey,
                    isunique = x.IsUnique,
                    isforeignkey = x.IsForeignKey,
                    foreign = x.Foreign == null ? null : new
                    {
                        foreigncolumn = x.Foreign.ForeignColumn,
                        foreigntable = x.Foreign.ForeignTable,
                    },
                }).ToList(),
            };

            return template.Render(model);
        }
    }
}