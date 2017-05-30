using System;

namespace VAssists.DataTransfer.Pontos.responses
{
    public class PontoResponse
    {
        public int Codigo { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataCadastrado { get; set; }
        public DateTime DataRespondido { get; set; }
        public string Tipo { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string EnderecoCompleto { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Observacao { get; set; }

    }
}