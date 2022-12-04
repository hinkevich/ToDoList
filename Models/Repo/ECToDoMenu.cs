using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace ToDoList.Models.Repo
{
    public class ECToDoMenu : IToDoMenu
    {
        private readonly ToDoListDbContext _context;

        public ECToDoMenu(ToDoListDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ItemSideBar> itemsSideBars => MakeMenu();

        private IEnumerable<ItemSideBar> MakeMenu()
        {
            var menu = new List<ItemSideBar>();

            var categories = from c in _context.TaskCategories
                             select c;
            menu.Add(new ItemSideBar() { Id = 0, Name = "All tasks", IsActiv = false });
            foreach (var category in categories)
            {
                var itemMenu = new ItemSideBar() { Id = category.Id, Name = category.Category, IsActiv = false };
                menu.Add(itemMenu);
            }
            return menu;
        }
    }
}
