using CoreProject.Data;
using CoreProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoreProject.Controllers
{
    [AllowAnonymous]
    public class ChartController : Controller
    {

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ColumnIndex()
        {
            return View();
        }



        public IActionResult VisualizeItemResult()
        {
            return Json(ProductList());
        }
        public List<Class> ProductList()
        {
            List<Class> productListClass = new List<Class>();
            using (var c = new Context())
            {
                productListClass = c.Items.Select(x => new Class
                {
                    Stock = x.Stock,
                    ProductName=x.Name
                    
                }).ToList();
            }
            return productListClass;
        }



        public IActionResult Statistics()
        {
            Context c = new Context();

            var totalitem = c.Items.Count();
            ViewBag.totalitemVB = totalitem;

            var totalCategory = c.Categories.Count();
            ViewBag.totalCategoryVB = totalCategory;


            var lightingItemsType = c.Categories.Where(x => x.CategoryName == "Lighting").Select(y =>
            y.CategoryID).FirstOrDefault();
            ViewBag.lightingItemsVB = lightingItemsType;
            var lightingItems2 = c.Items.Where(x => x.CategoryID == lightingItemsType).Count();
            ViewBag.lightingItems2VB = lightingItems2;
            // Kaç çeşit Aydınlatma ürünü var

            var decorItemsType = c.Items.Where(x => x.CategoryID == c.Categories.Where(x => x.CategoryName == "Decor").Select(y =>
            y.CategoryID).FirstOrDefault()).Count();
            ViewBag.decorItemsVB = decorItemsType;
            // Kaç çeşit Dekor ürünü var

            var tableItemsType = c.Items.Where(x => x.CategoryID == c.Categories.Where(y => y.CategoryName == "Table").Select(z =>
            z.CategoryID).FirstOrDefault()).Count();
            ViewBag.tableItemsVB = tableItemsType;

            var mirrorItemsType = c.Items.Where(x => x.CategoryID == c.Categories.Where(y => y.CategoryName == "Mirror").Select(z =>
            z.CategoryID).FirstOrDefault()).Count();
            ViewBag.mirrorItemsVB = mirrorItemsType;

            var chairItemsType = c.Items.Where(x => x.CategoryID == c.Categories.Where(y => y.CategoryName == "Chair").Select(z =>
           z.CategoryID).FirstOrDefault()).Count();
            ViewBag.chairItemsVB = chairItemsType;


            var most = c.Items.OrderByDescending(x => x.Stock).Select(x => x.Name).FirstOrDefault();
            ViewBag.mostItemsVB = most;
            var quantity = c.Items.OrderByDescending(x => x.Stock).Select(x => x.Stock).FirstOrDefault();
            ViewBag.mostItemsQuantity = quantity;

            var mostExpensive = c.Items.OrderByDescending(x => x.Price).Select(x => x.Name).FirstOrDefault();
            ViewBag.mostExpensiveVB = mostExpensive;
            // fiyatına göre sırala ismini çek
            var expensive = c.Items.OrderByDescending(x => x.Price).Select(x => x.Price).FirstOrDefault();
            ViewBag.mostItemExpensiveVB = expensive;
            // fiyatına göre sırala fiyatını çek



            var allProductNumber = c.Items.Sum(x => x.Stock);
            ViewBag.allProductNumberVB = allProductNumber;

            var totalStockLightingID = c.Categories.Where(x => x.CategoryName == "Lighting").Select(y => y.CategoryID).FirstOrDefault();
            var totalStockLighting = c.Items.Where(y => y.CategoryID == totalStockLightingID).Sum(x => x.Stock);
            ViewBag.totalStockLightingID = totalStockLighting;

            var totalStockDecorID = c.Categories.Where(x => x.CategoryName == "Decor").Select(y => y.CategoryID).FirstOrDefault();
            var totalStockDecor = c.Items.Where(y => y.CategoryID == totalStockDecorID).Sum(x => x.Stock);
            ViewBag.totalStockDecorID = totalStockDecor;

            var totalStockTableID = c.Categories.Where(x => x.CategoryName == "Table").Select(y => y.CategoryID).FirstOrDefault();
            var totalStockTable = c.Items.Where(y => y.CategoryID == totalStockTableID).Sum(x => x.Stock);
            ViewBag.totalStockTableID = totalStockTable;

            var totalStockMirrorID = c.Categories.Where(x => x.CategoryName == "Mirror").Select(y => y.CategoryID).FirstOrDefault();
            var totalStockMirror = c.Items.Where(y => y.CategoryID == totalStockMirrorID).Sum(x => x.Stock);
            ViewBag.totalStockMirrorID = totalStockMirror;

            var totalStockChairID = c.Categories.Where(x => x.CategoryName == "Chair").Select(y => y.CategoryID).FirstOrDefault();
            var totalStockChair = c.Items.Where(y => y.CategoryID == totalStockChairID).Sum(x => x.Stock);
            ViewBag.totalStockChairID = totalStockChair;

            return View();
        }


    }
}
