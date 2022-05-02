using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;

namespace BlogPessoal.src.rAepositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de usuario</para>
    /// <para>Criado por: Naomy Santana</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public interface IUsuario
    {
        void AddUser(NovoUsuarioDTO newUsuario);
        void AttUser(AtualizarUsuarioDTO newUsuario);
        void DeletarUsuario(int id);
        UsuarioModelo PegarUsuarioPeloId(int id);
        UsuarioModelo PegarUsuarioPeloEmail(string email);
        UsuarioModelo PegarUsuarioPeloNome(string nome);


    }
}