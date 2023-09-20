
namespace TodoTaskManagement.Infrastructure.Persistence.EntityConfigurations;

public class TodoCategoryEntityTypeConfiguration : IEntityTypeConfiguration<TodoCategory>
{
    public void Configure(EntityTypeBuilder<TodoCategory> builder)
    {
        builder.ToTable("TodoCategory", "dbo")
            .HasKey(pk => pk.Id);
        
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(
                id => id.Value,
                value => TodoCategoryId.From(value))
            .IsRequired();
        
        builder.Property(p => p.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}