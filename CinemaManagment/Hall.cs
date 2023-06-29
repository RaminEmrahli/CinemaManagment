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

        Seat[,] Seats = { };

        public List<Movie> Movies = new List<Movie>();

        Dictionary<int, Seat[,]> dic = new Dictionary<int, Seat[,]>();
        public Hall(string name, int row, int column, Cinema cinema)
        {

            Id = cinema.Halls.Count + 1;
            Name = name;
            Row = row;
            Column = column;
        }
       
        public void AddMovie(Movie movie, int hallId)
        {
            bool isFounded = false;
            foreach (var item in Movies)
            {
                if (movie.StartTime < item.StartTime && movie.EndTime <= item.StartTime || movie.StartTime >= item.EndTime)
                {
                    isFounded = false;
                }
                else
                {
                    isFounded = true;
                    break;
                }
            }
            bool isExists = Movies.Any(x => x.Name == movie.Name);
            if (isExists || !isExists && isFounded)
            { 
                Console.WriteLine("Bu film artiq movcuddur :");
            }
            else if(!isFounded && !isExists)
            {
                Movies.Add(movie);
                dic.Add(movie.Id, AddSeats());
                Console.WriteLine($"Film {hallId} -ci zala elave olundu ");
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
        public Seat[,] AddSeats()
        {
            Seats = new Seat[Row, Column];
            for (int i = 0; i < Seats.GetLength(0); i++)
            {
                for (int j = 0; j < Seats.GetLength(1); j++)
                {
                    Seats[i, j] = new Seat();
                }
            }
            return Seats;
        }
        public Seat[,] GetSeats(int movieId)
        {
            Seat[,] seats = dic[movieId];
            for(int i = 0; i < seats.GetLength(1); i++)
            {
                Console.Write($"  {i + 1}   ");
            }
            Console.WriteLine();
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                Console.Write($"{i + 1}. ");
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    if (seats[i,j].Status == Status.Empty)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                    }
                    Console.Write(seats[i, j].Status + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            return seats;
        }
        public override string ToString()
        {
            return $@"{Id}. {Name} - Sira : {Row}, Sutun : {Column}";
        }
    }
}
