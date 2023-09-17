using AutoMapper;
using TodoTaskManagement.Application.Features.GetTodoItems;

namespace TodoTaskManagement.Application.UnitTests.Features.GetTodoItemsTests;

public class GetTodoItemsQueryHandlerTests
{
    private readonly Mock<ITodoItemRepository> _todoItemRepositoryMock;
    private readonly IMapper _mapper;

    public GetTodoItemsQueryHandlerTests()
    {
        _todoItemRepositoryMock = new();
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TodoItemMapProfile>();
        }).CreateMapper();
    }

    [Fact]
    public async Task Handle_GivenValidRequest_ShouldReturnTodoItems()
    {
        // Arrange

        var queryRequest = new GetTodoItemsQuery();

        _todoItemRepositoryMock.Setup(
            x => x.GetAll())
            .ReturnsAsync(new List<TodoItem>
            {
                TodoItem.Create("Test Todo Item 1", "Test Todo Item Description 1"),
                TodoItem.Create("Test Todo Item 2", "Test Todo Item Description 2")
            });
        
        var handlerSut = new GetToItemsQueryHandler(
            _todoItemRepositoryMock.Object, 
            _mapper);

        // Act
        
        var response = await handlerSut.Handle(queryRequest, CancellationToken.None);

        // Assert
        
        response.Should().NotBeNull();
        response.Succeeded.Should().BeTrue();
        response.Errors.Should().BeNullOrEmpty();
        response.Data.Should().NotBeNullOrEmpty();
        response.Data.Should().HaveCount(2);
        response.Data.Should().BeOfType<List<TodoItemResult>>();
    }
}