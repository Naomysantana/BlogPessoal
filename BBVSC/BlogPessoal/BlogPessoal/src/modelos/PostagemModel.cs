using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BlogPessoal.src.modelos
{
            [Table("tb_Postagem")]
     public class PostagemModel
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
        [Required]
        [StringLength(100)]

        [ForeignKey("fk_Usuario")]
        public List<UsuarioModelo> Criador {get; set; }

        [ForeignKey("fk_Tema")]
        public List<TemaModelo> Tema {get; set; }
    }
}