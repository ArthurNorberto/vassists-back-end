using System;

namespace VDominio.Modelo
{
    public class Usuario
    {
        public virtual int IdUsuario { get; set; }
        public virtual string NomeUsuario { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual DateTime Dataultimologin { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}