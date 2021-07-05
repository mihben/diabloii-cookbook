using DiabloII_Cookbook.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Extensions
{
    public static class JSObjetReferenceExtensions
    {
        public static async Task<Dimensions> GetDimensions(this IJSObjectReference reference)
        {
            return await reference.InvokeAsync<Dimensions>("getScreenDimensions").ConfigureAwait(false);
        }

        public static async Task<Dimensions> GetDimensions(this IJSObjectReference reference, ElementReference element)
        {
            return await reference.InvokeAsync<Dimensions>("getDimensions", element).ConfigureAwait(false);
        }
    }
}
