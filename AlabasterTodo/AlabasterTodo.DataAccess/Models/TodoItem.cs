namespace AlabasterTodo.DataAccess.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateCompleted { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }

        public bool IsCompleted { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
