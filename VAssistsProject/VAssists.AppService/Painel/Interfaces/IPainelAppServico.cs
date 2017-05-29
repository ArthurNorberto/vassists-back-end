using System.Collections.Generic;
using VAssists.DataTransfer.Painel.requests;
using VAssists.DataTransfer.Painel.responses;

namespace VAssists.AppService.Painel.Interfaces
{
    public interface IPainelAppServico
    {
        IEnumerable<PerfilResponse> ListarPerfil();

        void InserirPerfil(InserirPerfilRequest request);

        IEnumerable<TipoResponse> ListarTipo();

        void InserirTipo(InserirTipoRequest request);

        void AlterarPerfil(int codigoPerfil, AlterarPerfilRequest request);

        void DeletarPerfil(int codigoPerfil);

        void AlterarTipo(int codigoTipo, AlterarTipoRequest request);

        void DeletarTipo(int codigoTipo);

        PerfilResponse RetornarPerfil(int codigoPerfil);

        TipoResponse RetornarTipo(int codigoTipo);

        IEnumerable<PerfilResponse> ListarPerfilSemAdmin();
    }
}