using System;
using InfoTrack.Common.Application;
using NJsonSchema.Annotations;
using TodoList.Application.Entities;

namespace TodoList.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommand : ICommand
    {
        [JsonSchemaIgnore]
        public int ItemId { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TodoItemStatus Status { get; set; }
    }
}
