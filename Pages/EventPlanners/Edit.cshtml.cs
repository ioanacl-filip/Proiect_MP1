using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_MP1.Data;
using Proiect_MP1.Models;

namespace Proiect_MP1.Pages.EventPlanners
{
    public class EditModel : PageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public EditModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public EventPlanner EventPlanner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventplanner =  await _context.EventPlanner.FirstOrDefaultAsync(m => m.ID == id);
            if (eventplanner == null)
            {
                return NotFound();
            }
            EventPlanner = eventplanner;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EventPlanner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventPlannerExists(EventPlanner.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EventPlannerExists(int id)
        {
            return _context.EventPlanner.Any(e => e.ID == id);
        }
    }
}
