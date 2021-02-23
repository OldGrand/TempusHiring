using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TempusHiring.Presentation.Models.ViewModels
{
    public class PaginationViewModel<TSource>
    {
        public IEnumerable<TSource> Items { get; set; }
        public int ItemsOnPage { get; set; } = 12;
        public SelectList ItemsOnPageSelectList { get; set; }
        public int PageNum { get; set; } = 1;
    }
}
