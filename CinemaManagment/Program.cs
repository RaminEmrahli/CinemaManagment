using System.Runtime.CompilerServices;

namespace CinemaManagment
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Cinema cinema = new Cinema("Park Cinema");
            int result = Enter();
            while (result != 0)
            {
                Console.Clear();
                switch (result)
                {
                    case 1:
                        {
                            Hall newHall = CreateHall(cinema);
                            cinema.AddHall(newHall);
                            result = Enter();
                            break;
                        }
                    case 2:
                        {
                            if(cinema.Halls.Count > 0)
                            {
                                Hall hall = GetHall(cinema);
                                Movie newMovie = CreateMovie(hall);
                                hall.AddMovie(newMovie, hall.Id);
                            }
                            else
                            {
                                Console.WriteLine("Zal movcud deyildir :\n");
                            }
                            result = Enter();
                            break;
                        }
                    case 3:
                        {
                            if (cinema.Halls.Count > 0)
                            {
                                Hall h = GetHall(cinema);
                                if (h.Movies.Count > 0)
                                {
                                    Movie mov = GetMovie(h);
                                    Ticket ticket = BuyTicket(mov.Id,h);
                                    mov.AddTicket(ticket);
                                    result = Enter();
                                }
                                else
                                {
                                    Console.WriteLine("Teessuf ki, film movcud deyildir\n");
                                    result = Enter();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Teessuf ki,zal movcud deyildir\n");
                                result = Enter();
                            }
                            break;
                        }
                    case 4:
                        {
                            if (cinema.Halls.Count != 0)
                            {
                                Hall h = GetHall(cinema);
                                if(h.Movies.Count != 0)
                                {
                                    Movie mov = GetMovie(h);
                                    mov.GetTickets();
                                }
                                else
                                {
                                    Console.WriteLine("Film movcud deyildir :\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Zal movcud deyildir :\n");
                            }
                            result = Enter();
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Duzgun klik edilmedi :\n\n");
                            result = Enter();
                            break;
                        }
                }
            }
        }
        #region AllMethods
        public static int Enter()
        {
            Console.WriteLine("Proqramdan cixis ucun '0' duymesini klikleyin");
            Console.WriteLine("Zal elave etmek ucun '1' duymesini klikleyin");
            Console.WriteLine("Film elave etmek ucun '2' duymesini klikleyin");
            Console.WriteLine("Bilet sifaris etmek ucun '3' duymesini klikleyin");
            Console.WriteLine("Satislarin siyahisini gormek ucun '4' duymesini klikleyin");
            int result = int.Parse(Console.ReadLine());
            return result;
        }
        public static Hall CreateHall(Cinema cinema)
        {
            Console.WriteLine("zalin adini daxil edin :");
            string name = Console.ReadLine();
            Console.WriteLine("zalin sira sayini daxil edin :");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("her siradaki yer sayini daxil edin :");
            int column = int.Parse(Console.ReadLine());
            return new Hall(name, row, column,cinema);
        }
        public static Movie CreateMovie(Hall hall)
        {
            Console.WriteLine("Filmin adini daxil edin :");
            string name = Console.ReadLine();
            Console.WriteLine("Filmin IMDB deyerini daxil edin :");
            double imdb = double.Parse(Console.ReadLine());
            while (imdb < 0 || imdb > 10)
            {
                Console.WriteLine("IMDB deyeri 0 ve 10 arasinda qiymet almalidir :");
                imdb = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Filmin baslama saatini daxil edin :");
            int start_time = int.Parse(Console.ReadLine());
            while (start_time > 22)
            {
                Console.WriteLine("Filmin baslama saati duzgun daxil edilmedi :");
                start_time = int.Parse(Console.ReadLine());
            }
            TimeOnly startTime = new TimeOnly(start_time, 0);
            Console.WriteLine("Filmin bitme saatini daxil edin :");
            int end_time = int.Parse(Console.ReadLine());
            while (end_time > 23 || end_time <= start_time)
            {
                Console.WriteLine("Filmin bitme saati duzgun daxil edilmedi :");
                end_time = int.Parse(Console.ReadLine());
            }
            TimeOnly endTime = new TimeOnly(end_time, 0);
            return new Movie(name, imdb, startTime,endTime,hall);
        }
        public static Hall GetHall(Cinema cinema)
        {
            Console.WriteLine("Zali secin :");
            cinema.GetHalls();
            int hallId = int.Parse(Console.ReadLine());
            Hall hall = cinema.GetHall(hallId);
            while (hall == null)
            {
                Console.WriteLine("Zal tapilmadi,ID-ni duzgun daxil edin :");
                hallId = int.Parse(Console.ReadLine());
                hall = cinema.GetHall(hallId);
            }
            return hall;
        }
        public static Movie GetMovie(Hall h)
        {
            Console.WriteLine("Filmi Secin :");
            h.GetMovies();
            int movieId = int.Parse(Console.ReadLine());
            Movie mov = h.GetMovie(movieId);
            while (mov == null)
            {
                Console.WriteLine("Film tapilmadi :");
                movieId = int.Parse(Console.ReadLine());
                mov = h.GetMovie(movieId);
            }
            return mov;
        }
        public static Ticket BuyTicket(int movieId,Hall h)
        {
            Console.WriteLine("Adinizi daxil edin :");
            string firstname = Console.ReadLine();
            while (firstname == "")
            {
                Console.WriteLine("Adinzi duzgun daxil edin:");
                firstname = Console.ReadLine();
            }
            Console.WriteLine("Soyadinizi daxil edin :");
            string lastname = Console.ReadLine();
            Seat[,] Seats= h.GetSeats(movieId);
            Console.WriteLine("Sirani secin :");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Yerinizi secin :");
            int column = int.Parse(Console.ReadLine());
            while (Seats[row - 1, column - 1].Status == Status.Reserved)
            {
                Console.WriteLine("Bu yer rezerv olunmusdur :");
                Console.WriteLine("Sirani secin :");
                row = int.Parse(Console.ReadLine());
                Console.WriteLine("Yerinizi secin :");
                column = int.Parse(Console.ReadLine());
            }
            Seats[row - 1, column - 1].Status = Status.Reserved;
            return new Ticket(firstname, lastname, row, column);
        }
        #endregion
    }
}