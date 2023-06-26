using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagment
{
    internal class Ticket
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public Ticket(string firstname,string lastname,int row,int column)
        {
            FirstName = firstname;
            LastName = lastname;
            Row = row;
            Column = column;
        } 
        
    }
}
