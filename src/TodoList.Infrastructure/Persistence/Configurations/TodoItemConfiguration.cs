using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Application.Entities;

namespace TodoList.Infrastructure.Persistence.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(p => p.ItemId);

            builder.Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Status)
                .HasConversion<int>();
        }
    }
}
