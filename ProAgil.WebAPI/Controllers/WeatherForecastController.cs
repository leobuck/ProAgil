using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public readonly DataContext _context;
        public WeatherForecastController(DataContext context)
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
                var result = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);

                return Ok(result);
            } 
            catch(Exception) 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }
    }
}
