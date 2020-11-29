using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaoDLL
{
    public class ValidadorUsuario
    {
        public bool ValidarUsuario(Usuario usuario)
        {
            bool retorno = true;

            if (string.IsNullOrEmpty(usuario.Apelido))
            {
                throw new Exception("Apelido não informado.");
            }

            if (string.IsNullOrEmpty(usuario.Email) || !usuario.Email.Contains("@"))
            {
                throw new Exception("E-mail inválido");
            }
            if (string.IsNullOrEmpty(usuario.Senha))
            {
                throw new Exception("Senha inválida");
            }
            return retorno;
        }
    }
}
