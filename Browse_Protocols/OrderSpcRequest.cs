using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalProductionProgram.Browse_Protocols
{
    public class OrderSpcRequest
    {
        public int? ProtocolDescriptionId { get; set; }
        public string ParameterName { get; }
        public double? Min { get; }
        public double? Nom { get; }
        public double? Max { get; }
        public List<string> OrderNumbers { get; }

        public OrderSpcRequest(int? protocolDescriptionId, string parameterName, double? min, double? nom, double? max, List<string> orderNumbers)
        {
            ProtocolDescriptionId = protocolDescriptionId;
            ParameterName = parameterName;
            Min = min;
            Nom = nom;
            Max = max;
            OrderNumbers = orderNumbers ?? new List<string>();
        }
    }
}
