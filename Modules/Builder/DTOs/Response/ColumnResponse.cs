namespace DefaultDotnetBackend.DTOs
{
    public class ColumnResponse
    {
        public string? ColumnName { get; set; }
        public int? Position { get; set; }
        public bool? IsNullable { get; set; }
        public string? DataType { get; set; }
        public bool? IsPrimaryKey { get; set; }
        public bool? IsUnique { get; set; }
        public bool? IsForeignKey { get; set; }
        public ForeignResponse? Foreign { get; set; }
    }
}