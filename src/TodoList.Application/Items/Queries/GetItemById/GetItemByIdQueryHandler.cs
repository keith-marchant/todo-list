using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InfoTrack.Common.Application;
using InfoTrack.Common.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.Common;
using TodoList.Application.Items.Dtos;

namespace TodoList.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQueryHandler : IQueryHandler<GetItemByIdQuery, TodoItemDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetItemByIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TodoItemDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _context.TodoItems.FirstOrDefaultAsync(t => t.ItemId == request.ItemId);

            if (item is null)
            {
                throw new NotFoundException($"Could not find item {request.ItemId}");
            }

            return _mapper.Map<TodoItemDto>(item);
        }
    }
}
