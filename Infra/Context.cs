using Microsoft.EntityFrameworkCore;
using ProjetoGamer_Banco_de_dados.Models;

namespace ProjetoGamer_Banco_de_dados.Infra
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string de conexao com o banco
                //Data Source: o nome do servidor do gerenciador do banco
                //initial catalog: nome do banco de dados
               
                //AUTENTICAÇÃO PELO WINDOWS
                //integrated security == Autenticação pelo windows
                //TrustServerCertificate == Autenticação pelo windows 

                //AUTENTICAÇÃO PELO SQLSERVER
                //user Id = "nome do usuário de login do banco de dados"
                //pwd = "nome da senha do banco de dados"

                //string de conexao
                optionsBuilder.UseSqlServer("Data Source = NOTE12-S14; Initial Catalog = GamerManha; User Id = sa; pwd = Senai@134; TrustServerCertificate = true");
            }
        }

        public DbSet<Jogador> Jogador {get; set;}
        public DbSet<Equipe> Equipe {get; set;}
    }
}