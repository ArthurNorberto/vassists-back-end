using VDominio.Modelo;
using VDominio.Pontos;
using System;
using VAssistsInfra.Conexao;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using Dominio.Seguranca.entidades;

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

        public ListaPontos ListarPontos(string nomeUsuario, int pg, int qt)
        {
            ListaPontos response = new ListaPontos();

            var pagina = pg - 1;
            var query = session.Query<Ponto>();

            if (!string.IsNullOrEmpty(nomeUsuario))
            {
                query = query.Where<Ponto>(x => x.Usuario.NomeUsuario.ToUpper().Like(nomeUsuario.ToUpper()));
            }

            var result = query.Skip(pagina * qt).Take(qt).ToList();

            response.pontos = result;
            response.pagina = pg;
            response.quantidade = result.Count;

            return response;
        }

        public void RegistrarPonto(Usuario usuario, decimal latitude, decimal longitude, Tipo tipo, string observacao)
        {
            session.BeginTransaction();
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

            session.Transaction.Commit();
        }

        public Ponto RetornarPonto(int codigo)
        {
            return session.Query<Ponto>().Where<Ponto>(x => x.IdPonto == codigo).FirstOrDefault();
        }
    }
}