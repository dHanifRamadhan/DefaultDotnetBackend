namespace DefaultDotnetBackend.DTOs {
    public class PagedResult<T> {
        public List<T>? Data { get; }
        public int TotalItems { get; }
        public PagedResult(List<T> data, int totalItems) {
            Data = data;
            TotalItems = totalItems;
        }
    }
}