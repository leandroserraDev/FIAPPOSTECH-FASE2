using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.DTO.Dtos.User
{
    public record  UsuarioLoginDTO(string email, string password)
    {
        public LoginUser GetUser()
        {
            var loginUser = new LoginUser(email, password);

            return loginUser;
        }
    }

}
