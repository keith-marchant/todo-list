using FluentValidation;

namespace TodoList.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(i => i.Title).NotEmpty();
        }
    }
}
