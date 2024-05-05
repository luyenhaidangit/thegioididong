namespace Thegioididong.Api.Models.Responses
{
    public class PagingResult<T>
    {
        public PagingResult(List<T> items, int pageIndex, int pageSize, int totalRecords)
        {
            Items = items;

            PageIndex = pageIndex;

            PageSize = pageSize;

            TotalRecords = totalRecords;
        }

        public PagingResult(List<T> items, int pageIndex, int pageSize, string? sortBy, string? orderBy, int totalRecords)
        {
            Items = items;

            PageIndex = pageIndex;

            PageSize = pageSize;

            SortBy = sortBy;

            OrderBy = orderBy;

            TotalRecords = totalRecords;
        }

        public List<T>? Items { set; get; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string? SortBy { get; set; }

        public string? OrderBy { get; set; }

        public int TotalRecords { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);

        public bool HasPrevious => PageIndex > 1;

        public bool HasNext => PageIndex < TotalPages;

        public int FirstRowOnPage => TotalRecords > 0 ? (PageIndex - 1) * PageSize + 1 : 0;

        public int LastRowOnPage => (int)Math.Min(PageIndex * PageSize, TotalRecords);
    }
}
