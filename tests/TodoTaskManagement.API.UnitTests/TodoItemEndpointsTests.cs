using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TodoTaskManagement.API.Endpoints.v1;
using TodoTaskManagement.Application.Features;
using TodoTaskManagement.Application.Features.GetTodoItems;
using TodoTaskManagement.Application.ResponseWrappers;
using TodoTaskManagement.Domain;

namespace TodoTaskManagement.API.UnitTests;

public class TodoItemEndpointsTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private IMapper _mapper;

    public TodoItemEndpointsTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TodoItemMapProfile>();
        }).CreateMapper();
    }

    [Fact]
    public async Task GetTodoItems_Should_Return_Ok()
    {
        // Arrange
        
        var todos = new List<TodoItem>
        {
            TodoItem.Create("Test Todo Item 1", "Test Todo Item Description 1"),
            TodoItem.Create("Test Todo Item 2", "Test Todo Item Description 2")
        };
        
        var mappedResults = _mapper.Map<IEnumerable<TodoItem>,IEnumerable<TodoItemResult>>(todos);

        var expectedResponse =
            Response<IEnumerable<TodoItemResult>>.Success(mappedResults, "Todo Items retrieved successfully.");
        
        _mediatorMock.Setup(
                x => x.Send(It.IsAny<GetTodoItemsQuery>(), default))
            .ReturnsAsync(
                Response<IEnumerable<TodoItemResult>>
                    .Success(mappedResults, "Todo Items retrieved successfully."));
        
        // Act
        
        var responseSut = await TodoItemEndpoints.GetTodos(_mediatorMock.Object);
        
        // Assert
        
        var test = responseSut.Value.Data;
        
        responseSut.Should().BeOfType<Ok<Response<IEnumerable<TodoItemResult>>>>();
        responseSut.Value.Should().BeOfType<Response<IEnumerable<TodoItemResult>>>();
        responseSut.Value.Data.Should().BeEquivalentTo(expectedResponse.Data);
        responseSut.StatusCode.Should().Be(StatusCodes.Status200OK);
    }
}