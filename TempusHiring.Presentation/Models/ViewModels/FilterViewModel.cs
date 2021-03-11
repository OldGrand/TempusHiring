using System.ComponentModel.DataAnnotations;

namespace TempusHiring.Presentation.Models.ViewModels
{
    public enum FilterViewModel
    {
        [Display(Name = "Default")]
        Deafult,
        
        [Display(Name = "Sort by popularity descending")]
        SortByPopularityDesc,

        [Display(Name = "Sort by popularity ascending")]
        SortByPopularityAsc,

        [Display(Name = "Sort by novelty ascending")]
        SortByNoveltyAsc,

        [Display(Name = "Sort by novelty descending")]
        SortByNoveltyDesc,

        [Display(Name = "Price: order by ascending")]
        OrderByPriceAsc,

        [Display(Name = "Price: order by descending")]
        OrderByPriceDesc
    }
}
