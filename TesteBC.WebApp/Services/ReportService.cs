using System.Net.Http;
using TesteBC.WebApp.Models.Report;
using TesteBC.WebApp.Services.Interfaces;

namespace TesteBC.WebApp.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;
        public  async Task<IEnumerable<LancamentoDiarioReportResult>> GetReportLancamentoDiarios(DateTime date)
        {
            var response = await _httpClient.GetAsync($"Report?dtLanctos=" + date.ToString("yyyy-MM-dd"));

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            StreamReader reader = new StreamReader(responseStream);
            string responseString = reader.ReadToEnd();

            return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<LancamentoDiarioReportResult>>(responseString);
        }
    }
}
