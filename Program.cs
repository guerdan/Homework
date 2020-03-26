using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Program
{
    enum Products { Apple, OPPO, XiaoMi, Vivo, Samsung };
    class OrderDetails
    {
        public string Brand { set; get; }
        public int ProductID { set; get; }
        public double Price { set; get; }
        public OrderDetails(string Brand, int ProductID, double Price)
        {
            this.Brand = Brand;
            this.ProductID = ProductID;
            this.Price = Price;
        }
        public override string ToString()
        {
            return "Brand:" + Brand + "  " + "ProductID:" + ProductID + "  " + "Price:" + Price;
        }
        public override bool Equals(object obj)
        {
            OrderDetails m = obj as OrderDetails;
            return m != null && m.Brand == Brand && m.ProductID == ProductID && m.Price == Price;


        }
    }
    class Order
    {
        public string ClientName { set; get; }
        public int OrderNum { set; get; }
        public List<OrderDetails> orderDetails = new List<OrderDetails>();
        public double TotalAmount
        {
            get
            {
                double sum = 0;
                foreach (var orderDetail in orderDetails)
                {
                    sum += orderDetail.Price;
                }
                return sum;
            }

        }
        public void AddOrderDetails(OrderDetails orderDetail)
        {
            bool tag = true;

            foreach (var a in orderDetails)
            {
                if (orderDetail.Equals(a))
                {
                    Console.WriteLine("重复订单了");
                    tag = false;
                }
            }
            if (tag == true)
                this.orderDetails.Add(orderDetail);
        }
        public void RemoveOrderDetails(OrderDetails orderDetails)
        {
            this.orderDetails.Remove(orderDetails);
        }
        public override string ToString()
        {
            return "ClientName :" + ClientName + "  " + "OrderNum:" + OrderNum + "TotalAmount:" + TotalAmount;
        }
        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            return m != null && m.ClientName == ClientName && m.OrderNum == OrderNum;
        }
    }


    class OrderService
    {
        public static List<Order> orders = new List<Order>();//储存订单

        public void AddOrder(Order order)
        {
            bool tag = true;

            foreach (var a in orders)
            {
                if (order.Equals(a))
                {
                    Console.WriteLine("重复订单了");
                    tag = false;
                }
            }
            if (tag == true)
                orders.Add(order);
        }//添加订单

        public void RemoveOrder(Order order)
        {
            try
            {
                orders.Remove(order);
            }
            catch (Exception e)
            {
                Console.WriteLine("订单删除失败");
            }

        }//删除订单

        public void QueryByNum(int n)
        {
            var a = from N in orders
                    where N.OrderNum == n
                    orderby N.TotalAmount
                    select N;
            List<Order> order1 = a.ToList();
            order1.ForEach(p => Console.WriteLine(p));
        }
        public void QueryByName(string s)
        {
            var a = from N in orders
                    where N.ClientName == s
                    orderby N.TotalAmount
                    select N;
            List<Order> order1 = a.ToList();
            order1.ForEach(p => Console.WriteLine(p));
        }
        public void OrderSort()
        {
            orders.Sort((p1, p2) => p1.OrderNum - p2.OrderNum);
        }



    }
    class Program
    {
        static void Main(String[] args)
        {
            OrderDetails a1 = new OrderDetails("Apple", 1111, 5333);
            OrderDetails a2 = new OrderDetails("Vivo", 1112, 2333);
            OrderDetails a3 = new OrderDetails("OPPO", 1113, 3333);
            Order A = new Order();
            A.AddOrderDetails(a1);
            A.AddOrderDetails(a2);
            A.AddOrderDetails(a3);
            A.ClientName = "小红";
            A.OrderNum = 123;

            OrderDetails b1 = new OrderDetails("Apple", 1121, 5444);
            OrderDetails b2 = new OrderDetails("Vivo", 1122, 2444);
            OrderDetails b3 = new OrderDetails("OPPO", 1123, 3444);
            Order B = new Order();
            B.AddOrderDetails(b1);
            B.AddOrderDetails(b2);
            B.AddOrderDetails(b3);
            B.ClientName = "小明";
            B.OrderNum = 456;

            OrderService k = new OrderService();
            k.AddOrder(A);
            k.AddOrder(B);
            k.QueryByName("小红");
            k.QueryByNum(456);


        }
    }
}