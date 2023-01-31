using Microsoft.EntityFrameworkCore;

namespace AlabasterTodo.DataAccess.Models
{
    public class AlabasterTodoDbContext : DbContext
    {
        public AlabasterTodoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasOne<User>(u => u.User).WithMany(t => t.TodoItems).HasForeignKey(u => u.UserId);
        }

    }
}

