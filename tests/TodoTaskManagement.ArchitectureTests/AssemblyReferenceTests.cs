
namespace TodoTaskManagement.ArchitectureTests;

public class AssemblyReferenceTests
{
    [Fact]
    public void Domain_Should_NotReferenceOtherProjectAssemblies()
    {
        // Arrange
        
        var assembly = typeof(Domain.AssemblyReference).Assembly;

        var otherAssemblies = new[]
        {
            typeof(API.AssemblyReference).Namespace,
            typeof(Application.AssemblyReference).Namespace,
            typeof(Infrastructure.Persistence.AssemblyReference).Namespace,
            typeof(Infrastructure.Shared.AssemblyReference).Namespace
        };
        
        // Act

        var assemblySut = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherAssemblies)
            .GetResult();

        // Assert

        assemblySut.IsSuccessful.Should().BeTrue();

    }
    
    [Fact]
    public void Application_Should_NotReferenceOtherProjectAssemblies()
    {
        // Arrange
        
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var otherAssemblies = new[]
        {
            typeof(Infrastructure.Persistence.AssemblyReference).Namespace,
            typeof(Infrastructure.Shared.AssemblyReference).Namespace
        };
        
        // Act

        var assemblySut = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherAssemblies)
            .GetResult();

        // Assert

        assemblySut.IsSuccessful.Should().BeTrue();

    }
    
    [Fact]
    public void API_Should_NotReferenceOtherProjectAssemblies()
    {
        // Arrange
        
        var assembly = typeof(API.AssemblyReference).Assembly;

        var otherAssemblies = new[]
        {
            typeof(Domain.AssemblyReference).Namespace
        };
        
        // Act

        var assemblySut = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherAssemblies)
            .GetResult();

        // Assert

        assemblySut.IsSuccessful.Should().BeTrue();

    }
    
}