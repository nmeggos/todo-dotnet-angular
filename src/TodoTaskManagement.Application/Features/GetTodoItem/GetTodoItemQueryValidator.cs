namespace TodoTaskManagement.Application.Features.GetTodoItem;

public class GetTodoItemQueryValidator : AbstractValidator<GetTodoItemQuery>
{
    public GetTodoItemQueryValidator()
    {
        RuleFor(t => t.Id)
            .NotEmpty();
    }
}