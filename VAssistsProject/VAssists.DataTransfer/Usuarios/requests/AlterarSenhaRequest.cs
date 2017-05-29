namespace VAssists.DataTransfer.Usuarios.requests
{
    public class AlterarSenhaRequest
    {
        public string SenhaAntiga { get; set; }
        public string SenhaNova { get; set; }
        public string SenhaNovaConfirme { get; set; }
    }
}