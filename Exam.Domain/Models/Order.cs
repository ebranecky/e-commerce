using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Domain.Models
{
    /// <summary>
    /// Order class used for information about created orders.
    /// </summary>
    [Serializable]
    public class Order

    {
        /// <summary>
        /// Collection of item models.
        /// </summary>
        private ICollection<Item> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="orderItems">Collection of order item models.</param>
        public Order(ICollection<OrderItem> orderItems)

        {
            if ( orderItems == null)
            {
                throw new ArgumentNullException(nameof(orderItems), "Order must contain order items.");
            }

            OrderItems = orderItems;

        }

        /// <summary>
        /// Gets a collection of item models.
        /// </summary>
        public ICollection<Item> Items
        {
            get
            {
                if (items == null)
                {
                    items = new List<Item>();
                }

                foreach (var item in OrderItems)
                {
                    items.Add(item.Item);
                }

                return items.OrderBy(x => x.Name).ToList();
            }
        }

        /// <summary>
        /// Gets a collection of order item models on the order.
        /// </summary>
        public ICollection<OrderItem> OrderItems { get; }

    }
}
