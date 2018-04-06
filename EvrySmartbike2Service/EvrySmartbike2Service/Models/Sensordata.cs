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
        public string SensorId { get; set; }
        public string Payload { get; set; }
        public DateTime Timestamp { get; set; }
        
    }
    //public class Sensordata
    //{
    //    public Guid Id { get; set; }
    //    public string Payload { get; set; }
    //    public DateTime Timestamp { get; set; }

    //}

}