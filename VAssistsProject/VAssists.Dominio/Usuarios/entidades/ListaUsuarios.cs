using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
