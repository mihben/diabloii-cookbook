namespace DiabloII_Cookbook.Api.DataTransferObjects
{
    public class Skill
    {
        public string Name { get; }
        public string Class { get; }
        public string Description { get; }

        public Skill(string name, string @class, string description)
        {
            Name = name;
            Class = @class;
            Description = description;
        }
    }
}
