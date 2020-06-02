using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drugi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Drugi.Pages
{
    public class UnosRecepataModel : PageModel
    {
        [BindProperty]
        public Recept Recept { get; set; }

        public String[] tipovi = {"toplo predjelo, hladno predjelo, glavno jelo, dezert, specijlitet"};

        private readonly DataContext _context;

        public UnosRecepataModel(DataContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _context.AddAsync(Recept);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
