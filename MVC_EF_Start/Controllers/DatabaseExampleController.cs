using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
    public class DatabaseExampleController : Controller
    {
        public ApplicationDbContext dbContext;

        public DatabaseExampleController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> DatabaseOperations()
        {
            Order Order1 = new Order();
            Order1.Quantity = 10;
            Order1.TotalCost = 15;
            Order1.date = "01/01/2021";

            Order Order2 = new Order();
            Order2.Quantity = 20;
            Order2.TotalCost = 25;
            Order2.date = "01/02/2021";

            Product Product1 = new Product();
            Product1.name = "Cake1";
            Product1.brand = "Brand1";
            Product1.UnitPrice = 5;

            Product Product2 = new Product();
            Product2.name = "Cake2";
            Product2.brand = "Brand2";
            Product2.UnitPrice = 6;

            Product Product3 = new Product();
            Product3.name = "Cake3";
            Product3.brand = "Brand3";
            Product3.UnitPrice = 3;

            OrderDetails orderItem1 = new OrderDetails
            {
                PurchasedItem = Product1,
                PlacedOrder = Order1

            };

            OrderDetails orderItem2 = new OrderDetails
            {
                PurchasedItem = Product2,
                PlacedOrder = Order1
            };

            OrderDetails orderItem3 = new OrderDetails
            {
                PurchasedItem = Product2,
                PlacedOrder = Order2
            };

            OrderDetails orderItem4 = new OrderDetails
            {
                PurchasedItem = Product3,
                PlacedOrder = Order2
            };
          

            dbContext.Orders.Add(Order1);
            dbContext.Orders.Add(Order2);
            dbContext.Products.Add(Product1);
            dbContext.Products.Add(Product2);
            dbContext.Products.Add(Product3);
            dbContext.OrderItems.Add(orderItem1);
            dbContext.OrderItems.Add(orderItem2);
            dbContext.OrderItems.Add(orderItem3);
            dbContext.OrderItems.Add(orderItem4);


            dbContext.SaveChanges();

            return View();
        }

        public ViewResult LINQOperations()
        {
            Product ProductRead1 = dbContext.Products
                                            .Include(o => o.ProductOrders)
                                            .Where(o => o.name == "Oreos")
                                            .First();
            return View();
        }

    }
}