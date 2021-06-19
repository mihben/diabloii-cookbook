using Netension.Request.Abstraction.Requests;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddMessageType(this HttpClient client, string messageType)
        {
            client.DefaultRequestHeaders.Remove("Message-Type");
            client.DefaultRequestHeaders.Add("Message-Type", messageType);
        }

        public static async Task<TResponse> QueryAsync<TQuery, TResponse>(this HttpClient client, TQuery query, CancellationToken cancellationToken)
            where TQuery : IQuery<TResponse>
        {
            client.AddMessageType(query.MessageType);
            System.Console.WriteLine(query);
            System.Console.WriteLine(JsonSerializer.Serialize(query));
            using var response = await client.PostAsJsonAsync("api", query, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.Never, IgnoreReadOnlyProperties = false }, cancellationToken);
            return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);
        }

        public static async Task SendAsync<TCommand>(this HttpClient client, TCommand command, CancellationToken cancellationToken)
            where TCommand : ICommand
        {
            client.AddMessageType(command.MessageType);
            using var response = await client.PostAsJsonAsync("api", command, cancellationToken);
        }
    }
}
