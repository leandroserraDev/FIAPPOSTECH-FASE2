using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.DOMAIN.Entities
{
    public class Usuario
    {
        public Usuario(string nome, string sobrenome, string email, string password)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Password = password;
        }



        public Usuario(int id, string nome, string sobrenome, string email, string password, byte[] salt)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            SaltHash = salt;
            Password = password;
        }


        protected Usuario()
        {
            
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public byte[] SaltHash { get; private set; }
        public virtual IEnumerable<Noticia> Noticias { get; private set; }

        public void TrocarSenha(string password)
        {
            Password = password;
        }

        public void AdicionarHashSalt(byte[] salt)
        {
             SaltHash = salt;
        }


        public void GerarSenha()
        {
            var rngCsp = RandomNumberGenerator.Create();

            byte[] salt = new byte[16];
            rngCsp.GetBytes(salt);

            var senha = Password;

            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 1000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string hashSenha = Convert.ToBase64String(hashBytes);

            TrocarSenha(hashSenha);
            AdicionarHashSalt(salt);


        }

    }
}
