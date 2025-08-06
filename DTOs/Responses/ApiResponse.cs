namespace DefaultDotnetBackend.DTOs {
    public class ApiResponse {
        public bool Success { get; set; }
        public required string Message { get; set; }
        public string? Details { get; set; }
        public string? StackTrace { get; set; }
    }

    public class ApiResponse<T> : ApiResponse {
        public T? Data { get; set; }
    }
}