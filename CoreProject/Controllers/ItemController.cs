using CoreProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoreProject.Data.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using X.PagedList;
using System.IO;
using System;

namespace CoreProject.Controllers
{
    public class ItemController : Controller
    {
        Context c = new Context();
        ItemRepository itemRepository = new ItemRepository();
        public IActionResult Index(int page = 1)
        {

            return View(itemRepository.GenericList("Category").ToPagedList(page, 5));
        }
        [HttpGet]
        public IActionResult AddItem()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;

            return View();
        }
        [HttpPost]
        public IActionResult AddItem(AddItem p)
        {

            Item i = new Item();
            if (p.ImageURL!=null)
            {
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newimagename= Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images/",newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                i.ImageURL = newimagename;
            }

            i.Name = p.Name;
            i.Description = p.Description;
            i.Price = p.Price;
            i.Stock = p.Stock;
            i.CategoryID = p.CategoryID;


            itemRepository.GenericAdd(i);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(int id)
        {

            itemRepository.GenericDelete(new Item { ItemId = id });
            return RedirectToAction("Index");
        }

        public IActionResult ItemGet(int id)
        {
            var x = itemRepository.GenericGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            Item i = new Item()
            {
                ItemId = x.ItemId,
                CategoryID = x.CategoryID,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                ImageURL = x.ImageURL

            };
            return View(i);
        }

        [HttpPost]
        public IActionResult ItemUpdate(Item i)
        {
            var x = itemRepository.GenericGet(i.ItemId);
            x.ImageURL = i.ImageURL;
            x.Name = i.Name;
            x.Description = i.Description;
            x.Price = i.Price;
            x.Stock = i.Stock;
            x.CategoryID = i.CategoryID;
            itemRepository.GenericUpdate(x);



            return RedirectToAction("Index");
        }




    }
}
