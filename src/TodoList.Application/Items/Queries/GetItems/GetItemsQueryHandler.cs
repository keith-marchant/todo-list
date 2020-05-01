using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InfoTrack.Common.Application;
using TodoList.Application.Common;
using TodoList.Application.Items.Dtos;

namespace TodoList.Application.Items.Queries.GetItems
{
    public class GetItemsQueryHandler : IQueryHandler<GetItemsQuery, IEnumerable<TodoItemDto>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetItemsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<IEnumerable<TodoItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var items = _context.TodoItems.ToList();

            return Task.FromResult(_mapper.Map<IEnumerable<TodoItemDto>>(items));
        }
    }
}
