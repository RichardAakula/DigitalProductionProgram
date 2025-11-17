using DigitalProductionProgram.Monitor.Services;
using System;

namespace DigitalProductionProgram.Monitor.GET
{
    public class Manufacturing
    {
        internal class ManufacturingOrderMaterials : DTO
        {
            public override string URL => "Manufacturing/ManufacturingOrderMaterials";

            public long PartId { get; set; }
            public string ManufacturingOrderId { get; set; }
        }

        internal class ManufacturingOrders : DTO
        {
            public override string URL => "Manufacturing/ManufacturingOrders";


            public long Id { get; set; }
            public string? OrderNumber { get; set; }
            public long? CustomerId { get; set; }
            public string Status { get; set; }
            public string PartId { get; set; }
            public string Part { get; set; }
            public string StartDate { get; set; }

            public decimal PlannedQuantity { get; set; }
            public decimal RestQuantity { get; set; }
            public decimal ReportedQuantity { get; set; }
        }

        internal class ManufacturingOrderOperations : DTO
        {
            public override string URL => "Manufacturing/ManufacturingOrderOperations";

            public long Id { get; set; }
            public string? Description { get; set; }
            public int? Priority { get; set; }
            public long PartId { get; set; }
            public decimal PlannedQuantity { get; set; }
            public decimal ReportedQuantity { get; set; }
            public decimal RestQuantity { get; set; }
            public long PlannedUnitTime { get; set; }
            public long ManufacturingOrderId { get; set; }
            public int OperationNumber { get; set; }
            public DateTimeOffset PlannedStartDate { get; set; }
            public DateTimeOffset PlannedFinishDate { get; set; }
            public long WorkCenterId { get; set; }

        }

        internal class ManufacturingOrderOperationControlDataRows : DTO
        {
            public override string URL => "Manufacturing/ManufacturingOrderOperationControlDataRows";

            public long OverridenFormTemplateId { get; set; }


        }

        internal class WorkCenters : DTO, ToolService.IHasId
        {
            public override string URL => "Manufacturing/WorkCenters";
            public long Id { get; set; }
            public string Number { get; set; }
            public string Description { get; set; }
            public string DepartmentId { get; set; }
        }

        internal class OperationRows : DTO
        {
            /// ProdGrupp
            public override string URL => "Manufacturing/OperationRows";

            public long OperationNumber { get; set; }
            public string Description { get; set; }
            public string WorkCenterId { get; set; }
        }
    }
}
