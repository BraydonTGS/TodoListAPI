using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AlabasterTodo.DataAccess.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateCompleted { get; set; }

        [Required, NotNull]
        public string Description { get; set; } = string.Empty;
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
