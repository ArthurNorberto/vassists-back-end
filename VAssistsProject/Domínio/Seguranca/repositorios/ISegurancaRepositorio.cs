using VDominio.Modelo;

namespace VDominio.Seguranca.repositorios
{
    public interface ISegurancaRepositorio
    {
        Usuario LogarNoSistema(string login, string senha);

        void CadastroSistema(string nome, string email, int codigoPerfil);
    }
}