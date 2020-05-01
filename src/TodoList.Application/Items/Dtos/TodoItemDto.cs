using System;
using System.Text.Json.Serialization;
using InfoTrack.Common.Application.Automapper;
using TodoList.Application.Entities;

namespace TodoList.Application.Items.Dtos
{
    public class TodoItemDto : IMapFrom<TodoItem>
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TodoItemStatus Status { get; set; }
    }
}
