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
                //Integrated Security: Autenticacao pelo Windows
                //TrustServerCertificate: Autenticacao pelo Windows

                //string de conexao
                optionsBuilder.UseSqlServer("Data Source = initial catalog = projetoGamer; Integrated Security = true; TrustServerCertificate = true");
            }
        }

        public DbSet<Jogador> jogador {get; set;}
        public DbSet<Equipe> Equipe {get; set;}
    }
}