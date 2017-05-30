using Dominio.Respostas.repositorios;
using System.Collections.Generic;
using System.Linq;
using VAssists.AppService.Auxiliares;
using VAssists.AppService.Auxiliares.Interfaces;
using VAssists.AppService.Respostas.Interfaces;
using VAssists.DataTransfer.Respostas.requests;
using VAssists.DataTransfer.Respostas.responses;
using VAssistsInfra.Pontos.repositorios;
using VAssistsInfra.Respostas.repositorios;
using VAssistsInfra.Usuarios.repositorios;
using VDominio.Pontos.repositorios;
using VDominio.Usuarios.repositorios;

namespace VAssists.AppService.Respostas
{
    public class RespostaAppServico : GenericoAppServico, IRespostaAppServico
    {
        private readonly IRespostaRepositorio respostaRepositorio;
        private readonly IRegistroPontoRepositorio registroPontoRepositorio;
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public RespostaAppServico(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.respostaRepositorio = new RespostaRepositorio(unitOfWork.Session);
            this.registroPontoRepositorio = new RegistroPontoRepositorio(unitOfWork.Session);
            this.usuarioRepositorio = new UsuarioRepositorio(unitOfWork.Session);
        }

        public void InserirResposta(int codigoPonto, InserirRespostaRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var ponto = registroPontoRepositorio.RetornarPonto(codigoPonto);
                var usuario = usuarioRepositorio.RetornaUsuario(request.CodigoUsuario);

                respostaRepositorio.InserirResposta(ponto, usuario, request.Texto);

                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
            finally
            {
                unitOfWork.Dispose();
            }
        }

        public IEnumerable<RespostaResponse> ListarRespostas(int codigoPonto)
        {
            var response = respostaRepositorio.ListarRespostas(codigoPonto).Select(x => new RespostaResponse
            {
                Codigo = x.IdResposta,
                NomeUsuario = x.Usuario.NomeUsuario,
                Texto = x.Texto,
                DataRespondido = x.DataResposta
            });

            return response;
        }
    }
}