using FIAPPOSTECH_FASE2.DOMAIN.Entities;

namespace FIAPPOSTECH_FASE2.Domain.Test
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void Criacao_Instancia_Usuario()
        {
            //Criar usuario
            var usuario = new Usuario("Leandro", "Serra", "leandro.serra@gmail.com", "12345678");

            //validação se usuario não é null
            Assert.AreNotEqual(null, usuario);

        }


        [TestMethod]
        public void Criacao_Instancia_Campos_Obrigatorios()
        {
            //Criar usuario
            var usuario = new Usuario("Leandro", "Serra", "leandro.serra@gmail.com", "12345678");

            //validação se usuario tem os campos obrigatórios
            Assert.AreNotEqual(null, usuario);
            Assert.AreNotEqual(null, usuario.Nome);
            Assert.AreNotEqual(null, usuario.Sobrenome);
            Assert.AreNotEqual(null, usuario.Password);
        }

        [TestMethod]
        public void Criacao_Troca_Senha_Usuario()
        {
            //Criar usuario
            var usuario = new Usuario("Leandro", "Serra", "leandro.serra@gmail.com", "12345678");

            usuario.TrocarSenha("1234567");

            //validação troca de senha
            Assert.AreNotEqual(null, usuario);
            Assert.AreNotEqual("12345678", usuario.Password);
            Assert.AreEqual("1234567", usuario.Password);

        }

        [TestMethod]
        public void Criacao_Criacao_Hash()
        {
            //Criar usuario
            var usuario = new Usuario("Leandro", "Serra", "leandro.serra@gmail.com", "12345678");

            byte[] saltHas = { 1, 2, 3, };
            usuario.AdicionarHashSalt(saltHas);

            //validação troca de senha
            Assert.AreNotEqual(null, usuario);
            Assert.AreNotEqual(null, usuario.SaltHash);

        }
    }
}