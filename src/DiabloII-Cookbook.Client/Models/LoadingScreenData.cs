using System;

namespace DiabloII_Cookbook.Client.Models
{
    public class LoadingScreenData
    {
        public string Name { get; }
        public string Quote { get; }
        
        public LoadingScreenData(string name, string quote)
        {
            Name = name;
            Quote = quote;
        }
    }
}
