using TransportationProblem.enums;

namespace TransportationProblem.Models
{
    public class CapacityModel
    {
        public int Count { get; set; }
        public UnitEnum Unit { get; set; }
        public TypeEnum Type { get; set; }
    }
}