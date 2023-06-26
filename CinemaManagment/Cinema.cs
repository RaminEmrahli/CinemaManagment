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
        public List<Hall> Halls = new List<Hall>();
        public void AddHall(Hall hall)
        {
            bool isExists = Halls.Any(h => h.Name == hall.Name);
            if (isExists)
            {
                Console.WriteLine("Bu zal artiq movcuddur");
            }
            else
            {
                Halls.Add(hall);
                Console.WriteLine("Zal elave edildi\n\n");
            }
        }
        public void GetHalls()
        {
            foreach (Hall hall in Halls)
            {
                Console.WriteLine(hall);
            }
        }

        public Hall GetHall(int id) => Halls.Find(x => x.Id == id);

    }
}
