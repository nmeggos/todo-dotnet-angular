using TodoTaskManagement.Application.ResponseWrappers;
using TodoTaskManagement.Domain.Exceptions;
using TodoTaskManagement.Domain.Interfaces;

namespace TodoTaskManagement.Application.Features.TodoItems.GetTodoItem;

public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemQuery, Response<TodoItemResult>>
{
    private readonly ITodoItemRepository _todoItemRepository;
    private readonly IMapper _mapper;

    public GetTodoItemQueryHandler(ITodoItemRepository todoItemRepository, IMapper mapper)
    {
        _todoItemRepository = todoItemRepository;
        _mapper = mapper;
    }

    public async Task<Response<TodoItemResult>> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
    {
        var todoItemId = TodoItemId.From(request.Id);
        
        var todoItem = await _todoItemRepository.GetById(todoItemId);
        
        if (todoItem is null)
        {
            throw new NotFoundException(typeof(TodoItem), request.Id);
        }
        
        var response = Response<TodoItemResult>
            .Success(
                _mapper.Map<TodoItemResult>(todoItem), 
                $"Successfully retrieved TodoItem with id {request.Id}");

        return response;
    }
}