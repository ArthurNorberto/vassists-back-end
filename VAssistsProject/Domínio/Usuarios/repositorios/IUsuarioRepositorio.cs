using Domínio.Modelo;

namespace Domínio.Usuarios.repositorios
{
    public interface IUsuarioRepositorio
    {
        Usuario RetornaUsuario(int codigoUsuario);
    }
}