﻿using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.Services.Interface
{
    public interface IServicoUsuario : IServicoGenerico<Usuario>
    {
        Task<Usuario> Login(string email, string password);
        Task<bool> TrocarSenha(int id, string password);
    }
}
