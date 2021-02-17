using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.DataTransferObjects.Order;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Common;
using TempusHiring.DataAccess.Core;
using TempusHiring.DataAccess.Entities;

namespace TempusHiring.BusinessLogic.Services.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly TempusHiringDbContext _context;
        private readonly IMapper _mapper;

        public ShoppingCartService(TempusHiringDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IQueryable<ShoppingCart> ReadAll(int userId)
        {
            return from cart in _context.ShoppingCarts
                   where cart.UserId == userId
                   orderby cart.Id descending
                   select cart;
        }

        public OrderSummaryDTO GetSummary(int userId)
        {
            var watches = ReadAll(userId).Where(_ => _.IsChecked);
            var totalPrice = watches.Sum(_ => _.Watch.Price * _.Count);
            var shippingPrice = totalPrice != 0 ? 25 : 0;

            return new OrderSummaryDTO
            {
                Shipping = shippingPrice,
                SubTotal = totalPrice,
                Total = shippingPrice + totalPrice,
                Count = watches.Sum(_ => _.Count)
            };
        }

        public void UpdateSelection(int userId, int watchId, bool isChecked)
        {
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(_ => _.UserId == userId && _.WatchId == watchId);

            if (shoppingCart is null)
            {
                throw new Exception("Item not found");
            }

            shoppingCart.IsChecked = isChecked;
            _context.SaveChanges();
        }

        public IEnumerable<ShoppingCartDTO> ReadUserCart(int userId)
        {
            var shoppingCarts = ReadAll(userId).ToList();
            var shoppingCartDto = _mapper.Map<IEnumerable<ShoppingCartDTO>>(shoppingCarts);
            return shoppingCartDto;
        }

        public void DeleteFromCart(int cartId)
        {
            var shoppingCart = _context.ShoppingCarts.Find(cartId);

            if (shoppingCart is null)
            {
                throw new Exception("Item not found");
            }

            _context.ShoppingCarts.Remove(shoppingCart);
            _context.SaveChanges();
        }

        public void ChangeCount(int userId, int watchId, Operations operation)
        {
            var changedShoppingCart = _context.ShoppingCarts.FirstOrDefault(_ => _.UserId == userId && _.WatchId == watchId);

            if (changedShoppingCart is null)
            {
                throw new Exception("Item not found");
            }

            changedShoppingCart.Count = operation switch
            {
                Operations.Minus => changedShoppingCart.Count - 1,
                Operations.Plus => changedShoppingCart.Count + 1,
                _ => changedShoppingCart.Count
            };

            if (changedShoppingCart.Count >= 1 && changedShoppingCart.Count <= changedShoppingCart.Watch.CountInStock)
            {
                _context.SaveChanges();
            }
        }

        public Task AddToCartAsync(int userId, int watchId)
        {
            var record = _context.ShoppingCarts.FirstOrDefault(_ => _.UserId == userId && _.WatchId == watchId);

            if (record is null)
            {
                record = new ShoppingCart
                {
                    UserId = userId,
                    WatchId = watchId
                };
                _context.ShoppingCarts.Add(record);
            }

            record.Count++;
            return _context.SaveChangesAsync();
        }
    }
}