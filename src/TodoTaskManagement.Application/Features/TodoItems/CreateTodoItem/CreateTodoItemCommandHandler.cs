namespace TodoTaskManagement.Application.Features.TodoItems.CreateTodoItem;

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Response<string>>
{
    private readonly ITodoItemRepository _todoItemRepository;

    public CreateTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<Response<string>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = TodoItem.Create(request.Title, request.Description, TodoCategoryId.From(request.CategoryId));

        await _todoItemRepository.Add(todoItem);
        
        return Response<string>.Success($"The requested todo item was successfully saved with id value of {todoItem.Id}");
    }
}