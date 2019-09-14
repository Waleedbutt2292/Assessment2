using System;
using System.Collections.Generic;

namespace Airline1.Models
{
    public partial class Flight
    {
        public int Id { get; set; }
        public int? AirlilneId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime? DepartialDateTime { get; set; }
        public DateTime? ArrivalDateTime { get; set; }
    }
}
