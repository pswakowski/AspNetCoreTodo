using System.Collections.Generic;

namespace AspNetCoreTodo.Models
{
    public class TodoViewModel
    {
        public IEnumerable<TodoItem> Items { get; set; }

        // this model represents a single item in the database,
        // but view might need to display two, ten or more todo items
    }
}