using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using BlogPessoal.src.Data;
using BlogPessoal.src.modelos;
using System.Linq;

namespace BlogPessoalTeste.Testes.Data
{
    [TestClass]
    public class BlogPessoalContextoTeste
    {
        private BlogPessoalContexto _contexto;

        [TestInitialize]
        public void Inicio()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "db_BlogPessoal")
            .Options;

            _contexto = new BlogPessoalContexto(opt);
        }
        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetornaUsuario()
        {
            UsuarioModelo Usuario = new UsuarioModelo();

            Usuario.Nome = "Naomy Santana";
            Usuario.Email = "naomy@email.com";
            Usuario.Senha = "55017841";

            _contexto.Usuarios.Add(Usuario);

            _contexto.SaveChanges();

            Assert.IsNotNull(_contexto.Usuarios.FirstOrDefault(u => u.Email == "naomy@email.com"));
        }
    }
}
