using DiabloII_Cookbook.Api.DataTransferObjects;

namespace DiabloII_Cookbook.Client.Models
{
    public class Filter
    {
        public bool Selected { get; set; }
        public ItemType ItemType { get; }

        public Filter(ItemType itemType)
        {
            ItemType = itemType;
        }
    }
}
