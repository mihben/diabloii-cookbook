using DiabloII_Cookbook.Api.DataTransferObjects;
using System.ComponentModel;

namespace DiabloII_Cookbook.Client.Models
{
    public class Filter
    {
        private bool _selected;

        public bool Selected { get { return _selected; } set { _selected = value; System.Console.WriteLine("Setted selected"); } }
        public ItemType ItemType { get; }

        public Filter(ItemType itemType)
        {
            ItemType = itemType;
        }
    }
}
