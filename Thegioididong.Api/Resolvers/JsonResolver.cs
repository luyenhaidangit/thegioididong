using Newtonsoft.Json.Serialization;

namespace Thegioididong.Api.Resolvers
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
