using Domínio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domínio.Modelo
{
    public class Usuario
    {
        public virtual int idUsuario { get; set; }
        public virtual string nomeUsuario { get; set; }
        public virtual string email { get; set; }
        public virtual string senha { get; set; }
        public virtual DateTime dataultimologin { get; set; }
        public virtual Perfil perfil { get; set; }
    }
}
