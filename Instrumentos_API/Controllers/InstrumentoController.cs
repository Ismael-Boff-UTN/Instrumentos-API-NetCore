using Instrumentos_API.DAO;
using Instrumentos_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instrumentos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentoController : Controller
    {
        private InterfaceInstrumentos db = new InstrumentosDAO();

        [HttpGet]
        public async Task <IActionResult> GetAllInstrumentos()
        {
            return Ok(await db.GetAllInstrumentos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstrumentoById(string id)
        {
            return Ok(await db.GetInstrumentoById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostInstrumento([FromBody] Instrumento instrumento)
        {
            if (instrumento == null)
            {
                return BadRequest();
            }else if (instrumento.instrumento == string.Empty)
            {
               ModelState.AddModelError("instrumento", "El Nombre No Puede Estar Vacio");
            }

            await db.InsertInstrumento(instrumento);

            return Created("Instrumento Creado", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstrumento([FromBody] Instrumento instrumento, string id)
        {
            if (instrumento == null)
            {
                return BadRequest();
            }
            else if (instrumento.instrumento == string.Empty)
            {
                ModelState.AddModelError("instrumento", "El Nombre No Puede Estar Vacio");
            }

            instrumento.id = new MongoDB.Bson.ObjectId(id);
            await db.UpdatePoduct(instrumento);

            return Created("Instrumento Actualizado", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstrumento(string id)
        {
            await db.DeleteInstrumento(id);

            return NoContent(); //Success
        }
    }
}
