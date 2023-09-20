namespace TodoTaskManagement.Application.Features.TodoCategories;

public class TodoCategoryMapProfile : Profile
{
    public TodoCategoryMapProfile()
    {
        CreateMap<TodoCategory, TodoCategoryResult>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id));
    }
}