using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalProductionProgram.Browse_Protocols
{
    public record OrderInfo(int OrderID, string OrderNumber, string RevNr, string ProdLine, string ProdType, DateTime Date)
    {
        public override string ToString() => $"{OrderNumber} - {RevNr} - {ProdLine}";
    }

    public class OrderSpcRequest
    {
        public int? ProtocolDescriptionId { get; set; }
        public string ParameterName { get; }
        public double? Min { get; }
        public double? Nom { get; }
        public double? Max { get; }
        public List<OrderInfo> Orders { get; }


        public OrderSpcRequest(int? protocolDescriptionId, string parameterName, double? min, double? nom, double? max, List<OrderInfo>? orders)
        {
            ProtocolDescriptionId = protocolDescriptionId;
            ParameterName = parameterName;
            Min = min;
            Nom = nom;
            Max = max;
            Orders = orders ?? new List<OrderInfo>();
        }
    }
}
