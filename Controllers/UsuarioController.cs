using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Projetos.Comentarios_Check_Point.Models;
using Senai.Projetos.Comentarios_Check_Point.Repositorios;

namespace Senai.Projetos.Comentarios_Check_Point.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(IFormCollection form)
        {
            UsuarioModel usuario = new UsuarioModel();

            usuario.Nome = form["nome"];
            usuario.Email = form["email"];
            usuario.Senha = form["senha"];
            usuario.confirmSenha = form["confirmSenha"];

            if (usuario.Senha != usuario.confirmSenha)
            {
                ViewBag.Mensagem = "As senhas não conferem!";

                return View();
            }

            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

            usuarioRepositorio.Cadastrar(usuario);

            ViewBag.Mensagem = "Usuário cadastrado!";

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

            UsuarioModel usuario = usuarioRepositorio.Login(form["email"], form["senha"]);

            if (usuario != null)
            {
                HttpContext.Session.SetString("idUsuario", usuario.ID.ToString());
                HttpContext.Session.SetString("nomeUsuario", usuario.Nome);
                HttpContext.Session.SetString("tipoUsuario",usuario.Tipo);
                
                if (usuario.Tipo == "Cliente")
                {
                    return RedirectToAction("Cadastrar","Comentario");
                }

                if (usuario.Tipo == "Administrador")
                {
                    return RedirectToAction("Listar","Comentario");
                }
            }

            ViewBag.Mensagem = "Usuário inválido!";

            return View();
        }
    }
}