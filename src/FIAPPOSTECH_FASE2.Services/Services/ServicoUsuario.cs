using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using FIAPPOSTECH_FASE2.DOMAIN.Repositories;
using FIAPPOSTECH_FASE2.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.Services.Services
{
    public class ServicoUsuario : ServicoGenerico<Usuario>, IServicoUsuario
    {
        private readonly Usuario _usuarioLogado;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ServicoUsuario(IRepositorioGenerico<Usuario> repositorioGenerico,
            IServicoUsuarioLogado usuarioLogado,
            IRepositorioUsuario repositorioUsuario) : base(repositorioGenerico)
        {
            _usuarioLogado = usuarioLogado.Get().Result;
            _repositorioUsuario = repositorioUsuario;
        }




        public override async Task<Usuario> Add(Usuario entity)
        {
            if (entity == null)
            {
                return null;
            }
            var usuario = await _repositorioUsuario.Get(obj => obj.Email.ToLower().Equals(entity.Email.ToLower()));
            if (usuario != null) return null;

         GerarSenha(entity.Password, entity);

            return await base.Add(entity);
        }

 

        public async Task<Usuario> Login(string email, string password)
        {

            var usuario = await _repositorioUsuario.Get(us => us.Email.ToLower().Equals(email));

            if (usuario == null) { return null; }

            if (!await CompareSenha(password, usuario.SaltHash, usuario.Password)) return null;

            return await Task.FromResult(usuario);
        }

        public async Task<bool> TrocarSenha(int id, string password)
        {


            var usuario = await _repositorioUsuario.Get(us => us.Id.Equals(id));
            if (usuario == null
                ||
                !_usuarioLogado.Id.Equals(id)) return false;
            

           GerarSenha(password, usuario);

            await _repositorioUsuario.Update(usuario);
            return await Task.FromResult(true);
        }

        private void GerarSenha(string password, Usuario usuario)
        {
            var rngCsp = RandomNumberGenerator.Create();

            byte[] salt = new byte[16];
            rngCsp.GetBytes(salt);

            var senha = password;

            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 1000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string hashSenha = Convert.ToBase64String(hashBytes);

            usuario.TrocarSenha(hashSenha);
            usuario.AdicionarHashSalt(salt);


        }

        private async Task<bool> CompareSenha(string password, byte[] salt, string passwordEntity)
        {

            var senha = password;

            var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 1000);

            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string hashSenha = Convert.ToBase64String(hashBytes);

            if (hashSenha.Equals(passwordEntity))
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);

        }

    }
}
