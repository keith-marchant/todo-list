using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InfoTrack.Common.Application;
using TodoList.Application.Common;
using TodoList.Application.Entities;
using TodoList.Application.Items.Dtos;

namespace TodoList.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand, TodoItemDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TodoItemDto> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = new TodoItem
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                Status = TodoItemStatus.Incomplete
            };

            _context.TodoItems.Add(item);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TodoItemDto>(item);
        }
    }
}
