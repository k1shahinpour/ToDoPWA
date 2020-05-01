using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToDoPWA.Data;
using ToDoPWA.Models;

namespace ToDoPWA.Controllers
{

    public class ToDoController : Controller
    {
        private readonly ToDoPWAContext _context;
        public ToDoController(ToDoPWAContext context)
        {
            _context = context;
        }

        // GET: api/ToDo
        [Route("todo")]
        [HttpGet]
        public async Task<IActionResult> GetToDo()
        {
            var model = await _context.ToDo.ToListAsync();
            return new JsonResult(model);
        }

        // GET: api/ToDo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetToDo(int id)
        {
            var toDo = await _context.ToDo.FindAsync(id);

            if (toDo == null)
            {
                return NotFound();
            }

            return toDo;
        }

        [Route("todo")]
        [HttpPut]
        public async Task<IActionResult> PutToDo(ToDo model)
        {
            var toDo = await _context.ToDo.FindAsync(model.Id);
            if (toDo == null)
            {
                return NotFound(); 
            }

            toDo.Title = model.Title;
            toDo.Note = model.Note;
            toDo.Complete = model.Complete;
            toDo.DueDate = model.DueDate;
           // toDo.Id = model.Id;


            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [Route("todo")]
        [HttpPost]
        public async Task<ActionResult<ToDo>> PostToDo(ToDo model)
        {
            _context.ToDo.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [Route("todo")]
        [HttpDelete]
        public async Task<ActionResult<ToDo>> DeleteToDo(ToDo model)
        {
            var toDo = await _context.ToDo.FindAsync(model.Id);
            if (toDo == null)
            {
                return NotFound();
            }

            _context.ToDo.Remove(toDo);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDo.Any(e => e.Id == id);
        }
    }
}
