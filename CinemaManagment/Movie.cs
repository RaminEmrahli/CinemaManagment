using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagment
{
    internal class Movie
    {
        private static int _id;
        public int Id { get; set; }
        public string Name { get; set; }
        public double IMDB { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public List<Ticket> Tickets = new List<Ticket>();
        public Movie(string name, double imdb, TimeOnly startTime, TimeOnly endTime)
        {
            Id = ++_id;
            Name = name;
            IMDB = imdb;
            StartTime = startTime;
            EndTime = endTime;
        }
        public void GetTickets()
        {
            foreach (var ticket in Tickets)
            {
                Console.WriteLine($"{ticket.FirstName} {ticket.LastName}");
            }
        }
        public override string ToString()
        {
            return $@"{Id}. {Name}
Baslama saati : {StartTime}
Bitme saati : {EndTime}
IMDB deyeri : {IMDB}";
        }

    }
}
