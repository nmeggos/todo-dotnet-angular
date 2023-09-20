namespace TodoTaskManagement.Application.Features.TodoCategories.CreateTodoCategory;

public class CreateTodoCategoryCommandHandler : IRequestHandler<CreateTodoCategoryCommand, Response<string>>
{
    private readonly ITodoCategoryRepository _todoCategoryRepository;

    public CreateTodoCategoryCommandHandler(ITodoCategoryRepository todoCategoryRepository)
    {
        _todoCategoryRepository = todoCategoryRepository;
    }

    public async Task<Response<string>> Handle(CreateTodoCategoryCommand request, CancellationToken cancellationToken)
    {
        var todoCategory = TodoCategory.Create(request.Name);
        
        var todoCategoryId = await _todoCategoryRepository.AddAsync(todoCategory);
        
        return Response<string>.Success(todoCategoryId?.ToString(), $"Successfully created todo category with id {todoCategoryId}");
    }
}