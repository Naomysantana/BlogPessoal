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
        public IActionResult GetPostsById([FromRoute] int postagemId)
        {
            var post = _repositorio.PegarPostagemPeloId(postagemId);

            if (post == null) return NotFound();

            return Ok(post);
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var list = _repositorio.PegarTodasPostagens();

            if (list.Count < 1) return NoContent();

            return Ok(list);
        }

        [HttpGet("search")]
        public IActionResult GetPostsBySearch([FromQuery] string title, [FromQuery] string descriptionTheme, [FromQuery] string creatorName)
        {
            var posts = _repositorio.PegarPostagensPorPesquisa (title, descriptionTheme, creatorName);
            
            if(posts.Count < 1) return NoContent();

            return Ok(posts);
        }

        [HttpPost]
        public IActionResult NewPost([FromBody] NovaPostagemDTO postagem)
        {
            if (!ModelState.IsValid) return BadRequest();

            
            return Created($"api/Posts", postagem);
        }

        [HttpPut]
        public IActionResult UpdatePost([FromBody] AtualizarPostagemDTO upPost)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            _repositorio.AtualizarPostagem(upPost);
            return Ok(upPost);
        }

        [HttpDelete("delete/{idPost}")]
        public IActionResult DeletePost([FromRoute] int idPost)
        {
            _repositorio.DeletarPostagem(idPost);
            return NoContent();        
        }
    }
    #endregion
}