using BlogPessoal.src.dtos;
using BlogPessoal.src.repositorios;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.src.controladores
{
    [ApiController]
    [Route("api/Users")]
    [Produces("application/json")]
    public class UsuarioControlador : ControllerBase
    {
        #region Atributos

        private readonly IUsuario _repositorio;

        #endregion

        #region Construtores

        public UsuarioControlador(IUsuario repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        [HttpGet("id/{idUsers}")]

        public IActionResult GetUserbyId([FromRoute] int idUser)
        {
            var user = _repositorio.PegarUsuarioPeloId(idUser);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet]

        public IActionResult GetUserByName([FromQuery] string Usuarionome)
        {
            var usuario = _repositorio.PegarUsuarioPeloNome(Usuarionome);
            
            if (usuario.Count < 1) return NoContent();

            return Ok(usuario);
        }

        [HttpGet("email/{emailuser}")]
        public IActionResult PegarUsuarioPeloEmail([FromRoute] string userEmail)
        {
            var user = _repositorio.PegarUsuarioPeloEmail(userEmail);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult NovoUsuario([FromBody] NovoUsuarioDTO user)
        {
            if(!ModelState.IsValid) return BadRequest();
            try
            {
            _servicos.CriarUsuarioSemDuplicar(usuario);
            return Created($"api/Usuarios/email/{usuario.Email}", usuario);
            }
            catch (Exception ex)
            {
            return Unauthorized(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] AtualizarUsuarioDTO user)
        {
            if (!ModelState.IsValid) return BadRequest();

            _repositorio.AtualizarUsuario(user);
            return Ok();

        }

        [HttpDelete("delete/{idUser}")]
        public IActionResult DeleteUser([FromRoute] int idUser)
        {
            _repositorio.DeletarUsuario(idUser);
            return NoContent();
        }
    }
}