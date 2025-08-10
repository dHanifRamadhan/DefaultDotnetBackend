namespace DefaultDotnetBackend.DTOs
{
    public class BuilderRequest
    {
        public required string Schema { get; set; }
        public required string TableName { get; set; }
        public required string Namespace { get; set; }
    }
}