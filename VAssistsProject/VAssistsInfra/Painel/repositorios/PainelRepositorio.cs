using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using VAssistsInfra.Auxiliares;
using VDominio.Modelo;
using VDominio.Painel.repositorios;
using NHibernate;

namespace VAssistsInfra.Painel.repositorios
{
    public class PainelRepositorio : GenericoRepositorio, IPainelRepositorio
    {
        public PainelRepositorio(ISession session) : base(session)
        {
        }

        public void AlterarPerfil(int codigoPerfil, string descricao, string identificacao)
        {
            var perfil = session.Query<Perfil>().Where<Perfil>(x => x.IdPerfil == codigoPerfil).FirstOrDefault();

            perfil.IdtPerfil = identificacao;
            perfil.NomePerfil = descricao;

            session.Update(perfil);
        }

        public void AlterarTipo(int codigoTipo, string descricao, string identificacao)
        {
            var tipo = session.Query<Tipo>().Where<Tipo>(x => x.IdTipo == codigoTipo).FirstOrDefault();

            tipo.IdtTipo = identificacao;
            tipo.NomeTipo = descricao;

            session.Update(tipo);
        }

        public void DeletarPerfil(int codigoPerfil)
        {
            var perfil = session.Query<Perfil>().Where(x => x.IdPerfil == codigoPerfil).FirstOrDefault();

            session.Delete(perfil);
        }

        public void DeletarTipo(int codigoTipo)
        {
            var tipo = session.Query<Tipo>().Where<Tipo>(x => x.IdTipo == codigoTipo).FirstOrDefault();

            session.Delete(tipo);
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

        public IEnumerable<Perfil> ListarPerfilSemAdmin()
        {
            return session.Query<Perfil>().Where(x => x.IdtPerfil != "A");
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