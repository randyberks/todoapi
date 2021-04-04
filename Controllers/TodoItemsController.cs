using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {

        private readonly IRepository<TodoItem> _todoItemRepository;

        public TodoItemsController(IRepository<TodoItem> todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        // GET: api/TodoItems
        [HttpGet]
        public ActionResult<IEnumerable<TodoItemDTO>> GetTodoItems()
        {
            IEnumerable<TodoItem> todoItems = _todoItemRepository.FindAll();

            List<TodoItemDTO> todoItemDTO = new List<TodoItemDTO>();
            
            foreach (var item in todoItems)
            {
                todoItemDTO.Add(ItemToDto(item));
            }

            return todoItemDTO;

        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public ActionResult<TodoItemDTO> GetTodoItem(long id)
        {
            var todoItem = _todoItemRepository.FindById(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return ItemToDto(todoItem);
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<TodoItem> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.ID)
            {
                return BadRequest();
            }

            _todoItemRepository.Update(id, todoItem);
            
            return _todoItemRepository.FindById(id);
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<TodoItemDTO> PostTodoItem(TodoItem todoItem)
        {

            _todoItemRepository.Create(todoItem);

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.ID }, todoItem);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(long id)
        {
            _todoItemRepository.DeleteById(id);

            return Accepted();
        }

        private bool TodoItemExists(long id)
        {
            return _todoItemRepository.ExistsById(id);
        }

        private static TodoItemDTO ItemToDto(TodoItem item) =>
            new TodoItemDTO
            {
                ID = item.ID,
                Name = item.Name,
                Owner = item.Owner,
                IsComplete = item.IsComplete
            };

    }
}
