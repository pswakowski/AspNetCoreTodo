using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        // this variable lets use the service from the Index action method
        private readonly ITodoItemService _todoItemService;

        // Constructor 
        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            //Get to-do items from database
            var todoItems = await _todoItemService.GetIncompleteItemsAsync();
            
            //Put items into model
            var model = new TodoViewModel()
            {
                Items = todoItems
            };

            // Render view using the model
            return View(model);            
        }

        public async Task<IActionResult> AddItem(NewTodoItem newItem)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var successful = await _todoItemService.AddItemAsync(newItem);
            if(!successful)
            {
                return BadRequest(new { error = "Could not add item"});
            }

            return Ok();
        }

        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var successful = await _todoItemService.MarkDoneAsync(id);

            if(!successful) return BadRequest();

            return Ok();
        }
    }
}