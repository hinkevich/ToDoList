using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Models.Repo
{
    public interface IToDoMenu
    {
        IEnumerable<ItemSideBar> itemsSideBars { get; }
    }
}