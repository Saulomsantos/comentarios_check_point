using System;

namespace Senai.Projetos.Comentarios_Check_Point.Models
{
    public class ComentarioModel
    {
        public DateTime DataCriacao { get; set; }
        public UsuarioModel Usuario { get; set; }
        public int ID { get; set; }
        public string Texto { get; set; }
        public string Status { get; set; }
    }
}