using System;
using System.Linq;

namespace TempusHiring.BusinessLogic.Pagination
{
    public static class PaginationExtension
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> source, int pageNum, int itemsOnPage) where T : class
        {
            var skippedItems = (pageNum - 1) * itemsOnPage;
            var count = source.Count();
            var resultItems = source.Skip(skippedItems).Take(itemsOnPage).ToList();

            var result = new PagedResult<T>()
            {
                CurrentPage = pageNum,
                ItemsOnPage = itemsOnPage,
                ItemsTotal = count,
                SkippedItems = skippedItems,
                PagesTotal = (int)Math.Ceiling((double)count / itemsOnPage),
                Result = resultItems
            };

            return result;
        }
    }
}
