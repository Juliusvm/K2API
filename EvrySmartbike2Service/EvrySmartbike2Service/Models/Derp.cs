using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EvrySmartbike2Service.Models
{
    public class Derp
    {
        
            public int ID { get; set; }
            [Required]
            public int Value { get; set; }

    }
}
