using System.Net.Http.Json;
using M6.Models;

namespace M6.Services;

public class ApiService
{
    private readonly HttpClient _client =
        new();

    public ApiService()
    {
        _client.BaseAddress =
            new Uri(
                "http://localhost:5222/");
    }

    public async Task<List<Partner>>
        GetPartners()
    {
        return await _client
            .GetFromJsonAsync<List<Partner>>(
                "api/Partners")
            ?? new List<Partner>();
    }
}