namespace TodoTaskManagement.Application.Features.TodoItems.GetTodoItem;

public class GetTodoItemQueryValidator : AbstractValidator<GetTodoItemQuery>
{
    public GetTodoItemQueryValidator()
    {
        RuleFor(t => t.Id)
            .NotEmpty();
    }
}