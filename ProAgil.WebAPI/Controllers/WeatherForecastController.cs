using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public readonly ProAgilContext _context;
        public WeatherForecastController(ProAgilContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try 
            {
                var results = await _context.Eventos.ToListAsync();

                return Ok(results);
            } 
            catch(Exception) 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
             try 
            {
                var result = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);

                return Ok(result);
            } 
            catch(Exception) 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }
    }
}
