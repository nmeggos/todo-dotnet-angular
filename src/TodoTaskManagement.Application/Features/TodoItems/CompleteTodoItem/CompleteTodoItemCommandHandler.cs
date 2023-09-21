using TodoTaskManagement.Domain.Identifiers;

namespace TodoTaskManagement.Application.Features.TodoItems.CompleteTodoItem;

public class CompleteTodoItemCommandHandler : IRequestHandler<CompleteTodoItemCommand, Response<string>>
{
    private readonly ITodoItemRepository _todoItemRepository;
    private readonly IMapper _mapper;

    public CompleteTodoItemCommandHandler(ITodoItemRepository todoItemRepository, IMapper mapper)
    {
        _todoItemRepository = todoItemRepository;
        _mapper = mapper;
    }

    public async Task<Response<string>> Handle(CompleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItemId = TodoItemId.From(request.Id);
        
        var todoItem = await _todoItemRepository.GetById(todoItemId);
        todoItem.Complete();
        
        await _todoItemRepository.Update(todoItem);
        
        return Response<string>.Success($"The requested todo item was successfully completed with id value of {todoItem.Id}");
    }
}