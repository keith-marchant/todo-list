using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Application.Entities;

namespace TodoList.Infrastructure.Persistence
{
    public static class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            context.TodoItems.AddRange(
                new List<TodoItem>
                {
                    new TodoItem{ ItemId = 1, Title = "Pay bills", Description = "Sydney Water", DueDate = DateTime.Now.AddDays(5), Status = TodoItemStatus.Incomplete }
                });

            await context.SaveChangesAsync();
        }
    }
}
