namespace DALGenericTemplate.Core.Utils.Attributes
{
    public class ProviderAttribute : Attribute
    {
        public string Name { get; set; }
        public ProviderAttribute(string name)
        {
            this.Name = name;
        }
    }
}
