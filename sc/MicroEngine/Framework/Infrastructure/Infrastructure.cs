using System.Text;
using System.Text.Json;

namespace MicroEngine.Framework.Infrastructure
{
    public class BaseSingleton
    {
        public static IDictionary<Type, object> AllSingletons { get; }

        static BaseSingleton()
        {
            AllSingletons = new Dictionary<Type, object>();
        }
    }

    public class Singleton<T> : BaseSingleton
    {
        private static T instance;
        public static T Instance
        {
            get { return instance; }
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }

    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            var result = new StringBuilder();
            result.Append(char.ToLower(name[0]));

            for (var i = 1; i < name.Length; i++)
            {
                if (char.IsUpper(name[i]))
                {
                    result.Append('_');
                    result.Append(char.ToLower(name[i]));
                }
                else
                {
                    result.Append(name[i]);
                }
            }

            return result.ToString();
        }
    }
}
