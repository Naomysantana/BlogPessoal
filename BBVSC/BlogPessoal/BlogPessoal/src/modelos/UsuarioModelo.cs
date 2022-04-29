using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlogPessoal.src.modelos
{
    [Table("tb_Uuarios")]
    
    public class UsuarioModelo
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        [StringLength(50)]

        public string Nome { get; set; }
        [Required]
        [StringLength(30)]

        public string Email { get; set; }
        [Required]
        [StringLength(30)]

        public string Senha { get;set;}
         [Required]
        [StringLength(30)]

        [JsonIgnore]
        public List<PostagemModel> MinhasPostagens{get;set;}
    }
}