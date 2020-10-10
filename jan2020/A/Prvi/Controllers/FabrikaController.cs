using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Prvi.Data;
using Prvi.Dtos;
using Prvi.Models;

namespace Prvi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FabrikaController : ControllerBase
    {
        private readonly DataContext _context;

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

        [HttpPut("napunisilos")]
        public async Task<IActionResult> NapuniSilos(EditSilosDto dto)
        {
            //if (dto.Kolicina < 0){ return BadRequest(); }

            var silos = await _context.Silosi.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();//klijent zna ID

            //Ako je situacija malo drugačija i treba ti da pretražiš po roditelju nešto, a nemaš referencu na roditelja
            /*
            Recimo da imamo ime silosa i ime fabrike u dto
            var fabrika = await _context.Fabrike.Where(x => x.Ime == dto.ImeFabrike).
                                                .Include(a => a.Silosi)
                                                .FirstOrDefaultAsync();
            var silos = await fabrika.Where(x => x.Ime == dto.ImeSilosa).FirstOrDefaultAsync();
            ...
            */

            silos.Kolicina += dto.Kolicina;
            if (silos.Kolicina > silos.Kapacitet) { return BadRequest("Kapacitet: " + silos.Kapacitet); }
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