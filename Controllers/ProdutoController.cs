using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using CadastroDeProdutos.Service;

namespace CadastroDeProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApiService _apiService;

        public ProdutoController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var produtosJson = await _apiService.GetProdutosAsync("your-filial");
            var produtos = JsonConvert.DeserializeObject<List<Produto>>(produtosJson);
            return View(produtos);
        }
    }

}
