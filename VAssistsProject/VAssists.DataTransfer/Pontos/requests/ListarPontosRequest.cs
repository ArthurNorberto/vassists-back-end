using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssists.DataTransfer.Pontos.requests
{
    public class ListarPontosRequest
    {
        public string NomeUsuario { get; set; }
        public int qt { get; set; }
        public int pg { get; set; }
    }
}
