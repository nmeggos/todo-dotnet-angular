using TodoTaskManagement.Application.ResponseWrappers;
using TodoTaskManagement.Domain;
using TodoTaskManagement.Domain.Interfaces;

namespace TodoTaskManagement.Application.Features.GetTodoItems;

internal class GetToItemsQueryHandler : IRequestHandler<GetTodoItemsQuery,Response<IEnumerable<TodoItemResult>>>
{
    private readonly ITodoItemRepository _todoItemRepository;
    private readonly IMapper _mapper;

    public GetToItemsQueryHandler(ITodoItemRepository todoItemRepository, IMapper mapper)
    {
        _todoItemRepository = todoItemRepository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<TodoItemResult>>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var todoItems = await _todoItemRepository.GetAll();
        var results = _mapper.Map<IEnumerable<TodoItem>,IEnumerable<TodoItemResult>>(todoItems);
        return Response<IEnumerable<TodoItemResult>>.Success(results, "Todo Items Retrieved Successfully");
    }
}