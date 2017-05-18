﻿using Domínio.Modelo;
using Domínio.Seguranca.repositorios;
using NHibernate;
using NHibernate.Linq;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using VAssistsInfra.Auxiliares;
using VAssistsInfra.Conexão;

namespace VAssistsInfra.Seguranca.repositorios
{
    public class SegurancaRepositorio : ISegurancaRepositorio
    {
        private readonly ISession session;

        public SegurancaRepositorio()
        {
            session = SessionFactory.OpenSession();
        }

        public void CadastroSistema(string nome, string email, int codigoPerfil)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = ConfigMD5.GetMd5Hash(md5Hash, "123456");
                var perfil = session.Query<Perfil>().Where<Perfil>(x => x.IdPerfil == codigoPerfil).First();
                Usuario usuario = new Usuario
                {
                    NomeUsuario = nome,
                    Email = email,
                    Perfil = perfil,
                    Senha = hash
                };

                session.Save(usuario);
            }
        }

        public Usuario LogarNoSistema(string login, string senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = ConfigMD5.GetMd5Hash(md5Hash, senha);

                var usuario = session.Query<Usuario>().Where<Usuario>(x => x.Email == login && x.Senha == hash).FirstOrDefault();

                return usuario;
            }
        }
    }
}