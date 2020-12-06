using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoDLL
{
    public class Comentario
    {
        public int Id { get; set; } = 0;
        public int Id_Usuario { get; set; } = 0;
        public int Id_Catalogo { get; set; } = 0;
        public int Id_ComentarioRaiz { get; set; } = 0;
        public string Texto { get; set; } = string.Empty;
        public List<Comentario> Respostas { get; set; } = new List<Comentario>();
    }
}
