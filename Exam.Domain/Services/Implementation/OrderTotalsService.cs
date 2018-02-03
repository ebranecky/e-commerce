using Exam.Domain.Enums;
using Exam.Domain.Models;
using Exam.Domain.Services;
using System.Collections.Generic;

namespace Exam.Infrastructure.Services
{
    /// <summary>
    /// Order totals service used to calculate totals for each order.
    /// </summary>
    public class OrderTotalsService : IOrderTotalsService
    {
        /// <summary>
        /// Function used to calculate the total amount with tax for an order.
        /// </summary>
        /// <param name="orderItems">Collection of order item models on the order.</param>
        /// <param name="taxRate">Tax rate to calculate the tax with.</param>
        /// <returns>Total amount for order.</returns>
        public decimal GetOrderTotal(ICollection<OrderItem> orderItems, decimal taxRate)
        {
            decimal orderTotal = 0;
            foreach (var item in orderItems)
            {
                decimal price = item.Item.Price;
                if (item.ItemType == OrderItemType.Material)
                {
                    orderTotal += price + (price * (taxRate / 100));
                }
                else
                {
                    orderTotal += price;
                }
            }

            return decimal.Round(orderTotal, 2);
        }

        /// <summary>
        /// Function to return just the total tax amount for the order based off of the tax rate.
        /// </summary>
        /// <param name="orderItems">Collection of order item models on the order.</param>
        /// <param name="taxRate">Tax rate to calculate the tax with.</param>
        /// <returns>Total amount of taxes on the order.</returns>
        public decimal GetOrderTaxTotal(ICollection<OrderItem> orderItems, decimal taxRate)
        {
            decimal taxTotal = 0;
            foreach (var item in orderItems)
            {
                decimal price = item.Item.Price;
                if (item.ItemType == OrderItemType.Material)
                {
                    taxTotal += price * (taxRate / 100);
                }
            }

            return decimal.Round(taxTotal, 2);
        }
    }
}
