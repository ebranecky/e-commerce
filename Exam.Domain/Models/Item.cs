using System;

namespace Exam.Domain.Models
{

    /// <summary>
    /// Item class for items on order items.
    /// </summary>
    [Serializable]
    public class Item

    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="key">Unique key value for item.</param>
        /// <param name="name">Name of the item.</param>
        /// <param name="price">Price of the item.</param>
        public Item(int key, string name, decimal price)

        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Name is requied for an item");
            }

            Key = key;
            Name = name;
            Price = price;
        }

        /// <summary>
        /// Gets the unique key for the item.
        /// </summary>
        public int Key { get; }

        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the price of the item.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Equals function to compare the key values of two item objects to determine if they match.
        /// </summary>
        /// <param name="obj">Object instance.</param>
        /// <returns>Boolean value indicating if item keys match or not.</returns>
        public override bool Equals(object obj)
        {
            if ( obj as Item != null)
            {
                if (Key == (obj as Item).Key)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Function to return the hash code for the item key.
        /// </summary>
        /// <returns>Returns the hash code for the item key.</returns>
        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

    }
}
