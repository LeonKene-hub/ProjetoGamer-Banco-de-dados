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
    public class JogadorController : Controller
    {
        private readonly ILogger<JogadorController> _logger;

        public JogadorController(ILogger<JogadorController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Context c = new Context();

        [Route("Listar")] //http:localhost/Jogador/Listar
        public IActionResult Index()
        {
            ViewBag.Jogador = c.Jogador.ToList();
            ViewBag.Equipe = c.Equipe.ToList();

            return View();
        }

        [Route("Cadastrar")] //http:localhost/Jogador/Cadastrar
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();

            novoJogador.Nome = form["Nome"].ToString();
            novoJogador.Email = form["Email"].ToString();
            novoJogador.Senha = form["Senha"].ToString();

            string nomeEquipe = form["Equipe"].ToString();

            novoJogador.Equipe = c.Equipe.First(x => x.Nome == nomeEquipe);
            novoJogador.IdEquipe = novoJogador.Equipe.IdEquipe;

            c.Jogador.Add(novoJogador);
            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Excluir{id}")] //http://localhost/Jogador/Excluir
        public IActionResult Excluir(int id)
        {
            Jogador jogadorEncontrado = c.Jogador.First(e => e.IdJogador == id);

            c.Remove(jogadorEncontrado);
            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Editar{id}")] //http://localhost/Jogador/Editar
        public IActionResult Editar(int id)
        {
            Jogador jogadorBuscado = c.Jogador.First(e => e.IdJogador == id);
            ViewBag.Jogador = jogadorBuscado;
            ViewBag.Equipe = c.Equipe.ToList();

            return View("Edit");
        }

        [Route("Atualizar")] //http://localhost/Jogador/Atualizar
        public IActionResult Atualizar(IFormCollection form)
        {
            Jogador jogador = new Jogador();
            jogador.IdJogador = int.Parse(form["IdJogador"]);

            jogador.Nome = form["Nome"];
            jogador.Email = form["Email"];
            jogador.Senha = form["Senha"];

            string nomeEquipe = form["Equipe"].ToString();

            jogador.Equipe = c.Equipe.First(x => x.Nome == nomeEquipe);
            jogador.IdEquipe = jogador.Equipe.IdEquipe;

            Jogador editado = c.Jogador.First(j => j.IdJogador == jogador.IdJogador);
            editado.Nome = jogador.Nome;
            editado.Senha = jogador.Senha;
            editado.Email = jogador.Email;
            editado.IdEquipe = jogador.IdEquipe;
            editado.Equipe = jogador.Equipe;

            c.Jogador.Update(editado);
            c.SaveChanges();
            return LocalRedirect("~/Jogador/Listar");
        }


    }
}