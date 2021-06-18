using Netension.Request.Abstraction.Requests;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddMessageType(this HttpClient client, string messageType)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("message-type", messageType);
        }

        public static async Task<TResponse> QueryAsync<TResponse>(this HttpClient client, IQuery<TResponse> query, CancellationToken cancellationToken)
        {
            client.AddMessageType(query.MessageType);
            var response = await client.PostAsJsonAsync("api", query, cancellationToken);
            return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);
        }

        public static async Task SendAsync<TCommand>(this HttpClient client, TCommand command, CancellationToken cancellationToken)
            where TCommand : ICommand
        {
            client.AddMessageType(command.MessageType);
            await client.PostAsJsonAsync("api", command, cancellationToken);
        }
    }
}
