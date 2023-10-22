using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coste_Ionut_Lab2.Data;
using Coste_Ionut_Lab2.Models;

namespace Coste_Ionut_Lab2.Models.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Coste_Ionut_Lab2.Data.Coste_Ionut_Lab2Context _context;

        public IndexModel(Coste_Ionut_Lab2.Data.Coste_Ionut_Lab2Context context)
        {
            _context = context;
        }

        public IList<Authors> Authors { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Authors != null)
            {
                Authors = (IList<Authors>)await _context.Authors.ToListAsync();
            }
        }
    }
}
