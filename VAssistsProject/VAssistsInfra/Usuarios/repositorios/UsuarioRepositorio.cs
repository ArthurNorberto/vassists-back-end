using VDominio.Modelo;
using VDominio.Usuarios.repositorios;
using NHibernate;
using VAssistsInfra.Conexao;
using NHibernate.Linq;
using System.Linq;
using System;
using Dominio.Usuarios.entidades;

namespace VAssistsInfra.Usuarios.repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ISession session;

        public UsuarioRepositorio()
        {
            session = SessionFactory.OpenSession();
        }

        public void CadastrarUsuario(Perfil perfil, string email, string nome)
        {
            Usuario usuario = new Usuario()
            {
                Perfil = perfil,
                Email = email,
                NomeUsuario = nome
            };

            session.Save(usuario);
        }

        public ListaUsuarios ListarUsuarios(string nome, string email, int perfil, int pg, int qt)
        {
            ListaUsuarios response = new ListaUsuarios();

            var pagina = pg - 1;
            var query = session.Query<Usuario>();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where<Usuario>(x => x.NomeUsuario.ToUpper().Like(nome.ToUpper()));
            }
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where<Usuario>(x => x.Email.ToUpper().Like(email.ToUpper()));
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

        public Usuario RetornaUsuario(int codigoUsuario)
        {
            var usuario = session.Query<Usuario>().Where<Usuario>(x => x.IdUsuario == codigoUsuario).FirstOrDefault();

            return usuario;
        }
    }
}