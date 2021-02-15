using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.DataTransferObjects.Order;
using TempusHiring.BusinessLogic.Extensions;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Common;
using TempusHiring.DataAccess.Core;
using TempusHiring.DataAccess.Entities;

namespace TempusHiring.BusinessLogic.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly TempusHiringDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(TempusHiringDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private Order CreateOrder(int userId)
        {
            var order = new Order
            {
                UserId = userId,
                PaymentMethod = PaymentMethods.CASH,
                OrderDate = DateTime.Now,
                User = _context.Users.Find(userId),
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }

        public void AddItemsToOrder(int userId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var carts = _context.ShoppingCarts.Where(_ => _.UserId == userId && _.IsChecked).ToList();
                    if (carts.Count > 0)
                    {
                        var order = CreateOrder(userId);

                        var oderLinks = carts.Select(_ => _.ToOrder(order));
                        _context.OrderWatchLinks.AddRange(oderLinks);
                        _context.ShoppingCarts.RemoveRange(carts);

                        _context.Watches.UpdateRange(carts.Select(_ =>
                        {
                            _.Watch.CountInStock = _.Watch.CountInStock - _.Count;
                            return _.Watch;
                        }));

                        order.TotalPrice = carts.Sum(_ => _.Count * _.Watch.Price);
                        order.TotalCount = carts.Sum(_ => _.Count);

                        _context.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public IEnumerable<OrderDTO> GetOrders(int userId)
        {
            var orders = _context.Orders.Where(_ => _.UserId == userId && !_.IsOrderCompleted)
                                                            .OrderBy(_ => _.Id)
                                                            .ToList();

            var orderDtos = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return orderDtos;
        }
    }
}
