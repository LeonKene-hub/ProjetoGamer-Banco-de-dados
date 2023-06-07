using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoGamer_Banco_de_dados.Infra;
using ProjetoGamer_Banco_de_dados.Models;

namespace ProjetoGamer_Banco_de_dados.Controllers
{
    [Route("[controller]")]
    public class EquipeController : Controller
    {
        private readonly ILogger<EquipeController> _logger;

        public EquipeController(ILogger<EquipeController> logger)
        {
            _logger = logger;
        }

        //instancia do contexto para acessar o banco de dados
        Context c = new Context();

        [Route("Listar")] //http://localhost/Equipe/Listar
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            //variavel que armazena as equipes listadas do banco de dados
            ViewBag.Equipe = c.Equipe.ToList();

            //retorna a view de equipe (tela)
            return View();
        }

        [Route("Cadastrar")] //http://localhost/Equipe/Cadastrar
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();

            novaEquipe.Nome = form["Nome"].ToString();

            //novaEquipe.Imagem = form["Imagem"].ToString();
            if (form.Files.Count > 0)
            {
                var file = form.Files[0];

                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using (var stream = new FileStream(path,FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem = file.FileName;
            }
            else
            {
                novaEquipe.Imagem = "padrao.png";
            }

            c.Equipe.Add(novaEquipe);

            c.SaveChanges();

            ViewBag.Equipe = c.Equipe.ToList();

            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("Excluir{id}")] //http://localhost/Equipe/Excluir
        public IActionResult Excluir(int id)
        {
            Equipe equipeBuscada = c.Equipe.First(e => e.IdEquipe == id)!;
            c.Remove(equipeBuscada);

            c.SaveChanges();

            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("Editar{id}")] //http://localhost/Equipe/Editar
        public IActionResult Editar(int id)
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            
            Equipe equipeBuscada = c.Equipe.First(e => e.IdEquipe == id)!;

            ViewBag.Equipe = equipeBuscada;

            return View("Edit");
        }

        [Route("Atualiazar")]
        public IActionResult Atualizar(IFormCollection form)
        {
            Equipe equipe = new Equipe();

            equipe.IdEquipe = int.Parse(form["IdEquipe"].ToString());
            equipe.Nome = form["Nome"];

            if (form.Files.Count > 0)
            {
                var file = form.Files[0];

                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                using(var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                equipe.Imagem = file.FileName;
            }
            else
            {
                equipe.Imagem = "Padrao.png";
            }

            Equipe editada = c.Equipe.First(x => x.IdEquipe == equipe.IdEquipe);
            editada.Nome = equipe.Nome;
            editada.Imagem = equipe.Imagem;
            c.Equipe.Update(editada);
            c.SaveChanges();
            return LocalRedirect("~/Equipe/Listar");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}