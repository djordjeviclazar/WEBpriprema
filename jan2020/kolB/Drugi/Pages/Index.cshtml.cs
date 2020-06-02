using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drugi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Drugi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }
    }
}
