using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Models.Repo;

namespace ToDoList.ViewComponents
{
    public class ItemsMenuViewComponent:ViewComponent
    {
        private readonly IToDoMenu toDoMenu;
        public ItemsMenuViewComponent(IToDoMenu menu)
        {
            toDoMenu = menu;
        }
        public async Task<IViewComponentResult> InvokeAsync(
        )
        {
            var items =  GetItemsAsync();
            return View(items);
        }
        private List<ItemSideBar> GetItemsAsync()
        {
            return toDoMenu.itemsSideBars.ToList();
        }
    }
}
