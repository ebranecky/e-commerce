using Exam.Domain.Models;
using System.Collections.Generic;

namespace Exam.Domain.Services
{
    /// <summary>
    /// Interface created for the order totals service.
    /// </summary>
    public interface IOrderTotalsService
    {
        /// <summary>
        /// Function used to calculate the total amount with tax for an order.
        /// </summary>
        /// <param name="orderItems">Collection of order item models on the order.</param>
        /// <param name="taxRate">Tax rate to calculate the tax with.</param>
        /// <returns>Total amount for order.</returns>
        decimal GetOrderTotal(ICollection<OrderItem> orderItems, decimal taxRate);

        /// <summary>
        /// Function to return just the total tax amount for the order based off of the tax rate.
        /// </summary>
        /// <param name="orderItems">Collection of order item models on the order.</param>
        /// <param name="taxRate">Tax rate to calculate the tax with.</param>
        /// <returns>Total amount of taxes on the order.</returns>
        decimal GetOrderTaxTotal(ICollection<OrderItem> orderItems, decimal taxRate);
    }
}
