using System.Text.Json.Serialization;

namespace ExampleWebApiCRUD.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Genders
    {
        Male,
        Female
    }
}
