using System.Collections.Generic;
using VDominio.Modelo;

namespace VDominio.Painel.repositorios
{
    public interface IPainelRepositorio
    {
        IEnumerable<Perfil> ListarPerfil();

        void InserirPerfil(string descricao, string identificao);

        IEnumerable<Tipo> ListarTipo();

        void InserirTipo(string descricao, string identificao);

        void DeletarTipo(int codigoTipo);

        void AlterarPerfil(int codigoPerfil, string descricao, string identificacao);

        void AlterarTipo(int codigoTipo, string descricao, string identificacao);

        Perfil RetornarPerfil(int codigoPerfil);

        Tipo RetornarTipo(int codigoTipo);

        IEnumerable<Perfil> ListarPerfilSemAdmin();

        void DeletarPerfil(int codigoPerfil);
    }
}