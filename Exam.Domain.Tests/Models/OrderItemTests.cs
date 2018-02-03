using Exam.Domain.Enums;
using Exam.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exam.Domain.Tests.Models
{
    [TestClass]
    public class OrderItemTests
    {
        private Bogus.Randomizer _randomizer;

        [TestInitialize]
        public void Initialize()
        {
            _randomizer = new Bogus.Randomizer();
        }


        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void OrderItem_WithNullItem_ReturnsNullException()
        {
            decimal price = _randomizer.Decimal();
            OrderItemType type = _randomizer.Enum<OrderItemType>();
            OrderItem item = new OrderItem(null, price, type);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void OrderItem_WithNoQuantity_ReturnsException()
        {
            int key = _randomizer.Int();
            string name = _randomizer.Words();
            decimal price = _randomizer.Decimal();
            Item item = new Item(key, name, price);
            OrderItemType type = _randomizer.Enum<OrderItemType>();
            OrderItem orderItem = new OrderItem(item, 0, type);
        }

        [TestMethod]
        public void OrderItem_ReturnsItem()
        {
            Item item = ItemTests.CreateModel();
            decimal quantity = _randomizer.Decimal();
            OrderItemType type = _randomizer.Enum<OrderItemType>();
            OrderItem orderItem = new OrderItem(item, quantity, type);

            Assert.AreEqual(item, orderItem.Item);
        }

        [TestMethod]
        public void OrderItem_ReturnsQuantity()
        {
            Item item = ItemTests.CreateModel();
            decimal quantity = _randomizer.Decimal();
            OrderItemType type = _randomizer.Enum<OrderItemType>();
            OrderItem orderItem = new OrderItem(item, quantity, type);

            Assert.AreEqual(quantity, orderItem.Quantity);
        }

        [TestMethod]
        public void OrderItem_ReturnsType()
        {
            Item item = ItemTests.CreateModel();
            decimal quantity = _randomizer.Decimal();
            OrderItemType type = _randomizer.Enum<OrderItemType>();
            OrderItem orderItem = new OrderItem(item, quantity, type);

            Assert.AreEqual(type, orderItem.ItemType);
        }

        public static OrderItem CreateModel()
        {
            Bogus.Randomizer randomizer = new Bogus.Randomizer();
            Item item = ItemTests.CreateModel();
            decimal quantity = randomizer.Decimal();
            OrderItemType type = randomizer.Enum<OrderItemType>();
            OrderItem orderItem = new OrderItem(item, quantity, type);
            return orderItem;
        }
    }
}
