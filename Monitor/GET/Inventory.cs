using System;
using System.Windows.Forms;

namespace DigitalProductionProgram.Monitor.GET
{
    public class Inventory
    {
        internal class PartLocations : DTO
        {
            //Artikel ID, ArtikelNr
            public override string URL => "Inventory/PartLocations";

            public long Id { get; set; }
            public string SerialNumber { get; set; } //Serienummer
            public string BatchNumber { get; set; } //LotNr
            public decimal Balance { get; set; } //Saldo
            public string Name { get; set; }
        }

        internal class Parts : DTO
        {
            public override string URL => "Inventory/Parts";


            public long Id { get; set; }
            public string? PartNumber { get; set; }
            public string? Description { get; set; }
            public string ExtraDescription { get; set; }
            public decimal StandardPrice { get; set; }
            public long StandardUnitId { get; set; }
        }

        internal class ProductRecords : DTO
        {
            public override string URL => "Inventory/ProductRecords";

            public long Id { get; set; }
            public string SerialNumber { get; set; }    //LotNr
            public string BestBeforeDate { get; set; }
        }

        internal class PartLocationProductRecords : DTO
        {
            public override string URL => "Inventory/PartLocationProductRecords";

            public long PartLocationId { get; set; }
            public long? ProductRecordId { get; set; }
            public decimal Quantity { get; set; }
        }
    }
}