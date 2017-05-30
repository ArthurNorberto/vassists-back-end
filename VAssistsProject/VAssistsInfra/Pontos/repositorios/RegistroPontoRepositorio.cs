using Dominio.Seguranca.entidades;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using VAssistsInfra.Auxiliares;
using VDominio.Modelo;
using VDominio.Pontos;
using VDominio.Pontos.repositorios;

namespace VAssistsInfra.Pontos.repositorios
{
    public class RegistroPontoRepositorio : GenericoRepositorio, IRegistroPontoRepositorio
    {
        public RegistroPontoRepositorio(ISession session) : base(session)
        {
        }

        public void DeletarPonto(int codigoPonto)
        {
            var ponto = session.Query<Ponto>().Where<Ponto>(x => x.IdPonto == codigoPonto).FirstOrDefault();

            session.Delete(ponto);
        }

        public ListaPontos ListarMeusPontos(int codigoUsuario, DateTime? dataInicial, DateTime? dataFinal, string endereco, int codigoTipo, int pg, int qt)
        {
            ListaPontos response = new ListaPontos();

            var pagina = pg - 1;
            var query = session.Query<Ponto>();

            if (codigoUsuario != 0)
            {
                query = query.Where(x => x.Usuario.IdUsuario == codigoUsuario);
            }

            if (codigoTipo != 0)
            {
                query = query.Where(x => x.Tipo.IdTipo == codigoTipo);
            }

            if (dataInicial != null)
            {
                query = query.Where(x => x.DataCadastrado >= dataInicial);
            }

            if (dataFinal != null)
            {
                query = query.Where(x => x.DataCadastrado <= dataFinal);
            }

            if (!string.IsNullOrEmpty(endereco))
            {
                query = query.Where(x => x.EnderecoCompleto.ToUpper().Like("%" + endereco.ToUpper() + "%"));
            }

            var result = query.Skip(pagina * qt).Take(qt).ToList();

            response.pontos = result;
            response.pagina = pg;
            response.quantidade = result.Count;

            return response;
        }

        public ListaPontos ListarPontos(string nomeUsuario, DateTime? dataInicial, DateTime? dataFinal, string endereco, int codigoTipo, int pg, int qt)
        {
            ListaPontos response = new ListaPontos();

            var pagina = pg - 1;
            var query = session.Query<Ponto>();

            if (!string.IsNullOrEmpty(nomeUsuario))
            {
                query = query.Where(x => x.Usuario.NomeUsuario.ToUpper().Like("%" + nomeUsuario.ToUpper() + "%"));
            }

            if (dataInicial != null)
            {
                query = query.Where(x => x.DataCadastrado >= dataInicial);
            }

            if (dataFinal != null)
            {
                query = query.Where(x => x.DataCadastrado <= dataFinal);
            }

            if (!string.IsNullOrEmpty(endereco))
            {
                query = query.Where(x => x.EnderecoCompleto.ToUpper().Like("%" + endereco.ToUpper() + "%"));
            }

            if (codigoTipo != 0)
            {
                query = query.Where(x => x.Tipo.IdTipo == codigoTipo);
            }

            var result = query.Skip(pagina * qt).Take(qt).ToList();

            response.pontos = result;
            response.pagina = pg;
            response.quantidade = result.Count;

            return response;
        }

        public void RegistrarPonto(Usuario usuario, decimal latitude, decimal longitude, Tipo tipo, string observacao, string enderecoCompleto, string cidade, string estado, string pais)
        {
            Ponto ponto = new Ponto
            {
                Latitude = latitude,
                Longitude = longitude,
                DataCadastrado = DateTime.Now,
                Observacao = observacao,
                Tipo = tipo,
                Usuario = usuario,
                EnderecoCompleto = enderecoCompleto,
                Cidade = cidade,
                Estado =estado,
                Pais = pais
            };

            session.Save(ponto);
        }

        public Ponto RetornarPonto(int codigo)
        {
            return session.Query<Ponto>().Where<Ponto>(x => x.IdPonto == codigo).FirstOrDefault();
        }
    }
}