using TodoTaskManagement.Application.ResponseWrappers;

namespace TodoTaskManagement.Application.Features.TodoCategories.GetTodoCategories;

public class GetTodoCategoriesQuery : IRequest<Response<IEnumerable<TodoCategoryResult>>>
{
    
}