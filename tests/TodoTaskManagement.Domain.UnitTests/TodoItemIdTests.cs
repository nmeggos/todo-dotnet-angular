namespace TodoTaskManagement._UnitTests;

public class TodoItemIdTests
{
    public TodoItemIdTests()
    {
        
    }
    
    [Fact]
    public void WhenCreatingNewTodoItemId_ThenValueIsNotEmpty()
    {
        // Arrange
        
        // Act
        var todoItemId = TodoItemId.New();
        
        // Assert
        todoItemId.Value.Should().NotBeEmpty();
    }
    
    [Fact]
    public void WhenInitializingTodoItemIdFromGuid_ThenValueIsNotEmpty()
    {
        // Arrange
        var guid = Guid.NewGuid();
        
        // Act
        var todoItemId = TodoItemId.From(guid);
        
        // Assert
        todoItemId.Value.Should().NotBeEmpty();
    }
    
    [Fact]
    public void WhenInitializingTodoItemIdFromString_ThenValueIsNotEmpty()
    {
        // Arrange
        var guid = Guid.NewGuid();
        
        // Act
        var todoItemId = TodoItemId.From(guid.ToString());
        
        // Assert
        todoItemId.Value.Should().NotBeEmpty();
    }
    
    [Fact]
    public void WhenInitializingTodoItemIdFromInvalidString_ThenThrowsInvalidTodoItemIdException()
    {
        // Arrange
        var invalidValue = "ABC";
        
        // Act
        Action action = () => TodoItemId.From(invalidValue);
        
        // Assert
        action.Should().Throw<InvalidTodoItemIdException>();
    }
    
    [Fact] 
    public void WhenComparingTwoTodoItemIds_ThenTheyAreEqual()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var todoItemId1 = TodoItemId.From(guid);
        var todoItemId2 = TodoItemId.From(guid);
        
        // Act
        var areEqual = todoItemId1 == todoItemId2;
        
        // Assert
        areEqual.Should().BeTrue();
    }
    
    [Fact]
    public void WhenComparingTwoTodoItemIds_ThenTheyAreNotEqual()
    {
        // Arrange
        var todoItemId1 = TodoItemId.New();
        var todoItemId2 = TodoItemId.New();
        
        // Act
        var areEqual = todoItemId1 == todoItemId2;
        
        // Assert
        areEqual.Should().BeFalse();
    }
    
    [Fact]
    public void WhenConvertTodoItemIdToString_ThenValueShouldBeExpected()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var todoItemId = TodoItemId.From(guid);
        
        // Act
        var todoItemIdString = todoItemId.ToString();
        
        // Assert
        todoItemIdString.Should().Be(guid.ToString());
    }
}