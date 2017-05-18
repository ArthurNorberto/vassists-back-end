using System;

namespace VAssists.DataTransfer.Usuarios.responses
{
    public class UsuarioResponse
    {
        public int CodigoUsuario { get; set; }
        public string Nome { get; set; }
        public string email { get; set; }
        public string Perfil { get; set; }
        public DateTime DataUltimoLogin { get; set; }
    }
}