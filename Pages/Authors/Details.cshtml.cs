using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coste_Ionut_Lab2.Data;
using Coste_Ionut_Lab2.Models;

namespace Coste_Ionut_Lab2.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Coste_Ionut_Lab2.Data.Coste_Ionut_Lab2Context _context;

        public DetailsModel(Coste_Ionut_Lab2.Data.Coste_Ionut_Lab2Context context)
        {
            _context = context;
        }

      public Pages_Authors_Details Authors { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.FirstOrDefaultAsync(m => m.ID == id);
            if (authors == null)
            {
                return NotFound();
            }
            else 
            {
                Authors = authors;
            }
            return Page();
        }
    }
}
