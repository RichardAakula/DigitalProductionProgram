
namespace DigitalProductionProgram.Monitor.GET
{
    public class Common
    {
        internal class Units : DTO
        {
            public override string URL => "Common/Units";

            public string Code { get; set; } //Enhet
        }

        internal class PartUnitUsages : DTO
        {
            public override string URL => "Common/PartUnitUsages";

            public long UnitId { get; set; }
        }

        internal class Departments : DTO
        {
            public override string URL => "Common/Departments";

            public string Description { get; set; }     //Avdelning
        }

        internal class FormTemplateSelectionRows : DTO
        {
            public override string URL => "Common/FormTemplateSelectionRows";

            public long Id { get; set; }
        }

        internal class FormTemplates : DTO
        {
            public override string URL => "Common/FormTemplates";

            public string Code { get; set; }
            public string Comment { get; set; }
            public string Description { get; set; }
        }
        internal class FormTemplateRows : DTO
        {
            public override string URL => "Common/FormTemplateRows";

            public string Description { get; set; }
            public double? MinValue { get; set; }
            public double? LowerBoundary { get; set; }
            public double? Value { get; set; }
            public double? UpperBoundary { get; set; }
            public double? MaxValue { get; set; }

        }

        internal class MeasuringTemplates : DTO
        {
            public override string URL => "Common/MeasuringTemplates";

            public long FormTemplateId { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }

        }
        internal class Persons : DTO
        {
            public override string URL => "Common/Persons";

            public string EmailAddress { get; set; }
            public int EmployeeNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Initials { get; set; }
        }
    }
}