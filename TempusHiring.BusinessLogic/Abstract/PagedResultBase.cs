using System;

namespace TempusHiring.BusinessLogic.Abstract
{
    public abstract class PagedResultBase
    {
        private const int PAGES_RANGE = 3;

        public int CurrentPageNum { get; set; }
        public int PagesTotal { get; set; } 
        public int ItemsOnPage { get; set; }
        public int ItemsTotal { get; set; }
        public int SkippedItems { get; set; }
        public int CurrentItemsCount => SkippedItems + ItemsOnPage;
        public Range Range => GetPaginationRange(CurrentPageNum, PagesTotal, PAGES_RANGE);

        private static Range GetPaginationRange(int currentPage, int total, int range)
        {
            if (range > total)
                return 1..total;

            var middleOfRange = range / 2;
            var start = currentPage - middleOfRange;
            var end = currentPage + middleOfRange;

            if (start <= 0)
            {
                start = 1;
                end = currentPage + range - 1;
            }

            if (end > total)
            {
                end = total;
                start = currentPage - range + 1;
            }

            return start..end;
        }
    }
}
