namespace VAssists.DataTransfer.Pontos.requests
{
    public class RegistrarPontoRequest
    {
        public int CodigoUsuario { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int CodigoTipo { get; set; }
        public string Observacao { get; set; }
        public string Endereco { get; set; }
    }
}