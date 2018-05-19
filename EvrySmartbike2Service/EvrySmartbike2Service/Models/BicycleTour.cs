using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EvrySmartbike2Service.Models
{
    public class BicycleTour
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public String SensorID { get; set;}
        [Required]
        public Guid EmployeeID { get; set; }
        [Required]
        public double AverageSpeed { get; set; }
        public double CarbonDioxide { get; set; }
        public double CaloriesBurnt { get; set; }
        public double Distance { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }

    }
}
