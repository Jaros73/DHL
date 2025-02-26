using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DHL.Pages;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public string Title { get; set; } = "Vítejte";
    public string Subtitle { get; set; } = "Dočasná domovská obrazovka.";

    public IndexModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

   /* public async Task OnGet()
    {
        // Fetch authentication status from API
        var response = await _httpClient.GetAsync("/authentication/status");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            Title = json["title"]?.ToString() ?? "Vítejte";
            Subtitle = json["subtitle"]?.ToString() ?? "Dočasná domovská obrazovka.";
        }
    }*/
}
