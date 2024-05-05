using Thegioididong.Api.Constants.Request;

namespace Thegioididong.Api.Models.Parameters
{
    public class PagingRequest
    {
        private int _pageIndex = PagingConstant.DefaultPageIndex;

        private int _pageSize = PagingConstant.DefaultPageSize;

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value < 1 ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value < 1)
                    _pageSize = value < 1 ? PagingConstant.DefaultPageSize : value;
                else
                    _pageSize = value;
            }
        }

        public string OrderBy { get; set; } = PagingConstant.DefaultOrderBy;

        public string SortBy { get; set; } = PagingConstant.DefaultSortBy;
    }
}
