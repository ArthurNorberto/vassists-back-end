namespace VAssists.DataTransfer.Usuarios.requests
{
    public class AlterarUsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int CodigoPerfil { get; set; }
    }
}