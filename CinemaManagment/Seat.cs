using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagment
{
    internal class Seat
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int MovieId { get; set; }

        public Status Status { get; set; } = Status.Empty;
    }
    enum Status
    {
        Empty,
        Reserved
    }
}
