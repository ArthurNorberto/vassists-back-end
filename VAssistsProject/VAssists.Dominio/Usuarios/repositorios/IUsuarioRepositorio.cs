﻿using Dominio.Usuarios.entidades;
using VDominio.Modelo;

namespace VDominio.Usuarios.repositorios
{
    public interface IUsuarioRepositorio
    {
        Usuario RetornaUsuario(int codigoUsuario);

        void CadastrarUsuario(Perfil perfil, string email, string nome);

        ListaUsuarios ListarUsuarios(string nome, string email, int perfil, int pg, int qt);

        void AlterarUsuario(Perfil perfil, int codigoUsuario, string email, string nome);

        void ExcluirUsuario(int codigoUsuario);

        void ResetarSenha(int codigoUsuario);

        void AlterarSenha(int codigoUsuario, string senhaNova);
    }
}