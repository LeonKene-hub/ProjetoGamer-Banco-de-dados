using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGamer_Banco_de_dados.Models
{
    public class Jogador
    {
        [Key] //DataAnnotations
        public int IdJogador { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        [ForeignKey("Equipe")]
        public int IdEquipe { get; set; }
    }
}