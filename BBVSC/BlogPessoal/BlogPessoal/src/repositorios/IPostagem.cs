using System.Collections.Generic;
using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;

namespace BlogPessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de postagem</para>
    /// <para>Criado por: Naomy Santana</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public interface IPostagem
    {
        void AtualizarPostagem(NovaPostagemDTO postagem);
        void AtualizarPostagem(AtualizarPostagemDTO postagem);
        void DeletarPostagem(int id);
        PostagemModelo PegarPostagemPeloId(int id);
        List<modelos.PostagemModelo> PegarTodasPostagens();
        List<PostagemModelo> PegarPostagensPorPesquisa(string titulo, string descricaoTema, string nomeCriador);


    }
}