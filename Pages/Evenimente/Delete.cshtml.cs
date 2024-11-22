﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MP1.Data;
using Proiect_MP1.Models;

namespace Proiect_MP1.Pages.Evenimente
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public DeleteModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Eveniment Eveniment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eveniment = await _context.Eveniment.FirstOrDefaultAsync(m => m.ID == id);

            if (eveniment == null)
            {
                return NotFound();
            }
            else
            {
                Eveniment = eveniment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eveniment = await _context.Eveniment.FindAsync(id);
            if (eveniment != null)
            {
                Eveniment = eveniment;
                _context.Eveniment.Remove(Eveniment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
