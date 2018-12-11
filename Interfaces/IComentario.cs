using System.Collections.Generic;
using Senai.Projetos.Comentarios_Check_Point.Models;

namespace Senai.Projetos.Comentarios_Check_Point.Interfaces
{
    /// <summary>
    /// Interface dos Comentários
    /// Métodos que a classe irá herdar deverá ter
    /// </summary>
    public interface IComentario
    {
        /// <summary>
        /// Cadastra um novo comentário
        /// </summary>
        /// <param name="comentario">ComentarioModel</param>
        /// <returns>Retorna um comentário</returns>
        ComentarioModel Cadastrar(ComentarioModel comentario);

        /// <summary>
        /// Edita o status de um comentário para aprovado
        /// </summary>
        /// <param name="comentario">ComentarioModel</param>
        /// <returns>Retorna um ComentarioModel aprovado</returns>
        ComentarioModel Aprovar(ComentarioModel comentario);

        /// <summary>
        /// Edita o status do comentário para reprovado
        /// </summary>
        /// <param name="comentario">ComentarioModel</param>
        /// <returns>Retorna um ComentarioModel reprovado</returns>
        ComentarioModel Reprovar(ComentarioModel comentario);

        /// <summary>
        /// Lista todos os comentários
        /// </summary>
        /// <returns>Retorna um List<ComentarioModel></returns>
        List<ComentarioModel> Listar();

        /// <summary>
        /// Busca um comentário através do seu ID
        /// </summary>
        /// <param name="id">ID do comentário</param>
        /// <returns>Retorna um id do comentário</returns>
        ComentarioModel BuscarPorId(int id);
    }
}