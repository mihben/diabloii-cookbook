using Microsoft.AspNetCore.Http;
using Netension.Request.Abstraction.Requests;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.IntegrationTest.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostAsync<TCommand>(this HttpClient client, PathString path, TCommand command, Guid correlationId)
            where TCommand : ICommand
        {
            return await client.PostAsync(path, command, correlationId, TimeSpan.FromSeconds(5));
        }

        public static async Task<HttpResponseMessage> PostAsync<TCommand>(this HttpClient client, PathString path, TCommand command, Guid correlationId, TimeSpan timeout)
            where TCommand : ICommand
        {
            var content = JsonContent.Create(command);
            content.Headers.SetCorrelationId(correlationId);
            content.Headers.SetMessageType(command);

            return await client.PostAsync(path, content, new CancellationTokenSource(timeout).Token);
        }
    }
}
