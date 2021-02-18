using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TempusHiring.BusinessLogic.AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Common;
using TempusHiring.DataAccess.Core;
using TempusHiring.DataAccess.EntityEnums;

namespace TempusHiring.BusinessLogic.Services.Implementation
{
    public class CatalogService : ICatalogService
    {
        private readonly TempusHiringDbContext _context;
        private readonly IMapper _mapper;

        private static PriceRangeDTO _priceRange;

        public CatalogService(TempusHiringDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _priceRange ??= GetWatchesPriceRange();
        }

        public PriceRangeDTO GetWatchesPriceRange()
        {
            if (_priceRange is not null)
                return _priceRange;

            var start = _context.Watches.Min(_ => _.Price);
            var end = _context.Watches.Max(_ => _.Price);

            return new PriceRangeDTO
            {
                StartBorder = start,
                EndBorder = end,
                StartPrice = start,
                EndPrice = end,
            };
        }

        public void ChangePriceRange(decimal start, decimal end)
        {
            _priceRange.StartPrice = start;
            _priceRange.EndPrice = end;
        }

        public PagedResult<WatchDTO> ReadUnisex(Filter filter, int pageNum, int itemsOnPage)
        {
            return (filter switch
            {
                Filter.OrderByPriceAsc => ReadOrderedByPriceAsc(),
                Filter.OrderByPriceDesc => ReadOrderedByPriceDesc(),
                Filter.SortByNoveltyAsc => ReadOrderedByNoveltyAsc(),
                Filter.SortByNoveltyDesc => ReadOrderedByNoveltyDesc(),
                Filter.SortByPopularityAsc => ReadOrderedByPopularityAsc(),
                Filter.SortByPopularityDesc => ReadOrderedByPopularityDesc(),
                _ => ReadAll()
            }).GetPaged(pageNum, itemsOnPage);
        }

        public PagedResult<WatchDTO> ReadMen(Filter filter, int pageNum, int itemsOnPage)
        {
            return (filter switch
            {
                Filter.OrderByPriceAsc => ReadMenOrderedByPriceAsc(),
                Filter.OrderByPriceDesc => ReadMenOrderedByPriceDesc(),
                Filter.SortByNoveltyAsc => ReadMenOrderedByNoveltyAsc(),
                Filter.SortByNoveltyDesc => ReadMenOrderedByNoveltyDesc(),
                Filter.SortByPopularityAsc => ReadMenOrderedByPopularityAsc(),
                Filter.SortByPopularityDesc => ReadMenOrderedByPopularityDesc(),
                _ => ReadMen()
            }).GetPaged(pageNum, itemsOnPage);
        }

        public PagedResult<WatchDTO> ReadWomen(Filter filter, int pageNum, int itemsOnPage)
        {
            return (filter switch
            {
                Filter.OrderByPriceAsc => ReadWomenOrderedByPriceAsc(),
                Filter.OrderByPriceDesc => ReadWomenOrderedByPriceDesc(),
                Filter.SortByNoveltyAsc => ReadWomenOrderedByNoveltyAsc(),
                Filter.SortByNoveltyDesc => ReadWomenOrderedByNoveltyDesc(),
                Filter.SortByPopularityAsc => ReadWomenOrderedByPopularityAsc(),
                Filter.SortByPopularityDesc => ReadWomenOrderedByPopularityDesc(),
                _ => ReadWomen()
            }).GetPaged(pageNum, itemsOnPage);
        }

        public WatchDTO ReadById(int id)
        {
            var watchEntity = _context.Watches.Find(id);

            if (watchEntity is null)
            {
                throw new Exception("Entity not found exception");
            }

            var watchDto = _mapper.Map<WatchDTO>(watchEntity);
            return watchDto;
        }

        private IQueryable<WatchDTO> ReadAll()
        {
            var watchEntities = _context.Watches
                .Where(_ => _.Price >= _priceRange.StartPrice && _.Price <= _priceRange.EndPrice);

            var mapperConfig = BusinessLogicLayerMapperConfig.GetConfiguration();
            var result = watchEntities.ProjectTo<WatchDTO>(mapperConfig);
            return result;
        }

        private IQueryable<WatchDTO> ReadOrderedByPriceDesc() =>
            ReadAll().OrderByDescending(_ => _.Price);
        private IQueryable<WatchDTO> ReadOrderedByPriceAsc() =>
            ReadAll().OrderBy(_ => _.Price);
        private IQueryable<WatchDTO> ReadOrderedByNoveltyDesc() =>
            ReadAll().OrderByDescending(_ => _.Id);
        private IQueryable<WatchDTO> ReadOrderedByNoveltyAsc() =>
            ReadAll().OrderBy(_ => _.Id);
        private IQueryable<WatchDTO> ReadOrderedByPopularityDesc() =>
            ReadAll().OrderByDescending(_ => _.SaledCount);
        private IQueryable<WatchDTO> ReadOrderedByPopularityAsc() =>
            ReadAll().OrderBy(_ => _.SaledCount);

        private IQueryable<WatchDTO> ReadMen() =>
            ReadAll().Where(_ => _.Gender == Gender.Man);
        private IQueryable<WatchDTO> ReadMenOrderedByPriceDesc() =>
            ReadMen().OrderByDescending(_ => _.Price);
        private IQueryable<WatchDTO> ReadMenOrderedByPriceAsc() =>
            ReadMen().OrderBy(_ => _.Price);
        private IQueryable<WatchDTO> ReadMenOrderedByNoveltyDesc() =>
            ReadMen().OrderByDescending(_ => _.Id);
        private IQueryable<WatchDTO> ReadMenOrderedByNoveltyAsc() =>
            ReadMen().OrderBy(_ => _.Id);
        private IQueryable<WatchDTO> ReadMenOrderedByPopularityDesc() =>
            ReadMen().OrderByDescending(_ => _.SaledCount);
        private IQueryable<WatchDTO> ReadMenOrderedByPopularityAsc() =>
            ReadMen().OrderBy(_ => _.SaledCount);

        private IQueryable<WatchDTO> ReadWomen() =>
            ReadAll().Where(_ => _.Gender == Gender.Woman);
        private IQueryable<WatchDTO> ReadWomenOrderedByPriceDesc() =>
            ReadWomen().OrderByDescending(_ => _.Price);
        private IQueryable<WatchDTO> ReadWomenOrderedByPriceAsc() =>
            ReadWomen().OrderBy(_ => _.Price);
        private IQueryable<WatchDTO> ReadWomenOrderedByNoveltyDesc() =>
            ReadWomen().OrderByDescending(_ => _.Id);
        private IQueryable<WatchDTO> ReadWomenOrderedByNoveltyAsc() =>
            ReadWomen().OrderBy(_ => _.Id);
        private IQueryable<WatchDTO> ReadWomenOrderedByPopularityDesc() =>
            ReadWomen().OrderByDescending(_ => _.SaledCount);
        private IQueryable<WatchDTO> ReadWomenOrderedByPopularityAsc() =>
            ReadWomen().OrderBy(_ => _.SaledCount);
    }
}
