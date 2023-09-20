﻿using TodoTaskManagement.Application.ResponseWrappers;

namespace TodoTaskManagement.Application.Features.CreateTodoItem;

public class CreateTodoItemCommand : IRequest<Response<string>>
{
    public CreateTodoItemCommand()
    {
        
    }
    
    public string Title { get; set; }
    public string Description { get; set; }
}