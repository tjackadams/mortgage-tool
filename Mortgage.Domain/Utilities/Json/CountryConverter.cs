namespace Mortgage.Domain.Utilities.Json
{
    using System;
    using Lenders;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class CountryConverter : JsonConverter<Country>
    {
        public override void WriteJson(JsonWriter writer, Country value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override Country ReadJson(JsonReader reader, Type objectType, Country existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            return Country.Create(jsonObject["id"].Value<string>(), jsonObject["code"].Value<string>());
        }
    }
}
