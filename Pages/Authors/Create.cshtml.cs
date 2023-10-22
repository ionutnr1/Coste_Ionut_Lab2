using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Coste_Ionut_Lab2.Data;
using Coste_Ionut_Lab2.Models;

namespace Coste_Ionut_Lab2.Models.Authors
{
    public class CreateModel : PageModel
    {
        private readonly Coste_Ionut_Lab2.Data.Coste_Ionut_Lab2Context _context;

        public CreateModel(Coste_Ionut_Lab2.Data.Coste_Ionut_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Authors Authors { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Authors == null || Authors == null)
            {
                return Page();
            }

            _context.Authors.Add(Authors);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
