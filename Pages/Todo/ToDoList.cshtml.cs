using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoPWA.Data;
using ToDoPWA.Models;

namespace ToDoPWA.Pages.Todo
{
    public class ToDoListModel : PageModel
    {
        private readonly ToDoPWA.Data.ToDoPWAContext _context;

        public ToDoListModel(ToDoPWA.Data.ToDoPWAContext context)
        {
            _context = context;
        }

        public IList<ToDo> ToDo { get;set; }

        public async Task OnGetAsync()
        {
            ToDo = await _context.ToDo.ToListAsync();
        }
        public async Task<IActionResult> OnGetItemsAsync()
        {
            var model = await _context.ToDo.ToListAsync();

            return new JsonResult(model);
        }

        public async Task<IActionResult> OnPostItemsAsync(ToDo model)
        {
            await _context.ToDo.AddAsync(model);
            await _context.SaveChangesAsync();
            return new OkObjectResult(model);
        }
    }
}
