using Microsoft.AspNetCore.Mvc.Rendering;
using TempusHiring.BusinessLogic.Pagination;

namespace TempusHiring.Presentation.Models.ViewModels
{
    public class PaginationViewModel<TSource> where TSource : class
    {
        public PagedResult<TSource> PagedResult { get; set; }
        public SelectList ItemsOnPageSelectList { get; set; }
    }
}
