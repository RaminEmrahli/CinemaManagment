using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagment
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double IMDB { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public List<Ticket> Tickets = new List<Ticket>();
        public Movie(string name, double imdb, TimeOnly startTime, TimeOnly endTime,Hall hall)
        {
            Id = hall.Movies.Count + 1;
            Name = name;
            IMDB = imdb;
            StartTime = startTime;
            EndTime = endTime;
        }
        public void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
            Console.WriteLine("Bilet satisi tamamlanmisdir, xos izlemeler");
        }
        public void GetTickets()
        {
            if(Tickets.Count > 0)
            {
                foreach (var ticket in Tickets)
                {
                    Console.WriteLine($"{ticket.FirstName} {ticket.LastName} sira: {ticket.Row} yer: {ticket.Column}");
                }
            }
            else
            {
                Console.WriteLine("Sifaris yoxdur");
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
