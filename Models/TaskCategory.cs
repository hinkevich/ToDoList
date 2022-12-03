namespace ToDoList.Models
{
    public class TaskCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public bool IsDeleted { get; set; }
    }
}