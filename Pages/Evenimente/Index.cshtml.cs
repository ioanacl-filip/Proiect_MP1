using System;
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
    public class IndexModel : PageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public IndexModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

        public IList<Eveniment> Eveniment { get;set; } = default!;

        public EventData EventD { get; set; }
        public int EventID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            EventD = new EventData();

            //se va include Author conform cu sarcina de la lab 2
            EventD.Evenimente = await _context.Eveniment
            .Include(b => b.EventPlanner)
            .Include(b => b.EventCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                EventID = id.Value;
                Eveniment eveniment = EventD.Evenimente
                .Where(i => i.ID == id.Value).Single();
                EventD.Categories = eveniment.EventCategories.Select(s => s.Category);
            }
        }
    }
}
