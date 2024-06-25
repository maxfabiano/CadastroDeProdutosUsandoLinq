using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace CadastroDeProdutos.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetProdutosAsync(string filial)
        {
            var response = await _httpClient.GetAsync($"/api/getProduto/{filial}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetClientesAsync(string codfil)
        {
            var response = await _httpClient.GetAsync($"/api/getCliente/{codfil}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // Adicione métodos para outras chamadas de API conforme necessário
    }

}
