using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Senai.Projetos.Comentarios_Check_Point.Interfaces;
using Senai.Projetos.Comentarios_Check_Point.Models;

namespace Senai.Projetos.Comentarios_Check_Point.Repositorios
{
    public class ComentarioRepositorio : IComentario
    {
        public ComentarioModel BuscarPorId(int id)
        {
            string[] linhas = System.IO.File.ReadAllLines("comentarios.csv");

            foreach (var item in linhas)
            {
                string[] dados = item.Split(';');

                if (id.ToString() == dados[0])
                {
                    
                    UsuarioRepositorio usuario = new UsuarioRepositorio();
                    ComentarioModel comentario = new ComentarioModel();

                    comentario.Usuario = new UsuarioModel();

                    comentario.ID = int.Parse(dados[0]);
                    comentario.Usuario.ID = int.Parse(dados[1]);
                    comentario.Usuario.Nome = dados[2];
                    comentario.Texto = dados[3];
                    comentario.DataCriacao = DateTime.Parse(dados[4]);
                    comentario.Status = dados[5];

                    return comentario;
                }
            }

            return null;
        }

        public ComentarioModel Cadastrar(ComentarioModel comentario)
        {
            // Verifica se o arquivo existe
            if (File.Exists("comentarios.csv"))
            {
                // Se o arquivo existe, pega a quantidade de linhas e incrementa 1
                comentario.ID = File.ReadAllLines("comentarios.csv").Length + 1;
            }
            else
            {
                // Caso não exista, define como 1
                comentario.ID = 1;
            }

            comentario.DataCriacao = DateTime.Now;
            comentario.Status = "Validar";

            // Grava as informações no arquivo comentarios.csv
            using (StreamWriter sw = new StreamWriter ("comentarios.csv", true))
            {
                sw.WriteLine ($"{comentario.ID};{comentario.Usuario.ID};{comentario.Usuario.Nome};{comentario.Texto};{comentario.DataCriacao};{comentario.Status}");
            }

            return comentario;
        }

        public ComentarioModel Aprovar(ComentarioModel comentario)
        {
            string[] linhas = System.IO.File.ReadAllLines("comentarios.csv");

            for (int i = 0; i < linhas.Length; i++)
            {
                if (string.IsNullOrEmpty(linhas[i]))
                {
                    continue;
                }

                string[] dados = linhas[i].Split(';');

                if (comentario.ID.ToString() == dados[0])
                {
                    comentario.Status = "Aprovado";

                    // Altera os dados da linha
                    linhas[i] = $"{comentario.ID};{comentario.Usuario.ID};{comentario.Usuario.Nome};{comentario.Texto};{comentario.DataCriacao};{comentario.Status}";
                    break;
                }
            }

            // Altera o arquivo comentarios.csv
            System.IO.File.WriteAllLines("comentarios.csv", linhas);

            return comentario;
        }

        public ComentarioModel Reprovar(ComentarioModel comentario)
        {
            string[] linhas = System.IO.File.ReadAllLines("comentarios.csv");

            for (int i = 0; i < linhas.Length; i++)
            {
                if (string.IsNullOrEmpty(linhas[i]))
                {
                    continue;
                }

                string[] dados = linhas[i].Split(';');

                if (comentario.ID.ToString() == dados[0])
                {
                    comentario.Status = "Reprovado";

                    // Altera os dados da linha
                    linhas[i] = $"{comentario.ID};{comentario.Usuario.ID};{comentario.Usuario.Nome};{comentario.Texto};{comentario.DataCriacao};{comentario.Status}";
                    break;
                }
            }

            // Altera o arquivo comentarios.csv
            System.IO.File.WriteAllLines("comentarios.csv", linhas);

            return comentario;
        }

        public List<ComentarioModel> Listar()
        {
            List<ComentarioModel> lsComentarios = new List<ComentarioModel> ();

            string[] linhas = System.IO.File.ReadAllLines ("comentarios.csv");

            ComentarioModel comentario;

            foreach (var item in linhas)
            {
                // Verifica se a linha é vazia
                if (string.IsNullOrEmpty(item))
                {
                    // Retorna para o foreach
                    continue;
                }

                string[] linha = item.Split(';');

                comentario = new ComentarioModel();

                comentario.Usuario = new UsuarioModel();

                comentario.ID = int.Parse(linha[0]);
                comentario.Usuario.ID = int.Parse(linha[1]);
                comentario.Usuario.Nome = linha[2];
                comentario.Texto = linha[3];
                comentario.DataCriacao = DateTime.Parse(linha[4]);
                comentario.Status = linha[5];

                lsComentarios.Add (comentario);
            }

            return lsComentarios.OrderByDescending(c => c.DataCriacao).ToList();
        }
    }
}