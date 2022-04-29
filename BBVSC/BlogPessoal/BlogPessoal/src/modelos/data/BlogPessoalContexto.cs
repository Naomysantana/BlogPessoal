using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;


namespace BlogPessoal.src.Data
{
    public class BlogPessoalContexto: DbContext
    {
        public DbSet<UsuarioModelo> Usuarios {get;set;}
        public DbSet<TemaModelo> Temas {get;set;}
        public DbSet<PostagemModel> Postagens {get;set;}

        public BlogPessoalContexto(DbContextOptions<BlogPessoalContexto> opt) : base(opt)
        {
            
        }
    }
}