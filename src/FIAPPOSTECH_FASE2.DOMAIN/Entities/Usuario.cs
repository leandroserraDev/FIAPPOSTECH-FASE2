using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
