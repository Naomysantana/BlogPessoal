using System.Threading.Tasks;
using BlogPessoal.src.dtos;
using BlogPessoal.src.repositorios;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.src.controladores
{
    [ApiController]
    [Route("api/Posts")]
    [Produces("application/json")]
    public class PostagemControlador  : ControllerBase
    {
        #region Atributos

        private readonly IPostagem _repositorio;

        #endregion

        #region Construtores

        public PostagemControlador(IPostagem repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion
        
        #region Metodos
        [HttpGet("id/{idPost}")]
        public async Task<ActionResult> PegarPostagemPeloIdAsync([FromRoute] int idPostagem)
        {
            var postagem = await _repositorio.PegarPostagemPeloIdAsync(idPostagem);
            if (postagem == null) return NotFound();
            return Ok(postagem);
        }

        [HttpGet]
         public IActionResult PegarTodasPostagens()
        {
            var lista = _repositorio.PegarTodasPostagens ();

            if (lista.Count < 1) return NoContent();
            
            return Ok(lista);
        }

        [HttpGet("pesquisa")]
        public async Task<ActionResult> PegarPostagensPorPesquisaAsync(
        [FromQuery] string titulo,
        [FromQuery] string descricaoTema,
        [FromQuery] string nomeCriador)
        {
            var postagens = await _repositorio.PegarPostagensPorPesquisaAsync(titulo,
            descricaoTema, nomeCriador);
            if (postagens.Count < 1) return NoContent();
            return Ok(postagens);

        }

        [HttpPost]
        public async Task<ActionResult> NovaPostagemAsync([FromBody] NovaPostagemDTO postagem)
        {
            if(!ModelState.IsValid) return BadRequest();
            await _repositorio.NovaPostagemAsync(postagem);
            return Created($"api/Postagens", postagem);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarPostagemAsync([FromBody]AtualizarPostagemDTO postagem)
        {
            if(!ModelState.IsValid) return BadRequest();
            await _repositorio.AtualizarPostagemAsync(postagem);
            return Ok(postagem);
        }

        [HttpDelete("delete/{idPostagem}")]
        public async Task<ActionResult> DeletarPostagem([FromRoute] int idPostagem)
        {
            await _repositorio.DeletarPostagemAsync(idPostagem);
            return NoContent();

        }
    }
    #endregion
}