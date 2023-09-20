namespace TodoTaskManagement.Application.Features.TodoItems.CreateTodoItem;

public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(i => i.Title)
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(i => i.Description)
            .MaximumLength(500);
    }
}