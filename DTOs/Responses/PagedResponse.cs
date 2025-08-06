namespace DefaultDotnetBackend.DTOs {
    public class PagedResponse<T> : ApiResponse {
        public List<T>? Data { get; set;}
        public PagedMetaResponse? Meta { get; set;}
    }
}