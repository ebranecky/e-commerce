using Exam.Domain.Enums;
using System;

namespace Exam.Domain.Models
{
    /// <summary>
    /// Order item class order items on orders.
    /// </summary>
    [Serializable]
    public class OrderItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItem"/> class.
        /// </summary>
        /// <param name="item">Instance of the item class.</param>
        /// <param name="quantity">Quantity being ordered.</param>
        /// <param name="orderItemType">Type of item being ordered.</param>
        public OrderItem(Item item, decimal quantity, OrderItemType orderItemType)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is requied to created an order item.");
            }

            if (quantity == 0)
            {
                throw new ArgumentException(nameof(quantity), "Quantity must be greater than zero to create an order item.");
            }

            Item = item;

            Quantity = quantity;

            ItemType = orderItemType;
        }

        /// <summary>
        /// Gets an item model that is linked to the order item.
        /// </summary>
        public Item Item { get; }

        /// <summary>
        /// Gets the order item quantity on the order.
        /// </summary>
        public decimal Quantity { get; }

        /// <summary>
        /// Gets the order item type.
        /// </summary>
        public OrderItemType ItemType { get; }
    }
}
