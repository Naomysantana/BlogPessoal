using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.dtos
{
    /// <summary>
    /// <para>Resumo: Classe espelho para criar um novo tema tema</para>
    /// <para>Criado por: Naomy Santana</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class NovoTemaDTO
    {
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
        public NovoTemaDTO(string descricao) => Descricao = descricao;
    }
     /// <summary>
    /// <para>Resumo: Classe espelho para alterar um novo tema tema</para>
    /// <para>Criado por: Naomy Santana</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class AtualizarTemaDTO
    {
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
    }
}