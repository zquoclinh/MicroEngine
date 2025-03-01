using MicroEngine.Framework.Commons;

namespace MicroEngine.Framework.Entity
{
    public class Setting : BaseEntity
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public Setting() { }

        public Setting(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
