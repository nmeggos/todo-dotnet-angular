
namespace TodoTaskManagement.Application.Features.TodoCategories.GetTodoCategories;

public class GetTodoCategoriesQueryHandler : IRequestHandler<GetTodoCategoriesQuery, Response<IEnumerable<TodoCategoryResult>>>
{
    private readonly ITodoCategoryRepository _todoCategoryRepository;
    private readonly IMapper _mapper;
    
    public GetTodoCategoriesQueryHandler(ITodoCategoryRepository todoCategoryRepository, IMapper mapper)
    {
        _todoCategoryRepository = todoCategoryRepository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<TodoCategoryResult>>> Handle(GetTodoCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _todoCategoryRepository.GetAllAsync();

        if (!categories.Any() && categories is null)
        {
            throw new NotFoundException($"No Todo Categories were found.");
        }

        var response = Response<IEnumerable<TodoCategoryResult>>.Success(
            _mapper.Map<IEnumerable<TodoCategory>, IEnumerable<TodoCategoryResult>>(categories),
            $"Successfully retrieved {categories.Count()}");

        return response;
    }
}