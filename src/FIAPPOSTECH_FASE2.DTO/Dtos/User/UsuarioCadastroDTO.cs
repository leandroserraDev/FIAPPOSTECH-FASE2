using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.DTO.Dtos.User
{
    public record UsuarioCadastroDTO(string nome,  string sobrenome, string email, string password)
    {
        public Usuario ToDomain()
        {
            return new Usuario(nome, sobrenome, email, password);
        }
    }
}
