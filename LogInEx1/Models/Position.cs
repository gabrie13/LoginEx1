using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LogInEx1.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        public string PositionTitle { get; set; }
    }
}