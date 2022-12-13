using System;

namespace ToDoList.Models
{
    public class ToDoListInfoContext
    {
        public Version version { get; set; }

        public DateTime CopyrightDate { get; set; }

        public bool Approved  { get; set; }

        public string ApprovedByName { get; set; }

    }

}

