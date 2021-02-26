using Microsoft.AspNetCore.Mvc.Rendering;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.Presentation.Models.ViewModels.Watch;

namespace TempusHiring.Presentation.Models.ViewModels
{
    public class FilteredWatchViewModel
    {
        public PagedResult<WatchViewModel> PageResult { get; set; }
        public int ItemsOnPage { get; set; } = 12;
        public FilterViewModel Filter { get; set; }
        public SelectList ItemsOnPageSelectList { get; set; }
        public PriceRangeViewModel PriceRange { get; set; }
    }
}
