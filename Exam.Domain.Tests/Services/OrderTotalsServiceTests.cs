using Exam.Domain.Enums;
using Exam.Domain.Models;
using Exam.Domain.Services;
using Exam.Domain.Tests.Models;
using Exam.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exam.Infrastructure.Tests.Services
{
    [TestClass]
    public class OrderTotalsServiceTests
    {
        private IOrderTotalsService _totalsService;

        [TestInitialize]
        public void Initialize()
        {
            _totalsService = new OrderTotalsService();
        }

        [TestMethod]
        public void GetOrderTotal_ReturnsTotal()
        {
            Bogus.Randomizer randomizer = new Bogus.Randomizer();
            Order order = OrderTests.CreateModel();
            decimal orderTotal = 0;
            decimal taxRate = randomizer.Decimal();
            foreach (var item in order.OrderItems)
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

            Assert.AreEqual(_totalsService.GetOrderTotal(order.OrderItems, taxRate), Decimal.Round(orderTotal, 2));
        }

        [TestMethod]
        public void GetOrderTaxTotal_ReturnsTotal()
        {
            Bogus.Randomizer randomizer = new Bogus.Randomizer();
            Order order = OrderTests.CreateModel();
            decimal taxTotal = 0;
            decimal taxRate = randomizer.Decimal();
            foreach (var item in order.OrderItems)
            {
                decimal price = item.Item.Price;
                if (item.ItemType == OrderItemType.Material)
                {
                    taxTotal += price * (taxRate / 100);
                }
            }

            Assert.AreEqual(_totalsService.GetOrderTaxTotal(order.OrderItems, taxRate), Decimal.Round(taxTotal, 2));
        }
    }
}
