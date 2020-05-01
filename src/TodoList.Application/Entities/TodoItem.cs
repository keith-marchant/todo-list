using System;

namespace TodoList.Application.Entities
{
    public class TodoItem
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TodoItemStatus Status { get; set; }
    }
}
