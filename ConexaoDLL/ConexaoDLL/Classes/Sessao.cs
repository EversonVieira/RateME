using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaoDLL
{
    public class Sessao
    {
        public int Id { get; set; } = 0;
        public int Id_Usuario { get; set; } = 0;
        public string Chave { get; set; } = string.Empty;
        public DateTime DataConexao { get; set; } = DateTime.MinValue;
    }
}
