using System;

namespace TransportationProblem.Models
{
    public class Boat : Transportation
    {
        public Boat() { }

        public Boat(Transportation model)
        {
            this.Name = model.Name;
            this.TransportType = enums.TransportTypes.Boat;
            this.ModeOfTransport = model.ModeOfTransport;
            this.PowerSource = model.PowerSource;
            this.Capacity = new Models.CapacityModel();
            this.Capacity.Count = model.Capacity.Count;
            this.Capacity.Type = model.Capacity.Type;
            this.Capacity.Unit = model.Capacity.Unit;
        }
        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Transport()
        {
            throw new NotImplementedException();
        }

        public override void Unload()
        {
            throw new NotImplementedException();
        }
    }
}