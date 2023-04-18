using Microsoft.AspNetCore.Mvc;
using WsApiexamen.Dto;
using WsApiexamen.Models;
using WsApiexamen.Servicios;

namespace WsApiexamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : ControllerBase 
    {
        private readonly IExamenServicio _examenServicio;
        public ExamenController(IExamenServicio examenServicio)
        {
            _examenServicio = examenServicio;
        }
        [HttpPost]
        

        public async Task<IActionResult> CrearExamen([FromBody] Examen examen)
        {
            await _examenServicio.AddExamen(examen);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetExamen(int id)
        {
            var examen = await _examenServicio.GetExamenById(id);

            if (examen == null)
            {
                return NotFound();

            }

            return Ok(examen);
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteExamen(int id)
        {
            var examen = await _examenServicio.GetExamenById(id);

            if (examen == null)
            {
                return NotFound();

            }
            await _examenServicio.DeleteById(examen);
            return Ok();
        }

        [HttpGet]
        [Route("all")]

        public async Task<IActionResult> GetAll([FromQuery] string? nombre, [FromQuery] string? descripcion)
        {
            var examen = await _examenServicio.GetAll(nombre, descripcion);

            return Ok(examen);
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> UpdateExamen(int id, [FromBody] ExamenPutDto examenPutDto)
        {
            var resultado = await _examenServicio.Update(id, examenPutDto);

            if (resultado is false)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
