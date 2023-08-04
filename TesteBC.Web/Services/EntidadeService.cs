using Newtonsoft.Json;
using System.Text;
//using System.Text;
using TesteBC.Web.Models;
using TesteBC.Web.Services.Interfaces;

namespace TesteBC.Web.Services
{
    public class EntidadeService : IEntidadeService
    {
        private readonly HttpClient _httpClient;
        public EntidadeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<APIResponse<EntidadeModel>?> Adiciona(EntidadeModel obj)
        {
            var serializedContent = JsonConvert.SerializeObject(obj);
            HttpContent httpContent = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"Entidade", httpContent);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<APIResponse<EntidadeModel>>(responseString);
        }

        public async Task<APIResponse<EntidadeModel>?> Atualiza(EntidadeModel obj)
        {
            var serializedContent = JsonConvert.SerializeObject(obj);
            HttpContent httpContent = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"Entidade/" + obj.idEntidade, httpContent);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<APIResponse<EntidadeModel>>(responseString);
        }

        public async Task<APIResponse<EntidadeModel>?> BuscaEntidade(Guid id)
        {
            var response = await _httpClient.GetAsync($"Entidade/" + id.ToString());

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            StreamReader reader = new StreamReader(responseStream);

            return JsonConvert.DeserializeObject<APIResponse<EntidadeModel>>(reader.ReadToEnd());
        }

        public Task<APIResponse<EntidadeModel>?> BuscaEntidadePorDocumento(string documento)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<IEnumerable<EntidadeModel>>?> BuscaTodos()
        {
            var response = await _httpClient.GetAsync($"Entidade");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            StreamReader reader = new StreamReader(responseStream);
            string responseString = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<APIResponse<IEnumerable<EntidadeModel>>>(responseString);
        }

        public async Task<APIResponse<EntidadeModel>?> Remove(EntidadeModel obj)
        {
            var serializedContent = JsonConvert.SerializeObject(obj);
            HttpContent httpContent = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.DeleteAsync($"Entidade/" + obj.idEntidade);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<APIResponse<EntidadeModel>>(responseString);
        }
    }
}
