using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBullyng2.Models.DB;

namespace ApiBullyng2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MensajesController : ControllerBase
    {
        private readonly AppbullyingContext _context;

        public MensajesController(AppbullyingContext context)
        {
            _context = context;
        }

        // GET: api/Mensajes
        [HttpGet]
        [Route("ListarMensajes")]
        public async Task<IActionResult> listarMensajes()
        {

            List<Mensaje> mensajes = await _context.Mensajes.ToListAsync();


            return Ok(mensajes);

        }

        // GET: api/Mensajes/5
        [HttpGet]
        [Route("BuscarMensaje")]
        public async Task<IActionResult> ObtenerMensaje(int id)
        {
            var mensaje = await _context.Mensajes.FindAsync(id);

            if (mensaje == null)
            {
                return NotFound();
            }

            return Ok(mensaje);
        }


        // POST: api/Mensajes
        [HttpPost]
        [Route("RegistrarMensaje")]
        public async Task<IActionResult> guardarMensaje([FromQuery] string Texto, [FromQuery] string Foto,
            [FromQuery] string Video, [FromQuery] decimal Latitud, [FromQuery] decimal Longitud)
        {
            var mensaje = new Mensaje();

            mensaje.Texto = Texto;
            mensaje.Foto = Foto;
            mensaje.Video = Video;
            mensaje.Latitud = Latitud;
            mensaje.Longitud = Longitud;

            _context.Mensajes.Add(mensaje);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Mensaje registrado",
                result = mensaje
            });
        }

        // DELETE: api/Mensajes/5
        [HttpDelete]
        [Route("EliminarMensaje")]
        public async Task<IActionResult> BorrarMensaje(int id)
        {
            var mensaje = await _context.Mensajes.FindAsync(id);

            if (mensaje == null)
            {
                return NotFound();
            }

            _context.Mensajes.Remove(mensaje);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                success = true,
                message = "Mensaje actualizado",
                result = mensaje
            });
        }

    private bool MensajeExists(int id)
        {
            return (_context.Mensajes?.Any(e => e.IdMensaje == id)).GetValueOrDefault();
        }
    }
}
