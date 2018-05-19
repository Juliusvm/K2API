﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EvrySmartbike2Service.Models
{
    public class Sensor
    {
        [Key]
        public String SensorID { get; set; }
        [Required]
        public string Information { get; set; }
        public int BicycleNumber { get; set; }

    }
}
