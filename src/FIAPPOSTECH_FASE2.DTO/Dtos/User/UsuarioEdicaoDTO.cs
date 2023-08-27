using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.DTO.Dtos.User
{
    public record UsuarioEdicaoDTO(int id, string nome,  string sobrenome, string email)
    {
        public Usuario ToDomain()
        {
            return new Usuario(id, nome, sobrenome, email);
        }
    }
}
