using System;

namespace AspNetCoreTodo.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        public string Title { get; set; }
        public DateTimeOffset? DueAt { get; set; }

        // ? makes it required, means it always has a value
        
        // Plain Odd C# Obcect - we do not worry about low-level database
        // because this model defines what the database will look like
    }
}