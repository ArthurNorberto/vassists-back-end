using VDominio.Painel.repositorios;
using System.Collections.Generic;
using System.Linq;
using VAssists.AppService.Painel.Interfaces;
using VAssists.DataTransfer.Painel.responses;
using System;
using VAssists.DataTransfer.Painel.requests;

namespace VAssists.AppService.Painel
{
    public class PainelAppServico : IPainelAppServico
    {
        private readonly IPainelRepositorio painelRepositorio;

        public PainelAppServico(IPainelRepositorio painelRepositorio)
        {
            this.painelRepositorio = painelRepositorio;
        }

        public void AlterarPerfil(int codigoPerfil, AlterarPerfilRequest request)
        {
            painelRepositorio.AlterarPerfil(codigoPerfil, request.Descricao, request.Identificacao);
        }

        public void AlterarTipo(int codigoTipo, AlterarTipoRequest request)
        {
            painelRepositorio.AlterarTipo(codigoTipo, request.Descricao, request.Identificacao);
        }

        public void DeletarPerfil(int codigoPerfil)
        {
            painelRepositorio.DeletarTipo(codigoPerfil);
        }

        public void DeletarTipo(int codigoTipo)
        {
            painelRepositorio.DeletarTipo(codigoTipo);
        }

        public void InserirPerfil(InserirPerfilRequest request)
        {
            painelRepositorio.InserirPerfil(request.Descricao, request.Identificao);
        }

        public void InserirTipo(InserirTipoRequest request)
        {
            painelRepositorio.InserirTipo(request.Descricao, request.Identificao);
        }

        public IEnumerable<PerfilResponse> ListarPerfil()
        {
            return painelRepositorio.ListarPerfil().Select(x => new PerfilResponse
            {
                Codigo = x.IdPerfil,
                Descricao = x.NomePerfil,
                IDTPerfil = x.IdtPerfil
            });
        }

        public IEnumerable<TipoResponse> ListarTipo()
        {
            return painelRepositorio.ListarTipo().Select(x => new TipoResponse
            {
                Codigo = x.IdTipo,
                Descricao = x.NomeTipo,
                IDTTipo = x.IdtTipo
            });
        }

        public PerfilResponse RetornarPerfil(int codigoPerfil)
        {
            var perfil = painelRepositorio.RetornarPerfil(codigoPerfil);

            PerfilResponse response = new PerfilResponse()
            {
               Codigo = perfil.IdPerfil,
               Descricao = perfil.NomePerfil,
               IDTPerfil = perfil.IdtPerfil
            };

            return response;
        }

        public TipoResponse RetornarTipo(int codigoTipo)
        {
            var perfil = painelRepositorio.RetornarTipo(codigoTipo);

            TipoResponse response = new TipoResponse()
            {
                Codigo = perfil.IdTipo,
                Descricao = perfil.NomeTipo,
                IDTTipo = perfil.IdtTipo
            };


            return response;
        }
    }
}