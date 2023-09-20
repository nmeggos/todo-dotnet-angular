
namespace TodoTaskManagement.Infrastructure.Persistence.EntityConfigurations;

public class TodoItemEntityTypeConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("Todo","dbo")
            .HasKey("Id");
        
        builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => TodoItemId.From(value));
        
        builder.Property(p => p.Title)
            .HasColumnName("Title")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("Description")
            .HasMaxLength(500)
            .IsRequired(false);

        builder.HasOne(p => p.Category)
            .WithMany()
            .IsRequired(false)
            .HasForeignKey(fk => fk.CategoryId);

        builder.Property(p => p.IsCompleted)
            .HasColumnName("IsCompleted")
            .HasColumnType("bit")
            .HasDefaultValue(false)
            .IsRequired();
        
        builder.Property(p => p.CompletedOn)
            .HasColumnName("CompletedOn")
            .IsRequired(false);

        builder.Property(p => p.CreatedOn)
            .HasColumnName("CreatedOn")
            .IsRequired();

        builder.Property(p => p.UpdatedOn)
            .HasColumnName("UpdatedOn")
            .IsRequired(false);
    }
}