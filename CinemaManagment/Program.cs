namespace CinemaManagment
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Cinema cinema = new Cinema("Park Cinema");
            Hall hall = new Hall("Hall A", 10, 8);
            Movie movie1 = new Movie("Movie 1", 8.5, new TimeOnly(12, 00), new TimeOnly(14, 00));
            Movie movie2 = new Movie("Movie 2", 8.5, new TimeOnly(14, 00), new TimeOnly(16, 00));
            Movie movie3 = new Movie("Movie 3", 8.5, new TimeOnly(16, 00), new TimeOnly(18, 00));
            hall.Movies.Add(movie1);
            hall.Movies.Add(movie2);
            hall.Movies.Add(movie3);
            cinema.Halls.Add(hall);
            int result = Enter();
            Console.Clear();
            while(result != 0)
            {
                switch (result) 
                {
                    case 1:
                        {
                            //Console.WriteLine("Zalin adini daxil edin :");
                            //string name = Console.ReadLine();
                            //Console.WriteLine("Zalin sira sayini daxil edin :");
                            //int row = int.Parse(Console.ReadLine());
                            //Console.WriteLine("Her siradaki yer sayini daxil edin :");
                            //int column = int.Parse(Console.ReadLine());
                            //Hall newHall = new Hall(name, row, column);
                            //result = Enter();
                            break;
                        }
                    case 2:
                        {
                            //Console.WriteLine("Filmin adini daxil edin :");
                            //string name = Console.ReadLine();
                            //Console.WriteLine("Filmin IMDB deyerini daxil edin :");
                            //double imdb = double.Parse(Console.ReadLine());
                            //Console.WriteLine("Filmin baslama saatini daxil edin :");
                            //int start_time = int.Parse(Console.ReadLine());
                            //TimeOnly startTime = new TimeOnly(start_time,0);
                            //int end_time = int.Parse(Console.ReadLine());
                            //TimeOnly endTime = new TimeOnly(end_time, 0);
                            //Movie movie = new Movie(name, imdb, startTime, endTime);
                            //result = Enter();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Adinizi daxil edin :");
                            string firstname = Console.ReadLine();
                            Console.WriteLine("Soyadinizi daxil edin :");
                            string lastname = Console.ReadLine();
                            Console.WriteLine("Zali secin");
                            cinema.GetHalls();
                            int hallId = int.Parse(Console.ReadLine());
                            Hall h = cinema.GetHall(hallId);
                            while (h == null)
                            {
                                Console.WriteLine("Zal tapilmadi :");
                                hallId = int.Parse(Console.ReadLine());
                            }
                            Console.WriteLine("Filmi Secin :");
                            hall.GetMovies();
                            int movieId = int.Parse(Console.ReadLine());
                            Movie mov = hall.GetMovie(movieId);
                            while (mov == null)
                            {
                                Console.WriteLine("Film tapilmadi :");
                                movieId = int.Parse(Console.ReadLine());
                            }
                            hall.GetSeats();
                            Console.WriteLine("Sirani secin :");
                            int row = int.Parse(Console.ReadLine());
                            Console.WriteLine("Yerinizi secin :");
                            int column = int.Parse(Console.ReadLine());
                            while (hall.Seats[row - 1, column - 1].Status == Status.Reserved)
                            {
                                Console.WriteLine("Bu yer rezerv olunmusdur :");
                                Console.WriteLine("Sirani secin :");
                                row = int.Parse(Console.ReadLine());
                                Console.WriteLine("Yerinizi secin :");
                                column = int.Parse(Console.ReadLine());
                            }
                            hall.Seats[row - 1, column - 1].Status = Status.Reserved;
                            Ticket ticket = new Ticket(firstname, lastname, row, column);
                            mov.Tickets.Add(ticket);
                            Console.WriteLine("Bilet satisi tamamlanmisdir, xos izlemeler");
                            result = Enter();
                            break;
                        }
                }
            }
        }
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
    }
}