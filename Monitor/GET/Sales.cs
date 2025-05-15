namespace DigitalProductionProgram.Monitor.GET
{
    public class Sales
    {
        internal class Customers : DTO
        {
            public override string URL => "Sales/Customers";

            public long Id { get; set; } //Kundens ID
            public string? Name { get; set; } //KundNamn
            public string Url { get; set; } //Kundens WebAdress
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