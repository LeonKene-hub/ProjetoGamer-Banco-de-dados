using System.ComponentModel.DataAnnotations;

namespace ProjetoGamer_Banco_de_dados.Models
{
    public class Equipe
    {
        [Key]
        public int IdEquipe { get; set; }
        public string? Nome { get; set; }
        public string? Imagem { get; set; }

        //referencia que a classe equipe vai ter acesso a collection "jogador"
        public ICollection<Jogador>? Jogador {get; set;}
    }
}