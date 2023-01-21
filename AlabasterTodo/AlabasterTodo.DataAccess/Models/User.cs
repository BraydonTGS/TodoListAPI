using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AlabasterTodo.DataAccess.Models
{
    public class User
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, NotNull]
        public string FirstName { get; set; } = string.Empty;

        [Required, NotNull]
        public string LastName { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }

        [Required, NotNull]
        public string Email { get; set; } = string.Empty;

        [Required, NotNull]
        public string Password { get; set; } = string.Empty;

        public IEnumerable<TodoItem>? TodoItems { get; set; }
    }
}
