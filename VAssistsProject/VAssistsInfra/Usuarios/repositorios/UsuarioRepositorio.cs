using Dominio.Usuarios.entidades;
using NHibernate.Linq;
using System.Linq;
using System.Security.Cryptography;
using VAssistsInfra.Auxiliares;
using VDominio.Modelo;
using VDominio.Usuarios.repositorios;
using NHibernate;

namespace VAssistsInfra.Usuarios.repositorios
{
    public class UsuarioRepositorio : GenericoRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ISession session) : base(session)
        {
        }

        public void AlterarSenha(int codigoUsuario, string senhaNova)
        {
            string hash;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = ConfigMD5.GetMd5Hash(md5Hash, senhaNova);
            }

            var usuario = session.Query<Usuario>().Where(x => x.IdUsuario == codigoUsuario).FirstOrDefault();

            usuario.Senha = hash;

            session.Update(usuario);
        }

        public void AlterarUsuario(Perfil perfil, int codigoUsuario, string email, string nome)
        {
            var usuario = session.Query<Usuario>().Where(x => x.IdUsuario == codigoUsuario).FirstOrDefault();

            usuario.Perfil = perfil;
            usuario.Email = email;
            usuario.NomeUsuario = nome;

            session.Update(usuario);
        }

        public void CadastrarUsuario(Perfil perfil, string email, string nome)
        {
            string hash;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = ConfigMD5.GetMd5Hash(md5Hash, "123456");
            }

            Usuario usuario = new Usuario()
            {
                Perfil = perfil,
                Email = email,
                NomeUsuario = nome,
                Senha = hash
            };

            session.Save(usuario);
        }

        public void ExcluirUsuario(int codigoUsuario)
        {
            var usuario = session.Query<Usuario>().Where(x => x.IdUsuario == codigoUsuario).FirstOrDefault();

            session.Delete(usuario);
        }

        public ListaUsuarios ListarUsuarios(string nome, string email, int perfil, int pg, int qt)
        {
            ListaUsuarios response = new ListaUsuarios();

            var pagina = pg - 1;
            var query = session.Query<Usuario>();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(x => x.NomeUsuario.ToUpper().Like("%" + nome.ToUpper() + "%"));
            }
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(x => x.Email.ToUpper().Like("%" + email.ToUpper() + "%"));
            }

            if (perfil != 0)
            {
                query = query.Where<Usuario>(x => x.Perfil.IdPerfil == perfil);
            }

            var result = query.Skip(pagina * qt).Take(qt).ToList();

            response.usuarios = result;
            response.pagina = pg;
            response.quantidade = result.Count;

            return response;
        }

        public void ResetarSenha(int codigoUsuario)
        {
            string hash;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = ConfigMD5.GetMd5Hash(md5Hash, "123456");
            }

            var usuario = session.Query<Usuario>().Where(x => x.IdUsuario == codigoUsuario).FirstOrDefault();

            usuario.Senha = hash;

            session.Update(usuario);
        }

        public Usuario RetornaUsuario(int codigoUsuario)
        {
            var usuario = session.Query<Usuario>().Where<Usuario>(x => x.IdUsuario == codigoUsuario).FirstOrDefault();

            return usuario;
        }
    }
}