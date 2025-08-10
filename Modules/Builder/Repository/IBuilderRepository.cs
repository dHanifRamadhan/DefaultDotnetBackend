using DefaultDotnetBackend.DTOs;

namespace DefaultDotnetBackend.Repositories
{
    public interface IBuilderRepository
    {
        Task<List<string>> GetSchema();

        Task<List<string>> GetTable(string schema);
        Task<List<TableDetailResponse>> GetTableDetail(string schema);
        Task<TableDetailResponse> GetTableDetailByName(string schema, string tableName);
    }
}