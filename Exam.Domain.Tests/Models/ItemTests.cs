using Exam.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Exam.Domain.Tests.Models
{
    [TestClass]
    public class ItemTests
    {
        public Bogus.Randomizer _randomizer;

        [TestInitialize]
        public void Initialize()
        {
            _randomizer = new Bogus.Randomizer();
        }

        [TestMethod]
        public void NewItem_ReturnsKey()
        {
            int key = _randomizer.Int();
            string name = _randomizer.Words();
            decimal price = _randomizer.Decimal();
            Item item = new Item(key, name, price);

            Assert.AreEqual(key, item.Key);
        }

        [TestMethod]
        public void NewItem_ReturnsName()
        {
            int key = _randomizer.Int();
            string name = _randomizer.Words();
            decimal price = _randomizer.Decimal();
            Item item = new Item(key, name, price);

            Assert.AreEqual(name, item.Name);
        }

        [TestMethod]
        public void NewItem_ReturnsPrice()
        {
            int key = _randomizer.Int();
            string name = _randomizer.Words();
            decimal price = _randomizer.Decimal();
            Item item = new Item(key, name, price);

            Assert.AreEqual(price, item.Price);
        }

        [TestMethod]
        public void AddItemToHashTable_ProperlyComparesKeys()
        {
            Hashtable table = new Hashtable();
            Item item1 = CreateModel();
            Item item2 = CreateModel();
            Item item3 = CreateModel();
            Item item4 = new Item(item1.Key, "test",9);
            Item item5 = new Item(item2.Key, "test", 9);
            Item item6 = new Item(item3.Key, "test", 9);
            Item item7 = CreateModel();
            table.Add(item1, "Test");
            table.Add(item2, "Test2");
            table.Add(item3, "Test3");

            Assert.AreEqual(table[item4], "Test");
            Assert.AreEqual(table[item5], "Test2");
            Assert.AreEqual(table[item6], "Test3");
            Assert.IsFalse(table.ContainsKey(item7));
        }

        public static Item CreateModel()
        {
            Bogus.Randomizer randomizer = new Bogus.Randomizer();
            int key = randomizer.Int();
            string name = randomizer.Words();
            decimal price = randomizer.Decimal();
            Item item = new Item(key, name, price);
            return item;
        }
    }
}
