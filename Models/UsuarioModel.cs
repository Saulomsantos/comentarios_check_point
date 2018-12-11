using Microsoft.Extensions.Primitives;

namespace Senai.Projetos.Comentarios_Check_Point.Models
{
    public class UsuarioModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string confirmSenha { get; set; }
        public int ID { get; set; }
        public string Tipo { get; set; }
    }
}