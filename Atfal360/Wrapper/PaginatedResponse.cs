using Atfal360.Context;

namespace Atfal360.Wrapper
{
    public class PagedResponse<T> : Response<T>
    {
        ApplicationContext _context;

        public PagedResponse(ApplicationContext context)
        {
            _context = context;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = null;
            this.Success = true;
        }


/*        public async Task<PagedResponse<T>> ToPaginatedList(PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _context.Set<T>()
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
        }*/
    }
}
