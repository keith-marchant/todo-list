using InfoTrack.Common.Application;
using TodoList.Application.Items.Dtos;

namespace TodoList.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQuery : IQuery<TodoItemDto>
    {
        public GetItemByIdQuery(int itemId)
        {
            ItemId = itemId;
        }

        public int ItemId { get; }
    }
}
