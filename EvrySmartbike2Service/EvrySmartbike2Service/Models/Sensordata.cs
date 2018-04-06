using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EvrySmartbike2Service.Models
{
    public class Sensordata
    {
        public Guid Id { get; set; }
        [Required]
        public Guid SensorID { get; set; }

        public Guid BicycleTourID { get; set; }
        public double Humidity { get; set; }
        public double AtmospherePressure { get; set; }
        public DateTime Timestamp { get; set; }
        public double AccelerationX { get; set; }
        public double AccelerationY { get; set; }
        public double AccelerationZ { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}