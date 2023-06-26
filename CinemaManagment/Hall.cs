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

        public Seat[,] Seats = {};

        public List<Movie> Movies = new List<Movie>();
        public Hall(string name, int row, int column)
        {
            Id = ++_id;
            Name = name;
            Row = row;
            Column = column;
            AddSeats(row, column);
        }
        public void AddSeats(int row,int column)
        {
            Seats = new Seat[row, column];
        }
        public void AddMovie(Movie movie)
        {
            bool isExists = Movies.Any(x => x.Name == movie.Name);
            if(isExists)
            {
                Console.WriteLine("Bu film artiq movcuddur :");
            }
            else
            {
                Movies.Add(movie);
            }
        }
        public void GetMovies()
        {
            foreach (Movie movie in Movies)
            {
                Console.WriteLine(movie);
            }
        }
        public Movie GetMovie(int id) => Movies.Find(x => x.Id == id);
        public void GetSeats()
        {
            for(int i = 0; i < Seats.GetLength(1); i++)
            {
                Console.Write($"  {i + 1}   ");
            }
            Console.WriteLine();
            for (int i = 0; i < Seats.GetLength(0); i++)
            {
                Console.Write($"{i + 1}. ");
                for (int j = 0; j < Seats.GetLength(1); j++)
                {
                    if (Seats[i,j].Status == Status.Empty)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                    }
                    Console.Write(Seats[i, j].Status + " ");
                }
                Console.WriteLine();
            }
        }
        public override string ToString()
        {
            return $@"{Id}. {Name} - Sira : {Row}, Sutun : {Column}";
        }
    }
}
