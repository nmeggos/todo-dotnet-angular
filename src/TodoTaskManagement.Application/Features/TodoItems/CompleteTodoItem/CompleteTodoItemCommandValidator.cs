namespace TodoTaskManagement.Application.Features.TodoItems.CompleteTodoItem;

public class CompleteTodoItemCommandValidator : AbstractValidator<CompleteTodoItemCommand>
{
    public CompleteTodoItemCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("The id of the todo item is required.")
            .NotNull();
    }
}