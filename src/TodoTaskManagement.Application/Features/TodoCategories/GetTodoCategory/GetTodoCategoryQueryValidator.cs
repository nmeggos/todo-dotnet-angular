namespace TodoTaskManagement.Application.Features.TodoCategories.GetTodoCategory;

public class GetTodoCategoryQueryValidator : AbstractValidator<GetTodoCategoryQuery>
{
    public GetTodoCategoryQueryValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty().WithMessage("A valid id value is required to complete this request.");
    }
}