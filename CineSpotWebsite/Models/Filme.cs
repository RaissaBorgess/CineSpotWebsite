namespace CineSpotWebsite.Models
{
    public class Filmes
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
         public List<string> Gênero  { get; set; } = [];
         public string Sinopse { get; set; }
         public double Duração { get; set; }
         public double Ano { get; set; }
         public string Imagem { get; set; }
        
        
        
    }
}