using System;
using System.ComponentModel.DataAnnotations;

namespace DiabloII_Cookbook.Client.Options
{
    public class HttpClientOptions
    {
        [Required]
        public string BaseAddress { get; set; }
    }
}
