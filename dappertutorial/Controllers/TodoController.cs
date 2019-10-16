using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dappertutorial.DAL;
using dappertutorial.DAL.Models;
using dappertutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace dappertutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoDataStore _todoDataStore;

        public TodoController(ITodoDataStore todoDataStore)
        {
            _todoDataStore = todoDataStore;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDAL>>> Get()
        {
            var result = await _todoDataStore.SelectAllTodoItems();

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDAL>> Get(int id)
        {
            var result = await _todoDataStore.SelectTodoItem(id);

            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _todoDataStore.InsertTodoItem(todoItem);

            return result;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _todoDataStore.UpdateTodoItem(todoItem, id);

            return Ok(result);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await _todoDataStore.DeleteTodoItem(id);

            return Ok(result);
        }
    }
}
