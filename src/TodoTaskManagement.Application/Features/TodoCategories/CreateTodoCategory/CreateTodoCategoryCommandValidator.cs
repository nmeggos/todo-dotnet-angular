namespace TodoTaskManagement.Application.Features.TodoCategories.CreateTodoCategory;

public class CreateTodoCategoryCommandValidator : AbstractValidator<CreateTodoCategoryCommand>
{
    public CreateTodoCategoryCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}