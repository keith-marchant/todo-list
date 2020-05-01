using System;
using InfoTrack.Common.Application;
using TodoList.Application.Items.Dtos;

namespace TodoList.Application.Items.Commands.CreateItem
{
    public class CreateItemCommand : ICommand<TodoItemDto>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
