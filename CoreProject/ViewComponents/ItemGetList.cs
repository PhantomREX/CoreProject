using CoreProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.ViewComponents
{
    public class ItemGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ItemRepository itemRepository = new ItemRepository();
            var itemList = itemRepository.GenericList();
            return View(itemList);
            

        }


    }
}
