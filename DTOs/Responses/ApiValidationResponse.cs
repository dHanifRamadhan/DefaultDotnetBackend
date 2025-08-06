namespace DefaultDotnetBackend.DTOs {
    public class ApiValidationResponse : ApiResponse {
        public required IDictionary<string, string[]?> Errors { get; set; }
    }
}