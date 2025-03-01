using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MicroEngine.Framework.Commons
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class BaseModel { }
}
