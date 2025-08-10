namespace DefaultDotnetBackend.DTOs
{
    public class OptionResponse
    {
        public required string Label { get; set; }
        public required string Value { get; set; }
        public string? Description { get; set; }
    }
}