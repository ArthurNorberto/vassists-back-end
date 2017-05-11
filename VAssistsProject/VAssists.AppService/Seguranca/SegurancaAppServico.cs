using Domínio.Seguranca.repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAssists.AppService.Seguranca.Interfaces;
using VAssists.DataTransfer.Seguranca.requests;
using VAssists.DataTransfer.Seguranca.responses;

namespace VAssists.AppService.Seguranca
{
    public class SegurancaAppServico : ISegurancaAppServico
    {
        private readonly ISegurancaRepositorio segurancaRepositorio;

        public SegurancaAppServico(ISegurancaRepositorio segurancaRepositorio)
        {
            this.segurancaRepositorio = segurancaRepositorio;
        }

        public UsuarioLogadoResponse LogarNoSistema(LoginSistemaRequest request)
        {
            var usuario = segurancaRepositorio.LogarNoSistema(request.login, request.senha);

            UsuarioLogadoResponse response = new UsuarioLogadoResponse()
            {
                idUsuario = usuario.IDUSUARIO,
                nomeUsuario = usuario.NOMEUSUARIO
            };

            return response;
        }
    }
}
