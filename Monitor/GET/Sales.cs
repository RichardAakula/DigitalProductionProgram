using System.Text.Json.Serialization;

namespace DigitalProductionProgram.Monitor.GET
{
    public abstract class Sales
    {
        internal class Customers : DTO
        {
            [JsonIgnore]
            public override string URL => "Sales/Customers";

            public long Id { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("url")]
            public string Url { get; set; }
        }


        internal class CustomerPartLinks : DTO
        {
            public override string URL => "Sales/CustomerPartLinks";

            public long Id { get; set; }
            public long CustomerId { get; set; }
            public string CustomerPartNumber { get; set; }
        }
    }
}