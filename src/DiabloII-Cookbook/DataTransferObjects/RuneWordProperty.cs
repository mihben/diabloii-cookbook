namespace DiabloII_Cookbook.Api.DataTransferObjects
{
    public class RuneWordProperty
    {
        public string Description { get; }
        public Skill Skill { get; }

        public RuneWordProperty(string description, Skill skill)
        {
            Description = description;
            Skill = skill;
        }
    }
}
