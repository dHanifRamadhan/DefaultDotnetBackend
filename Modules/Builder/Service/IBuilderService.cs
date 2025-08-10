using DefaultDotnetBackend.DTOs;

namespace DefaultDotnetBackend.Services
{
    public interface IBuilderService
    {
        Task<PagedResult<OptionResponse>> GetAllSchema();
        Task<PagedResult<OptionResponse>> GetAllTable(string schema);
        Task<TableDetailResponse> GetTableByName(string schema, string tableName);
        Task<string> GenerateEntity(string schema, string tableName, string namespaceName);
    }
}