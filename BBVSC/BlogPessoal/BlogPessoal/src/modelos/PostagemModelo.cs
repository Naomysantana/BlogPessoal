using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.modelos
{
    [Table("tb_postagens")]
    public class PostagemModelo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Descricao { get; set; }
        
        public string Foto { get; set; }

        [ForeignKey("fk_Usuario")]
        public UsuarioModelo Criador { get; set; }

        [ForeignKey("fk_Tema")]
        public TemaModelo Tema { get; set; }
    }
}