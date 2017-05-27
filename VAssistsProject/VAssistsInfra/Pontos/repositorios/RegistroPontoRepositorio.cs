using VDominio.Modelo;
using VDominio.Pontos;
using System;
using VAssistsInfra.Conexao;
using NHibernate;
using NHibernate.Linq;
using System.Linq;

namespace VAssistsInfra.Pontos.repositorios
{
    public class RegistroPontoRepositorio : IRegistroPontoRepositorio
    {
        private readonly ISession session;

        public RegistroPontoRepositorio()
        {
            session = SessionFactory.OpenSession();
        }

        public void DeletarPonto(int codigoPonto)
        {
            session.BeginTransaction();
            var ponto = session.Query<Ponto>().Where<Ponto>(x => x.IdPonto == codigoPonto).FirstOrDefault();

            session.Delete(ponto);

            session.Transaction.Commit();
        }

        public void RegistrarPonto(Usuario usuario, decimal latitude, decimal longitude, Tipo tipo, string observacao)
        {
            Ponto ponto = new Ponto
            {
                Latitude = latitude,
                Longitude = longitude,
                DataCadastrado = new DateTime(),
                Observacao = observacao,
                Tipo = tipo,
                Usuario = usuario
            };

            session.Save(ponto);
        }

        public Ponto RetornarPonto(int codigo)
        {
            return session.Query<Ponto>().Where<Ponto>(x => x.IdPonto == codigo).FirstOrDefault();
        }
    }
}