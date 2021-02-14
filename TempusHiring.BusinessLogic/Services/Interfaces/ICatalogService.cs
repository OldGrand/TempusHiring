using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.Common;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface ICatalogService
    {
        PriceRangeDTO GetWatchesPriceRange();
        void ChangePriceRange(decimal start, decimal end);

        PagedResult<WatchDTO> ReadUnisex(Filter filter, int pageNum, int itemsOnPage);
        PagedResult<WatchDTO> ReadMen(Filter filter, int pageNum, int itemsOnPage);
        PagedResult<WatchDTO> ReadWomen(Filter filter, int pageNum, int itemsOnPage);
    }
}
