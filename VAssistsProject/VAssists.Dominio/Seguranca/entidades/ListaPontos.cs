using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDominio.Modelo;

namespace Dominio.Seguranca.entidades
{
    public class ListaPontos
    {
        public IEnumerable<Ponto> pontos { get; set; }
        public int quantidade { get; set; }
        public int pagina { get; set; }
    }
}
