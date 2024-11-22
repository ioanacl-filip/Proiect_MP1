﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_MP1.Data;
using Proiect_MP1.Models;

namespace Proiect_MP1.Pages.Evenimente
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public CreateModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Eveniment Eveniment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Eveniment.Add(Eveniment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
