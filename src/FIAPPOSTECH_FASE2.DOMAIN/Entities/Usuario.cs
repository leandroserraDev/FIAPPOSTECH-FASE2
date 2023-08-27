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



        public Usuario(int id, string nome, string sobrenome, string email)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
        }

        protected Usuario()
        {
            
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

    }
}
