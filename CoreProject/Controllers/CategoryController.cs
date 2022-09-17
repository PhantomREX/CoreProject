using CoreProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoreProject.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
       
        public IActionResult Index(string param)
        {
            if (!string.IsNullOrEmpty(param))
            {
                return View(categoryRepository.List(x => x.CategoryName == param));
            }
            return View(categoryRepository.GenericList());
        }

        [HttpGet] 
        public IActionResult CategoryAdd()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            else
            {
                categoryRepository.GenericAdd(p);
                return RedirectToAction("Index");
            }
        }

        public IActionResult CategoryGet(int id)
        {

            var i = categoryRepository.GenericGet(id);
            Category category = new Category()
            {
                CategoryName = i.CategoryName,
                CategoryDescription = i.CategoryDescription,
                CategoryID = i.CategoryID

            };
            return View(category);


        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category c)
        {
            var x = categoryRepository.GenericGet(c.CategoryID);
            x.CategoryName = c.CategoryName;
            x.CategoryDescription = c.CategoryDescription;
            x.IsApprovedStatu = true;
            categoryRepository.GenericUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.GenericGet(id);
            x.IsApprovedStatu=false;
            categoryRepository.GenericUpdate(x);
            return RedirectToAction("Index");

        }










    }
}
 