namespace Acerto.Business.Core.Pagination
{
    public class PagedInputModel
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int Skip => (PageIndex - 1) * PageSize;
    }
}