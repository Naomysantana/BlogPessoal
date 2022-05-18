using System.Threading.Tasks;
using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
namespace BlogPessoal.src.servicos
{
    public interface IAutenticacao
    {
        string CodificarSenha(string senha);
        void CriarUsuarioSemDuplicarAsync(NovoUsuarioDTO usuario);
        string GerarToken(UsuarioModelo usuario);
        Task<AutorizacaoDTO> PegarAutorizacaoAsync(AutenticarDTO autenticacao);
    }
}