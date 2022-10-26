using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class AwardHttpClient : IAwardService
{
    private HttpClient client;

    public AwardHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<Award> Create(AwardCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Awards/allAwards", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Award award = JsonSerializer.Deserialize<Award>(result)!;
        return award;
    }

    public async Task<IEnumerable<Award>> GetAll()
    {
        HttpResponseMessage response = await client.GetAsync("/Awards/allAwards");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Award> awards = JsonSerializer.Deserialize<IEnumerable<Award>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        foreach (var award in awards)
        {
            Console.WriteLine(award.Name);
        }
        return awards;
    }
    
    public async Task<Award> AwardPost(AwardToPostDto dto)
    {
        JsonContent json = JsonContent.Create(dto);
        HttpResponseMessage response = await client.PatchAsync("/Awards/awardPost", json);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Award award = JsonSerializer.Deserialize<Award>(result)!;
        return award;
    }
}