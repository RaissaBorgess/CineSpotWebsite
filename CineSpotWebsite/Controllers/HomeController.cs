using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineSpotWebsite.Models;
using System.Text.Json;

namespace CineSpotWebsite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Filme> filmes = GetFilmes();
        List<Genero> generos = GetGeneros();
        ViewData["Generos"] = generos;
        return View(filmes);
    }

    public IActionResult Details(int id)
    {
        List<Filme> filmes = GetFilmes();
        List<Genero> generos =GetGeneros();
        DetailsVM details = new() {
        Generos = generos,
        Atual = filmes.FirstOrDefault( p => p.Numero == id),
        Anterior = filmes.OrderByDescending( p => p.Numero).FirstOrDefault(p => p.Numero < id),
        Proximo = filmes.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id),
        };
        return View(details);
    }

    private List<Filme> GetFilmes()
    {
        using (StreamReader leitor = new("Data\\filmes.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Filme>>(dados);
        }
}

    private List<Genero> GetGeneros() 
    {
    using (StreamReader leitor = new("Data\\generos.json"))
    {
        string dados = leitor.ReadToEnd();
        return JsonSerializer.Deserialize<List<Genero>>(dados);
    }
}

    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

