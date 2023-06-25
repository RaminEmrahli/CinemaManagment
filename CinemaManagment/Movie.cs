using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagment
{
    internal class Movie
    {
        public string Name { get; set; }//unique olmalidi
        public double IMDB { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        List<Ticket> tickets = new List<Ticket>();
        public Movie(string name, double imdb, DateTime startTime, DateTime endTime)
        {
            Name = name;
            IMDB = imdb;
            StartTime = startTime;
            EndTime = endTime;
        }
        //c) Başlama saatı, bir dənə inputdan təşkil olunacaq, saatı qeyd edərsiniz və
        //TimeOnly struct-u vasitəsilə başlama saatını da təyin edərsiniz, yəni məsələn, deyəlim ki, başlama saatını 15 yazdınız,
        //saatı təyin edərkən, belə yazmalısınız : TimeOnly start_time = new TimeOnly(15, 0);

        //d) Bitmə saatı : Eyni başlama saatı kimi təyin edəcəksiniz. Başlama və bitmə saatlarını təyin edərkən,
        //saat dəyərinin 23 dən böyük olmamalı olduğunu və
        //bitmə saatının başlama saatından böyük olmalı olduğunu nəzərinizə çatdırım.

        //e) Zalı seçməlisiniz. Zalların siyahısı gələcək daxil etməli olduğunuz Id dəyərinə görə həmin zalı tapmalıdır.
        //Əgər tapmasa, zalı seçməyinizi tələb
        //etməlidir. Tapdığı halda isə, həmin Hall-un içərisindəki Movie List-inə yaradacağınız Movie-ni əlavə etməlidir.
    }
}
