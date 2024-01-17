using ApiTarjeta;
using ApiTarjeta.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace ApiTarjeta.Controllers
{
    [Route("api/tarjetas")]
    [ApiController]
    public class TarjetasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public TarjetasController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]

        public async Task<ActionResult<List<Tarjeta>>> Get()
        {
            return await context.Tarjeta.ToListAsync();
        }
        [HttpGet("{numeroTarjeta}")]

        public async Task<ActionResult<List<Tarjeta>>> NumeroTarjeta(string NumeroTarjeta)
        {
            //string numString = Convert.ToString(NumeroTarjeta);
            //return numString;
            //var creditos = await context.Tarjeta.Where(x => x.NumeroTarjeta == NumeroTarjeta).ToListAsync();
            //var creditos = await context.Tarjeta.Include(x=>x.Usuarios).FirstOrDefaultAsync(x => x.NumeroTarjeta.Contains(NumeroTarjeta));
            var creditos = await context.Tarjeta.FirstOrDefaultAsync(x => x.NumeroTarjeta.Contains(NumeroTarjeta));
            if (creditos is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(creditos);
            }
            //return await context.Movimientos.AsQueryable("select * from").ToList();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> put(Tarjeta tarjeta, int id)
        {
            if(tarjeta.Id != id)
            {
                return BadRequest("Id de tarjeta no coincide con el de la URL");
            }
            context.Update(tarjeta.TasaInteres);
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
