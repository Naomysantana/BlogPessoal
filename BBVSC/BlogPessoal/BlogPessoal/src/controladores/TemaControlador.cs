using BlogPessoal.src.repositorios;
using Microsoft.AspNetCore.Mvc;
using BlogPessoal.src.dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BlogPessoal.src.controladores
{
    [ApiController]
    [Route("api/Temas")]
    [Produces("application/json")]
    public class TemaControlador : ControllerBase
    {
        #region Atributos

        private readonly ITema _repositorio;

        #endregion


        #region Construtores

        public TemaControlador(ITema repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion


        #region Metodos

        [HttpGet]
       [Authorize]
        public IActionResult PegarTodosTemas()
        {
            var lista = _repositorio.PegarTodosTemas();

            if (lista.Count < 1) return NoContent();
            
            return Ok(lista);
        }

        [HttpGet("id/{idTema}")]
        public async Task<ActionResult> PegarTemaPeloIdAsync([FromRoute] int idTema)
        {
            var tema = await _repositorio.PegarTemaPeloIdAsync(idTema);
            if (tema == null) return NotFound();
            return Ok(tema);
        }

        [HttpGet("search")]
        public async Task<ActionResult> PegarTemasPelaDescricaoAsync([FromQuery] string descricaoTema)
        {
            var temas = await _repositorio.PegarTemasPelaDescricaoAsync(descricaoTema);
            if (temas.Count < 1) return NoContent();
            return Ok(temas);
        }

        [HttpPost]
        public async Task<ActionResult> NovoTemaAsync([FromBody] NovoTemaDTO tema)
        {
            if(!ModelState.IsValid) return BadRequest();
            await _repositorio.NovoTemaAsync(tema);
            return Created($"api/Temas", tema);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarTema([FromBody] AtualizarTemaDTO tema)
        {
            if(!ModelState.IsValid) return BadRequest();
            await _repositorio.AtualizarTemaAsync(tema);
            return Ok(tema);

        }

        [HttpDelete("delete/{idTema}")]
        public async Task<ActionResult> DeletarTema([FromRoute] int idTema)
        {
            await _repositorio.DeletarTemaAsync(idTema);
            return NoContent();

        }

        #endregion
        
    }
}