using Microsoft.AspNetCore.Mvc;
using CoreProject.Repositories;
namespace CoreProject.ViewComponents
{
    public class CategoryGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var categoryList = categoryRepository.GenericList();
            return View(categoryList);

        }
    }
}
