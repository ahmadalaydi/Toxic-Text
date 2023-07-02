using Detect_Toxic_Text.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Detect_Toxic_Text.Services;
public class Search : IApiClient
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "8e3bfbfb-d6c0-473f-bfc9-7483e2bf6697";
    private const string BaseUrl = "https://predict.cogniflow.ai/text/classification/predict/489190f2-54b0-11ec-bc13-a617fadca25c";

    public Search(HttpClient httpClient)
    => _httpClient = httpClient;

    public async Task<Response> PostAsync(string text)
    {
        using var request = new HttpRequestMessage(new HttpMethod("POST"), BaseUrl);
        request.Headers.TryAddWithoutValidation("accept", "application/json");
        request.Headers.TryAddWithoutValidation("x-api-key", ApiKey);

        request.Content = new StringContent("{\"text\":\"" + text + "\"}");
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

        var response = await _httpClient.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<Response>(responseContent)!;
    }
}