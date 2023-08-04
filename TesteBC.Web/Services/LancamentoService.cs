using Newtonsoft.Json;
using System.Text;
using TesteBC.Web.Models;
using TesteBC.Web.Services.Interfaces;

namespace TesteBC.Web.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly HttpClient _httpClient;
        public LancamentoService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<APIResponse<LancamentoModel>?> Adiciona(LancamentoModel obj)
        {
            var serializedContent = JsonConvert.SerializeObject(obj);
            HttpContent httpContent = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"Lancamento", httpContent);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<APIResponse<LancamentoModel>>(responseString);
        }

        public async Task<APIResponse<LancamentoModel>?> Atualiza(LancamentoModel obj)
        {
            var serializedContent = JsonConvert.SerializeObject(obj);
            HttpContent httpContent = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"Lancamento/" + obj.idLancamento, httpContent);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<APIResponse<LancamentoModel>>(responseString);
        }

        public async Task<APIResponse<LancamentoModel>?> BuscaLancamento(Guid id)
        {
            var response = await _httpClient.GetAsync($"Lancamento/" + id.ToString());

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            StreamReader reader = new StreamReader(responseStream);

            return JsonConvert.DeserializeObject<APIResponse<LancamentoModel>>(reader.ReadToEnd());
        }

        public async Task<APIResponse<IEnumerable<LancamentoModel>?>> BuscaTodos()
        {
            var response = await _httpClient.GetAsync($"Lancamento");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            StreamReader reader = new StreamReader(responseStream);

            return JsonConvert.DeserializeObject<APIResponse<IEnumerable<LancamentoModel>?>>(reader.ReadToEnd());
        }

        public async Task<APIResponse<LancamentoModel>?> Remove(LancamentoModel obj)
        {
            var serializedContent = JsonConvert.SerializeObject(obj);
            HttpContent httpContent = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.DeleteAsync($"Lancamento/" + obj.idLancamento);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<APIResponse<LancamentoModel>?>(responseString);
        }
    }
}
