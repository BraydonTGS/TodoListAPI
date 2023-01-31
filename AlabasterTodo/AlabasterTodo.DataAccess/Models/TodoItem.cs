using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace AlabasterTodo.DataAccess.Models
{
    [DataContract]
    public class TodoItem
    { 
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        public DateTime? DateCompleted { get; set; }

        [DataMember]
        public string Description { get; set; } = string.Empty;

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsCompleted { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
