using System;
using System.Threading;
using System.Threading.Tasks;
using InfoTrack.Common.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.Common;

namespace TodoList.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : AsyncRequestHandler<UpdateItemCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateItemCommandHandler(IAppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override async Task Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.TodoItems.FirstOrDefaultAsync(t => t.ItemId == request.ItemId);

            if (item is null)
            {
                throw new NotFoundException($"Could not find item {request.ItemId}");
            }

            item.Description = request.Description ?? item.Description;
            item.Status = request.Status;
            item.DueDate = request.DueDate ?? item.DueDate;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
