using System;

namespace VAssists.DataTransfer.Pontos.responses
{
    public class PontoResponse
    {
        public string NomeUsuario { get; set; }
        public DateTime DataCadastrado { get; set; }
        public DateTime DataRespondido { get; set; }
        public string Tipo { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}