using VDominio.Painel.repositorios;
using System.Collections.Generic;
using System.Linq;
using VAssists.AppService.Painel.Interfaces;
using VAssists.DataTransfer.Painel.responses;

namespace VAssists.AppService.Painel
{
    public class PainelAppServico : IPainelAppServico
    {
        private readonly IPainelRepositorio painelRepositorio;

        public PainelAppServico(IPainelRepositorio painelRepositorio)
        {
            this.painelRepositorio = painelRepositorio;
        }

        public IEnumerable<PerfilResponse> ListarPerfil()
        {
            return painelRepositorio.ListarPerfil().Select(x => new PerfilResponse
                {
                    Codigo = x.IdPerfil,
                    Descricao = x.NomePerfil,
                    IDTPerfil = x.IdtPerfil
                }
            );
        }
    }
}