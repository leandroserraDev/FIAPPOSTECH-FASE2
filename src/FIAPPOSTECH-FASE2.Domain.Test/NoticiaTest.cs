using FIAPPOSTECH_FASE2.DOMAIN.Entities;


namespace FIAPPOSTECH_FASE2.Domain.Test
{
    [TestClass]
    public class NoticiaTest
    {
       
        [TestMethod]
        public void Criacao_Noticia_Com_Usuario()
        {
            var noticia = new Noticia(1, "Noticia teste", "Teste de unidade da notícia", new("Leandro", "Serra", "administrador@gmail.com", "12345678"), DateTime.Now);


            //validação dos campos da noticia
            Assert.AreNotEqual(null, noticia);
            Assert.AreNotEqual(null, noticia.Id);
            Assert.AreNotEqual(null, noticia.Conteudo);
            Assert.AreNotEqual(null, noticia.Titulo);
            Assert.AreNotEqual(null, noticia.Autor);
            Assert.AreNotEqual(null, noticia.DataPublicacao);

        }
    }
}
