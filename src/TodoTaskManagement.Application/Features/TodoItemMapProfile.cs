
namespace TodoTaskManagement.Application.Features;

public class TodoItemMapProfile : Profile
{
    public TodoItemMapProfile()
    {
        CreateMap<TodoItem, TodoItemResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
    }
}