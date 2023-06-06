using System.Text.Json;
using System.Text.Json.Serialization;

namespace UniversityApi.Constants;

public class JsonConstant
{
    public static JsonSerializerOptions jsonSerializerOptions
    {
        get
        {
            return new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
            };
        }
    }
}