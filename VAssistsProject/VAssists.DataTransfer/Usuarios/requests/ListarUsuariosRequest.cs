﻿namespace VAssists.DataTransfer.Usuarios.requests
{
    public class ListarUsuariosRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int CodigoPerfil { get; set; }
        public int qt { get; set; }
        public int pg { get; set; }
    }
}