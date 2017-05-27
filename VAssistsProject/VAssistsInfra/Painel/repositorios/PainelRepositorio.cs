using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAssistsInfra.Conexao;
using NHibernate.Linq;
using VDominio.Painel.repositorios;
using VDominio.Modelo;

namespace VAssistsInfra.Painel.repositorios
{
    public class PainelRepositorio : IPainelRepositorio
    {
        private readonly ISession session;

        public PainelRepositorio()
        {
            session = SessionFactory.OpenSession();
        }

        public void AlterarPerfil(int codigoPerfil, string descricao, string identificacao)
        {
            session.BeginTransaction();
            var perfil = session.Query<Perfil>().Where<Perfil>(x => x.IdPerfil == codigoPerfil).FirstOrDefault();

            perfil.IdtPerfil = identificacao;
            perfil.NomePerfil = descricao;

            session.Update(perfil);

            session.Transaction.Commit();
        }

        public void AlterarTipo(int codigoTipo, string descricao, string identificacao)
        {
            session.BeginTransaction();
            var tipo = session.Query<Tipo>().Where<Tipo>(x => x.IdTipo == codigoTipo).FirstOrDefault();

            tipo.IdtTipo = identificacao;
            tipo.NomeTipo = descricao;

            session.Update(tipo);

            session.Transaction.Commit();
        }

        public void DeletarTipo(int codigoTipo)
        {
            session.BeginTransaction();
            var tipo = session.Query<Tipo>().Where<Tipo>(x => x.IdTipo == codigoTipo).FirstOrDefault();

            session.Delete(tipo);
            session.Transaction.Commit();
        }

        public void InserirPerfil(string descricao, string identificao)
        {
            Perfil perfil = new Perfil
            {
               NomePerfil = descricao,
               IdtPerfil = identificao
            };

            session.Save(perfil);
        }

        public void InserirTipo(string descricao, string identificao)
        {
            Tipo tipo = new Tipo
            {
                NomeTipo = descricao,
                IdtTipo = identificao
            };

            session.Save(tipo);
        }

        public IEnumerable<Perfil> ListarPerfil()
        {
            return session.Query<Perfil>();
        }

        public IEnumerable<Tipo> ListarTipo()
        {
            return session.Query<Tipo>();
        }

        public Perfil RetornarPerfil(int codigoPerfil)
        {
            return session.Query<Perfil>().Where<Perfil>(x => x.IdPerfil == codigoPerfil).FirstOrDefault();
        }

        public Tipo RetornarTipo(int codigoTipo)
        {
            return session.Query<Tipo>().Where<Tipo>(x => x.IdTipo == codigoTipo).FirstOrDefault();
        }
    }
}
