using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class UsuarioServiceClient
{
    private readonly HttpClient _httpClient;

    public UsuarioServiceClient(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("UsuarioService");
    }

    public async Task<string> GetUsuarioByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/{id}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var user = JsonSerializer.Deserialize<UserResponse>(content);

        return user?.Name;
    }
}

public class UserResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
