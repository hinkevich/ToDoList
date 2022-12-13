using System;

namespace ToDoList.Models.Repo
{
    public class ECToDoListInfo : IToDoListInfo
    {
        ToDoListInfoContext IToDoListInfo.InfoToDoLis => new ToDoListInfoContext()
        {
            version = new System.Version(1, 1, 2, 2),
            Approved = true,
            ApprovedByName = "Serge Hinkevich",
            CopyrightDate = new System.DateTime(2022, 12, 13, 18, 50, 00)
        };
    }
}
