using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CadastroProdutos.Request
{
    [Route("/api/")]
    [ApiController]
    public class Resposta : ControllerBase
    {
        public Resposta( ) { }
        [HttpGet("getProduto")]
        public async Task<IActionResult> executeAsync(object json)
        {
            var con = new Context();

            var Produtos = await con.Produtos.ToListAsync();
            return Ok(Produtos);
        }
    }
}
