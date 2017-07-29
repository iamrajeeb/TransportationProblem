using System.ComponentModel.DataAnnotations;
using TransportationProblem.enums;

namespace TransportationProblem.Models
{

    public abstract class Transportation
    {
        public Transportation()
        {
            Capacity = new CapacityModel();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Transport Type")]
        public TransportTypes TransportType { get; set; }
        [Display(Name = "Mode Of Transport")]
        public TransportModes ModeOfTransport { get; set; }
        [Display(Name = "Power Source")]
        public PowerSources PowerSource { get; set; }

        public CapacityModel Capacity { get; set; }
        public bool isEdit { get; set; }

        public abstract void Load();
        public abstract void Transport();
        public abstract void Unload();

    }

}