namespace CineSpotWebsite.Models
{
    public class Filme
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
         public List<string> Generos  { get; set; } = [];
         public string Sinopse { get; set; }
         public double Duracao { get; set; }
         public double Ano { get; set; }
         public string Imagem { get; set; }
        
        
        
    }
}