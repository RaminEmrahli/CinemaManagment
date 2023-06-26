using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagment
{
    internal class Cinema
    {
        public string Name { get; set; }
        public Cinema(string name)
        {
            Name = name;
        }
        public  List<Hall> Halls = new List<Hall>();
        public void AddHall(Hall hall)
        {
            Halls.Add(hall);
        }
        public void GetHalls()
        {
            foreach (Hall hall in Halls)
            {
                Console.WriteLine(hall);
            }
        }
        public Hall GetHall(int id)=> Halls.Find(h => h.Id == id);
    }
}
