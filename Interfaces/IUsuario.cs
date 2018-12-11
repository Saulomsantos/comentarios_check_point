using Senai.Projetos.Comentarios_Check_Point.Models;

namespace Senai.Projetos.Comentarios_Check_Point.Interfaces
{
    /// <summary>
    /// Interface do Usuário
    /// Métodos que a classe que irá herdar deverá ter
    /// </summary>
    public interface IUsuario
    {
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">UsuarioModel</param>
        /// <returns>Retorna um usuário</returns>
        UsuarioModel Cadastrar(UsuarioModel usuario);
        /// <summary>
        /// Efetua o login do usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna o usuário logado</returns>
        UsuarioModel Login(string email, string senha);
    }
}