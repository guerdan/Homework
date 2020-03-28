using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            Order a = new Order();
            a.ClientName = "xiaoming";
            a.OrderNum = 123;
            Order b = new Order();
            b.ClientName = "xiaoming";
            b.OrderNum = 123;
            OrderService c = new OrderService();
            c.AddOrder(a);
            c.AddOrder(b);
            Assert.IsFalse(OrderService.orders[0]==b);

        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            OrderService c = new OrderService();
            Order a = new Order();
            c.AddOrder(a);
            c.RemoveOrder(a);
            Assert.IsFalse(OrderService.orders.Contains(a));
        }
        

        [TestMethod()]
        public void QueryByNumTest()
        {
            Order a = new Order();
            a.ClientName = "xiaoming";
            a.OrderNum = 123;
            Order b = new Order();
            b.ClientName = "xiaohong";
            b.OrderNum = 456;
            OrderService c = new OrderService();
            c.AddOrder(a);
            c.AddOrder(b);
            c.QueryByNum(123);
            Assert.IsTrue(OrderService.orders.Contains(a));


        }

        [TestMethod()]
        public void QueryByNameTest()
        {
            Order a = new Order();
            a.ClientName = "xiaoming";
            a.OrderNum = 123;
            Order b = new Order();
            b.ClientName = "xiaohong";
            b.OrderNum = 456;
            OrderService c = new OrderService();
            c.AddOrder(a);
            c.AddOrder(b);
            c.QueryByName("xiaohong");
            Assert.IsTrue(OrderService.orders.Contains(b));
        }

        [TestMethod()]
        public void OrderSortTest()
        {
            Order a = new Order();
            a.ClientName = "xiaoming";
            a.OrderNum = 123;
            Order b = new Order();
            b.ClientName = "xiaohong";
            b.OrderNum = 456;
            OrderService c = new OrderService();
            c.AddOrder(b);
            c.AddOrder(a);
            c.OrderSort();
            Assert.IsTrue(OrderService.orders[0].Equals(a));
        }

        
    }
}