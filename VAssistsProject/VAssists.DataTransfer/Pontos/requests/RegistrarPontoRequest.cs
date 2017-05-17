using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssists.DataTransfer.Pontos.requests
{
    public class RegistrarPontoRequest
    {
        public int CodigoUsuario { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Tipo { get; set; }
        public string Observacao { get; set; }
    }
}
