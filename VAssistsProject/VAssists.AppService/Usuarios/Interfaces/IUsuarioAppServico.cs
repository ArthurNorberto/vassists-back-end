using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAssists.DataTransfer.Usuarios.requests;
using VAssists.DataTransfer.Usuarios.responses;

namespace VAssists.AppService.Usuarios.Interfaces
{
    public interface IUsuarioAppServico
    {
        UsuarioResponse RetornaUsuario(int codigoUsuario);
        void CadastrarUsuario(CadastrarUsuariosRequest request);
    }
}
