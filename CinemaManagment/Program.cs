namespace CinemaManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = Enter();
            Console.Clear();
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