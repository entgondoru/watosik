using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Threading.Tasks;

namespace Watosik.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ILogger<ChatController> _logger;
        private readonly string _apiKey;

        public ChatController(ILogger<ChatController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _apiKey = configuration["OpenAI:ApiKey"];
        }

        [HttpPost]
        [Route("chatgpt")]
        public async Task<IActionResult> GetChatGPTResponse([FromBody] ChatRequest request)
        {
            _logger.LogInformation("Received request with prompt: {Prompt}", request.Prompt);

            if (string.IsNullOrWhiteSpace(request.Prompt))
            {
                _logger.LogWarning("Received empty prompt.");
                return BadRequest(new { response = "Zapytanie nie może być puste." });
            }

            try
            {
                var openAiClient = new HttpClient
                {
                    BaseAddress = new Uri("https://api.openai.com/v1/")
                };
                openAiClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

                var payload = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new { role = "user", content = request.Prompt }
                    }
                };

                _logger.LogInformation("Sending request to OpenAI API... Payload: {Payload}", JsonSerializer.Serialize(payload));

                var response = await SendRequestWithRetries(openAiClient, payload);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("OpenAI API responded with status code: {StatusCode}", response.StatusCode);
                    return StatusCode((int)response.StatusCode, new { response = "Błąd komunikacji z OpenAI API." });
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Received response from OpenAI API: {Response}", jsonResponse);

                var chatResponse = JsonDocument.Parse(jsonResponse);
                var message = chatResponse.RootElement
                                           .GetProperty("choices")[0]
                                           .GetProperty("message")
                                           .GetProperty("content")
                                           .GetString();

                _logger.LogInformation("Extracted message: {Message}", message);

                return Ok(new { response = message });
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred: {ExceptionMessage}", ex.Message);
                return StatusCode(500, new { response = $"Wystąpił błąd: {ex.Message}" });
            }
        }

        private async Task<HttpResponseMessage> SendRequestWithRetries(HttpClient client, object payload, int retries = 3, int initialDelayInSeconds = 2)
        {
            int delay = initialDelayInSeconds;

            for (int i = 0; i < retries; i++)
            {
                var response = await client.PostAsJsonAsync("chat/completions", payload);

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                _logger.LogWarning("Response content: {ResponseContent}", jsonResponse);

                if (response.StatusCode != System.Net.HttpStatusCode.TooManyRequests)
                {
                    _logger.LogError("Unexpected error: {StatusCode}", response.StatusCode);
                    return response;
                }

                _logger.LogWarning("Rate limit exceeded. Retrying in {Delay} seconds...", delay);
                await Task.Delay(delay * 1000);
                delay *= 2; // Exponentially increase delay for each retry
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.TooManyRequests);
        }

    }

    public class ChatRequest
    {
        public string Prompt { get; set; }
    }
}
