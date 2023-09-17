namespace TodoTaskManagement._UnitTests;

public class TodoItemTests
{
    public TodoItemTests()
    {
        
    }
    
    [Fact]
    public void WhenCreatingValidTodoItem_ThenCreatesTodoItem()
    {
        // Arrange
        var title = "Some title";
        var description = "Some description";
        
        // Act
        var todoItem = TodoItem.Create(title, description);
        
        // Assert
        todoItem.Should().NotBeNull();
        todoItem.Title.Should().Be(title);
        todoItem.Description.Should().Be(description);
        todoItem.CreatedOn.Should().NotBe(null);
        todoItem.UpdatedOn.Should().BeNull();
        todoItem.CompletedOn.Should().BeNull();
        todoItem.IsCompleted.Should().BeFalse();
    }
    
    [Fact]
    public void WhenCreatingTodoItemWithEmptyTitle_ThenThrowsInvalidTodoItemTitleException()
    {
        // Arrange
        var title = string.Empty;
        var description = "Some description";
        
        // Act
        Action action = () => TodoItem.Create(title, description);
        
        // Assert
        action.Should().Throw<InvalidTodoItemTitleException>();
    }
    
    [Fact]
    public void WhenUpdatingTodoItemWithValidValues_ThenUpdatesTodoItem()
    {
        // Arrange
        var todoItem = TodoItem.Create("Some title", "Some description");
        var title = "Some new title";
        var description = "Some new description";
        
        // Act
        todoItem.Update(title, description);
        
        // Assert
        todoItem.Title.Should().Be(title);
        todoItem.Description.Should().Be(description);
        todoItem.UpdatedOn.Should().NotBeNull();
    }
    
    [Fact]
    public void WhenUpdatingTodoItemWithInvalidTitle_ThenThrowsInvalidTodoItemTitleException()
    {
        // Arrange
        var todoItem = TodoItem.Create("Some title", "Some description");
        var title = string.Empty;
        var description = "Some new description";
        
        // Act
        Action action = () => todoItem.Update(title, description);
        
        // Assert
        action.Should().Throw<InvalidTodoItemTitleException>();
    }
    
    [Fact]
    public void WhenCompletingTodoItem_ThenCompletesTodoItem()
    {
        // Arrange
        var todoItem = TodoItem.Create("Some title", "Some description");
        
        // Act
        todoItem.Complete();
        
        // Assert
        todoItem.CompletedOn.Should().NotBeNull();
        todoItem.UpdatedOn.Should().NotBeNull();
        todoItem.CompletedOn.Should().Be(todoItem.UpdatedOn);
        todoItem.IsCompleted.Should().BeTrue();
    }
}