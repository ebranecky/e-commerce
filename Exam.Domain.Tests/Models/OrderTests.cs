using Exam.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Exam.Domain.Tests.Models
{
    [TestClass]
    public class OrderTests
    {
        private Bogus.Randomizer _randomizer;

        [TestInitialize] 
        public void Initialize()
        {
            _randomizer = new Bogus.Randomizer();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NewOrder_WithNullItems_ReturnsNullException()
        {
            Order order = new Order(null);
        }

        [TestMethod]
        public void GetOrderItems_ReturnsSortedListOfItems()
        {
            ICollection<OrderItem> orderItems = CreateCollectionOfOrderItems(4);
            ICollection<Item> items = new List<Item>();
            foreach (var item in orderItems)
            {
                items.Add(item.Item);
            }

            var orderedList = items.OrderBy(x => x.Name).ToList();

            Order order = new Order(orderItems);

            var itemList = order.Items.ToList();

            Assert.AreEqual(itemList.Count, orderItems.Count);

            for (int i = 0; i < orderedList.Count(); i++)
            {
                Assert.AreEqual(orderedList[i].Key, itemList[i].Key);
            }
        }

        [TestMethod]
        public void SerializeOrder_Deserializes()
        {

            IFormatter formatter = new BinaryFormatter();
            Order order = CreateModel();
            decimal taxRate = _randomizer.Decimal();
            using (var memoryStream = new MemoryStream())
            {
                formatter.Serialize(memoryStream, order);
                memoryStream.Position = 0;
                Order deserializedOrder = (Order)formatter.Deserialize(memoryStream);
                Assert.AreEqual(deserializedOrder.Items.Count, order.Items.Count);
                Assert.AreEqual(deserializedOrder.OrderItems.Count, order.OrderItems.Count);
            }
        }

        public static Order CreateModel()
        {
            ICollection<OrderItem> orderItems = CreateCollectionOfOrderItems(4);
            Order order = new Order(orderItems);

            return order;
        }

        private static ICollection<OrderItem> CreateCollectionOfOrderItems(int count)
        {
            ICollection<OrderItem> orderItems = new List<OrderItem>();
            for (int i = 0; i < count; i++)
            {
                orderItems.Add(OrderItemTests.CreateModel());
            }

            return orderItems;
        }
    }
}
