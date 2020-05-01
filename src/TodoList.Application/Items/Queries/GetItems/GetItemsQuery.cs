using System.Collections.Generic;
using InfoTrack.Common.Application;
using TodoList.Application.Items.Dtos;

namespace TodoList.Application.Items.Queries.GetItems
{
    public class GetItemsQuery : IQuery<IEnumerable<TodoItemDto>>
    {
    }
}
