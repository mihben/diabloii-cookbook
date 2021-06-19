namespace DiabloII_Cookbook.Client.Models
{
    public class SelectModel<TItem>
    {
        public bool Selected { get; set; }
        public TItem Item { get; }

        public SelectModel(TItem item)
        {
            Item = item;
        }
    }
}
