﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TempusHiring.BusinessLogic.DataTransferObjects.Order;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.DataAccess.Core;
using TempusHiring.DataAccess.Entities;

namespace TempusHiring.BusinessLogic.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly TempusHiringDbContext _context;
        private readonly IMapper _mapper;

        private const string ERROR_MESSAGE = "Items not found";

        public OrderService(TempusHiringDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public void CreateOrder(OrderDTO orderDto, int userId)
        {
            var checkedItemsInCart = _context.ShoppingCarts
                .Where(_ => _.UserId == userId && _.IsChecked)
                .ToList();

            if (!checkedItemsInCart.Any())
            {
                throw new Exception(ERROR_MESSAGE);
            }

            var transaction = _context.Database.BeginTransaction();
            try
            {
                var orderEntity = _mapper.Map<Order>(orderDto);
                orderEntity.OrderDate = DateTime.Now;
                orderEntity.UserId = userId;
                orderEntity.TotalPrice = checkedItemsInCart.Sum(_ => _.Count * _.Watch.Price);
                orderEntity.TotalCount = checkedItemsInCart.Sum(_ => _.Count);

                var orderWatchLinks = _mapper.Map<IEnumerable<OrderWatchLink>>(checkedItemsInCart);

                foreach (OrderWatchLink item in orderWatchLinks)
                {
                    item.Order = orderEntity;
                }
                
                _context.OrderWatchLinks.AddRange(orderWatchLinks);
                _context.ShoppingCarts.RemoveRange(checkedItemsInCart);

                foreach (ShoppingCart item in checkedItemsInCart)
                {
                    item.Watch.CountInStock -= item.Count;
                }

                transaction.Commit();
                //_context.SaveChanges();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public IEnumerable<OrderDTO> GetOrders(int userId)
        {
            var orders = _context.Orders.Where(_ => _.UserId == userId && !_.IsOrderCompleted)
                .OrderBy(_ => _.Id)
                .AsEnumerable();

            var orderDtos = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return orderDtos;
        }
    }
}