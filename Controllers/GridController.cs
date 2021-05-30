using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class GridController : Controller
    {
        private static ICollection<Product> products;
        public GridController()
        {
            if (products == null)
            {
                var random = new Random();
                products = Enumerable.Range(1, 100).Select(x => new Product
                {
                    Discontinued = x % 2 == 1,
                    ProductID = x,
                    ProductName = "Product " + x,
                    UnitPrice = random.Next(11, 300),
                    UnitsInStock = random.Next(11, 300),
                    UnitsOnOrder = random.Next(11, 300)

                }).ToList();
            }
        }

        public IActionResult CustomDataSource()
        {
            return View();
        }
        public ActionResult Read()
        {
            return Json(new MyResponseModel { DataCollection = products, TotalRecords = products.Count });
        }
    }
}
