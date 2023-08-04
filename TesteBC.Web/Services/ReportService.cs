using Newtonsoft.Json;
using System.Net.Http;
using TesteBC.Web.Models;
using TesteBC.Web.Models.Report;
using TesteBC.Web.Services.Interfaces;

namespace TesteBC.Web.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;
        public ReportService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<APIResponse<IEnumerable<LancamentoDiarioReportResult>>> GetReportLancamentoDiarios(DateTime date)
        {
            var response = await _httpClient.GetAsync($"Report?dtLanctos=" + date.ToString("yyyy-MM-dd"));

            //response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            StreamReader reader = new StreamReader(responseStream);

            return JsonConvert.DeserializeObject<APIResponse<IEnumerable<LancamentoDiarioReportResult>?>>(reader.ReadToEnd());
        }
    }
}
