namespace DefaultDotnetBackend.DTOs
{
    public class TableDetailResponse
    {
        public required string TableName { get; set; }
        public List<ColumnResponse>? Columns { get; set; }
    }
}