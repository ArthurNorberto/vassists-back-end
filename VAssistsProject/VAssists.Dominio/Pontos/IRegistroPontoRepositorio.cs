

using VDominio.Modelo;

namespace VDominio.Pontos
{
    public interface IRegistroPontoRepositorio
    {
        Ponto RetornarPonto(int codigo);

        void RegistrarPonto(int codigoUsuario, decimal latitude, decimal longitude, int tipo, string observacao);
    }
}