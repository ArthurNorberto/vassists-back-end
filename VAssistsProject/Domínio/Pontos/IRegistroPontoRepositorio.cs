using Domínio.Modelo;

namespace Domínio.Pontos
{
    public interface IRegistroPontoRepositorio
    {
        Ponto RetornarPonto(int codigo);

        void RegistrarPonto(int codigoUsuario, decimal latitude, decimal longitude, int tipo, string observacao);
    }
}