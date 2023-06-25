using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagment
{
    internal class Hall
    {
        private static int _id;
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Name { get; set; }

        public Seat[,] seats = { };
        public List<Movie> Movies = new List<Movie>();
        public Hall(string name, int row, int column)
        {
            Id = ++_id;
            Name = name;
            Row = row;
            Column = column;
            seats = new Seat[Row, Column];
        }
    }
}
