using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;


namespace BlogPessoal.src.modelos
{
   
        [Table("tb_Temas")]
     public class TemaModelo
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        [StringLength(50)]

        public string Descricao { get; set; }
        [Required]
        [StringLength(30)]

         [JsonIgnore]
        public List<PostagemModel> MinhasPostagens{get;set;}
    }
}