using System.IO;
using Senai.Projetos.Comentarios_Check_Point.Interfaces;
using Senai.Projetos.Comentarios_Check_Point.Models;

namespace Senai.Projetos.Comentarios_Check_Point.Repositorios
{
    public class UsuarioRepositorio : IUsuario
    {
        public UsuarioModel Cadastrar(UsuarioModel usuario)
        {
            // Verifica se o arquivo existe
            if (File.Exists("usuarios.csv"))
            {
                // Se o arquivo existe, pega a quantidade de linhas e incrementa 1
                usuario.ID = File.ReadAllLines("usuarios.csv").Length + 1;
            }
            else
            {
                // cria o arquivo usuarios.csv com o administrador como sendo o primeiro usuário
                using (StreamWriter sw = new StreamWriter ("usuarios.csv", true))
                {
                    sw.WriteLine($"1;Administrador;admin@carfel.com;admin;admin;Administrador");
                }

                // Após criar o administrador, incrementa 1 para que o primeiro usuário cadastrado tenha o ID 2
                usuario.ID = File.ReadAllLines("usuarios.csv").Length + 1;
            }

            usuario.Tipo = "Cliente";

            // Grava as informações no arquivo usuarios.csv
            using (StreamWriter sw = new StreamWriter ("usuarios.csv", true))
            {
                sw.WriteLine($"{usuario.ID};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.confirmSenha};{usuario.Tipo}");
            }

            return usuario;
        }

        public UsuarioModel Login(string email, string senha)
        {
            using(StreamReader sr = new StreamReader("usuarios.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string[] linha = sr.ReadLine().Split(";");

                    if (linha[0] == "")
                    {
                        continue;
                    }

                    if (linha[2] == email && linha[3] == senha)
                    {
                        UsuarioModel usuario = new UsuarioModel();

                        usuario.ID = int.Parse(linha[0]);
                        usuario.Nome = linha[1];
                        usuario.Email = linha[2];
                        usuario.Senha = linha[3];
                        usuario.confirmSenha = linha[4];
                        usuario.Tipo = linha[5];

                        return usuario;
                    }
                }
            }

            return null;
        }
    }
}