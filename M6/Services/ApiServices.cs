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

    public async Task<bool> CreatePartnerAsync(
    Partner partner)
    {
        var response =
            await _client.PostAsJsonAsync(
                "api/Partners",
                partner);

        if (!response.IsSuccessStatusCode)
        {
            var error =
                await response.Content.ReadAsStringAsync();

            throw new Exception(error);
        }

        return true;
    }

    public async Task<bool> UpdatePartnerAsync(
    Partner partner)
    {
        var response =
            await _client.PutAsJsonAsync(
                $"api/Partners/{partner.IdPartner}",
                partner);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeletePartnerAsync(
    int id)
    {
        var response =
            await _client.DeleteAsync(
                $"api/Partners/{id}");

        if (!response.IsSuccessStatusCode)
        {
            var error =
                await response.Content.ReadAsStringAsync();

            throw new Exception(error);
        }

        return true;
    }
}