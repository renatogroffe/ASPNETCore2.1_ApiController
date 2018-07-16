using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIComentarios.Data;
using APIComentarios.Models;

namespace APIComentarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Comentario> Get(
            [FromServices]ApplicationDbContext context)
        {
            return context.Comentarios.ToArray();
        }

        [HttpPost]
        public IActionResult Post(
            Comentario comentario,
            [FromServices]ApplicationDbContext context)
        {
            comentario.Id = Guid.NewGuid();
            comentario.Data = DateTime.Now;
            context.Comentarios.Add(comentario);
            context.SaveChanges();

            return Ok();
        }
    }
}