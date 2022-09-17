using CoreProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents
{
    public class ItemListByCategory : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {


            ItemRepository itemRepository = new ItemRepository();
            var itemList = itemRepository.List(x=>x.CategoryID==id);
            return View(itemList);


        }
    }
}
