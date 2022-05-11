using BlogPessoal.src.repositorios;
using Microsoft.AspNetCore.Mvc;
using BlogPessoal.src.dtos;

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
        public IActionResult PegarTodosTemas()
        {
            var lista = _repositorio.PegarTodosTemas();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        [HttpGet("id/{idTema}")]
        public IActionResult GetThemeById([FromRoute] int idTema)
        {
            var theme = _repositorio.PegarTemaPeloId(idTema);

            if (theme == null) return NotFound();

            return Ok(theme);
        }

        [HttpGet("search")]
        public IActionResult PegarTemaPorDescricao([FromQuery] string DescricaoTema)
        {
            var themes = _repositorio.PegarTemaPelaDescricao(DescricaoTema);

            if (themes.Count < 1) return NoContent();

            return Ok(themes);

        }

        [HttpPost]
        public IActionResult NewTheme([FromBody] NovoTemaDTO Tema)
        {
            if (!ModelState.IsValid) return BadRequest();

            _repositorio.NovoTema(Tema);
            
            return Created($"api/Themes", Tema);

        }

        [HttpPut]
        public IActionResult UpdateTheme([FromBody] AtualizarTemaDTO uptheme)
        {
            if (!ModelState.IsValid) return BadRequest();

            _repositorio.AtualizarTema(uptheme);

            return Ok(uptheme);
        }

        [HttpDelete("delete/{idTheme}")]
        public IActionResult DeleteTheme([FromRoute] int delTheme)
        {
            _repositorio.DeletarTema(delTheme);
            return NoContent();
        }

        #endregion
        
    }
}