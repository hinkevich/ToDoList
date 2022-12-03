using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class UserTask
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Lenght can be more than 3")]
        [Display(Name = "Description of task")]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; }
        public string TaskCategory { get; set; }

        [Display(Name = "Is done")]
        public bool IsDone { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime MakingDate { get; set; } = DateTime.Now;
        
        [DataType(DataType.DateTime)]
        [Display(Name = "DeadLine Date")]
        public DateTime Dedline { get; set; } = DateTime.Now.AddDays(1);

    }
}
