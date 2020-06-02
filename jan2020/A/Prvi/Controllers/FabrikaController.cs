using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Prvi.Data;
using Prvi.Models;

namespace Prvi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FabrikaController : ControllerBase
    {
        private DataContext _context;

        public FabrikaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<JsonResult> GetAll()
        {
            var result = await _context.Fabrike.Include(x => x.Silosi).ToListAsync();
            return new JsonResult(result);
        }

        [HttpPut("napunisilos/{id}/{kolicina}")]
        public async Task<IActionResult> NapuniSilos(int id, int kolicina)
        {
            if (kolicina < 0){ return BadRequest(); }

            var silos = await _context.Silosi.Where(x => x.Id == id).FirstOrDefaultAsync();
            silos.Kolicina += kolicina;
            if (silos.Kolicina > silos.Kapacitet) { silos.Kolicina = silos.Kapacitet; }
            _context.Update(silos);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("dodaj")]
        public async Task<IActionResult> Dodaj(Fabrika fabrika)
        {
            if (fabrika == null) {return BadRequest();}

            await _context.Fabrike.AddAsync(fabrika);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}