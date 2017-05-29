using System.Collections.Generic;
using VDominio.Modelo;

namespace Dominio.Usuarios.entidades
{
    public class ListaUsuarios
    {
        public IEnumerable<Usuario> usuarios { get; set; }
        public int quantidade { get; set; }
        public int pagina { get; set; }
    }
}