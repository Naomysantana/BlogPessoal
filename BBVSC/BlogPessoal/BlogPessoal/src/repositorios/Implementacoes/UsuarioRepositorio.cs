using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPessoal.src.Data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;

namespace BlogPessoal.src.repositorios.Implementacoes
{
    public class UsuarioRepositorio : IUsuario
    {
        #region Atributos

        private readonly BlogPessoalContexto _contexto;

        #endregion Atributos

        #region Construtores

        public UsuarioRepositorio(BlogPessoalContexto contexto)
        {
            _contexto = contexto;
        }

        #endregion Construtores

        #region  Métodos

        public void NovoUsuario(NovoUsuarioDTO Usuario)
        {
            _contexto.Usuarios.Add(new UsuarioModelo
            {
                Email = Usuario.Email,
                Nome = Usuario.Nome,
                Senha = Usuario.Senha,
                Foto = Usuario.Foto,
                Tipo = Usuario.Tipo
            });
        _contexto.SaveChanges();

        }

        public void AtualizarUsuario(AtualizarUsuarioDTO Usuario)
        {
            var usuarioExistente = PegarUsuarioPeloId(Usuario.Id);
            usuarioExistente.Nome = Usuario.Nome;
            usuarioExistente.Senha = Usuario.Senha;
            usuarioExistente.Foto = Usuario.Foto;
            _contexto.Usuarios.Update(usuarioExistente);
            _contexto.SaveChanges();
        }

         public async Task<UsuarioModelo> PegarUsuarioPeloIdAsync(int id)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task<UsuarioModelo> PegarUsuarioPeloEmailAsync(string email)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public UsuarioModelo PegarUsuarioPeloId(int id)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public async Task<List<UsuarioModelo>> PegarUsuariosPeloNomeAsync(string nome)
        {
            return await _contexto.Usuarios
            .Where(u => u.Nome.Contains(nome))
            .ToListAsync();
        }

        public async Task NovoUsuarioAsync(NovoUsuarioDTO usuario)
        {
            await _contexto.Usuarios.AddAsync(new UsuarioModelo
            {
                Email = usuario.Email,
                Nome = usuario.Nome,
                Senha = usuario.Senha,
                Foto = usuario.Foto,
                Tipo = usuario.Tipo
            });
            await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarUsuarioAsync(AtualizarUsuarioDTO usuario)
        {
            var usuarioExistente = await PegarUsuarioPeloIdAsync(usuario.Id);
            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Senha = usuario.Senha;
            usuarioExistente.Foto = usuario.Foto;
            _contexto.Usuarios.Update(usuarioExistente);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarUsuarioAsync(int id)
        {
            _contexto.Usuarios.Remove(await PegarUsuarioPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }
        #endregion

    }
}