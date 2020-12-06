using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoDLL
{
    public class Catalogo
    {
        public int Id { get; set; } = 0;
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int PontuacaoMedia { get; set; } = 0;
        public int QntAvaliacoes { get; set; } = 0;

        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}
