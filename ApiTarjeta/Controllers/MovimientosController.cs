
using ApiTarjeta;
using ApiTarjeta.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiEstadoDeCuenta.Controllers
{
    [Route("api/movimientos")]
    [ApiController]
    //[Authorize]
    public class MovimientosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public MovimientosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]

        public async Task<ActionResult<List<Movimiento>>> Get()
        {
            return await context.Movimientos.Where(x => x.Fecha.Month == DateTime.Now.Month).ToListAsync();
        }
        [HttpGet("tarjeta/{IdTarjeta:int}")]

        public async Task<ActionResult<List<Movimiento>>> Tarjeta(int IdTarjeta)
        {
            return await context.Movimientos.Where(x => x.IdTarjeta == IdTarjeta).Where(x => x.Fecha.Month == DateTime.Now.Month).ToListAsync();
            //return await context.Movimientos.AsQueryable("select * from").ToList();
        }
        [HttpGet("tarjetapagos/{IdTarjeta:int}")]

        public async Task<ActionResult<List<Movimiento>>> TarjetaPagos(int IdTarjeta)
        {
            return await context.Movimientos.Where(x => x.IdTarjeta == IdTarjeta).Where(x => x.Fecha.Month == DateTime.Now.Month).Where(x => x.IdTipoTransaccion == 1).Where(x => x.Fecha.Year == DateTime.Now.Year).ToListAsync();
            //return await context.Movimientos.AsQueryable("select * from").ToList();
        }
        [HttpGet("tarjetacompas/{IdTarjeta:int}")]

        public async Task<ActionResult<List<Movimiento>>> TarjetaCompas(int IdTarjeta)
        {
            return await context.Movimientos.Where(x => x.IdTarjeta == IdTarjeta).Where(x => x.Fecha.Month == DateTime.Now.Month).Where(x => x.IdTipoTransaccion == 2).Where(x => x.Fecha.Year == DateTime.Now.Year).ToListAsync();
            //return await context.Movimientos.AsQueryable("select * from").ToList();
        }

        [HttpGet("{idtransaccion:int}")]

        public async Task<ActionResult<List<Movimiento>>> Tipo(int idtransaccion)
        {
            return await context.Movimientos.Where(x=>x.IdTipoTransaccion==idtransaccion).Where(x => x.Fecha.Month == DateTime.Now.Month).Where(x => x.Fecha.Year == DateTime.Now.Year).ToListAsync();
            //return await context.Movimientos.AsQueryable("select * from").ToList();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Movimiento movimiento)
        {
            context.Add(movimiento);
            await context.SaveChangesAsync();
            return Ok("OK");
        }
    }
}