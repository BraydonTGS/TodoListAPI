using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AlabasterTodo.DataAccess.Models
{
    public class AlabasterTodoDbContext : DbContext
    {
        public AlabasterTodoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasOne<User>(u => u.User).WithMany(t => t.TodoItems).HasForeignKey(u => u.UserId);
        }

        private string GetConnectionString()
        {
            string c = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("\\AlabasterTodo\\AlabasterTodo.DataAccess\\appsettings.json").Build();
            string? connectionStringIs = configuration.GetConnectionString("AlabasterTodo");
            if (connectionStringIs != null)
            {
                return connectionStringIs;
            }
            throw new ArgumentNullException(nameof(connectionStringIs));
        }
    }
}

