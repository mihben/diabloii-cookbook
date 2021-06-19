using DiabloII_Cookbook.Client.Models;

namespace DiabloII_Cookbook.Client.Extensions
{
    public static class LoadingScreenDataExtensions
    {
        public static string GetImage(this LoadingScreenData data)
        {
            return $"/assets/classic/loading-screen/{data.Name}.gif";
        }
    }
}
