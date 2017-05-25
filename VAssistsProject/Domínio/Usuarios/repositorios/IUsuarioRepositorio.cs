using VDominio.Modelo;

namespace VDominio.Usuarios.repositorios
{
    public interface IUsuarioRepositorio
    {
        Usuario RetornaUsuario(int codigoUsuario);
    }
}