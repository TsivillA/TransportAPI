namespace WebApi.Models
{
    public class PaginationModel
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string SortBy { get; set; } = "Id";
        public bool IsAscending { get; set; } = true;
    }
}
