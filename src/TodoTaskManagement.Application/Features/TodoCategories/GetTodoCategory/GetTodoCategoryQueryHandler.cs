using TodoTaskManagement.Domain.Identifiers;

namespace TodoTaskManagement.Application.Features.TodoCategories.GetTodoCategory;

public class GetTodoCategoryQueryHandler : IRequestHandler<GetTodoCategoryQuery, Response<TodoCategoryResult>>
{
    private readonly ITodoCategoryRepository _todoCategoryRepository;
    private readonly IMapper _mapper;

    public GetTodoCategoryQueryHandler(ITodoCategoryRepository todoCategoryRepository, IMapper mapper)
    {
        _todoCategoryRepository = todoCategoryRepository;
        _mapper = mapper;
    }

    public async Task<Response<TodoCategoryResult>> Handle(GetTodoCategoryQuery request, CancellationToken cancellationToken)
    {
        var categoryId = TodoCategoryId.From(request.Id);
        
        var todoCategory = await _todoCategoryRepository.GetByIdAsync(categoryId);
        
        if (todoCategory is null)
        {
            throw new NotFoundException($"No Todo Category was found with the id {categoryId}");
        }
        
        var response = Response<TodoCategoryResult>.Success(
            _mapper.Map<TodoCategory,TodoCategoryResult>(todoCategory),
            $"The requested Todo Category with the id {categoryId} was found");

        return response;
    }
}