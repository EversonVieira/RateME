using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaoDLL
{
    public class Usuario
    {
        public int Id { get; set; } = 0;
        public string Apelido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
    public class DTO_Usuario
    {
        public int Id { get; set; } = 0;
        public string Apelido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
