using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication02
{
    //TPL(Task Parallel Library)
    //PLINQ(Parallel Language INtegrated Query) 
    class Program
    {
        static void Main(string[] args)
        {
            #region Parallel Ilk Ornek

            //List<Ogrenci> OgrenciListesi = new List<Ogrenci>
            //{
            //    new Ogrenci{ Id = 1, AdSoyad = "Veysel Uğur KIZMAZ"},
            //    new Ogrenci{ Id = 2, AdSoyad = "Emre YAĞMUR"},
            //    new Ogrenci{ Id = 3, AdSoyad = "Baran KIZMAZ"},
            //    new Ogrenci{ Id = 4, AdSoyad = "Umutcan SAVUR"},
            //    new Ogrenci{ Id = 5, AdSoyad = "Halil YILAMZ"},
            //    new Ogrenci{ Id = 6, AdSoyad = "Hakan ÖZSOY"},
            //    new Ogrenci{ Id = 7, AdSoyad = "Önder TURAN"},
            //};

            //for (int i = 0; i < OgrenciListesi.Count; i++)
            //{
            //    Console.WriteLine("Ogrenci ID:" + OgrenciListesi[i].Id + " - Ad Soyad: " + OgrenciListesi[i].AdSoyad);
            //}


            //Console.WriteLine(" "); Console.WriteLine(" "); Console.WriteLine(" ");

            #region Paralel Ogrenci Listesi Calistir
            //List<Ogrenci> ogrenciler = new List<Ogrenci>
            //{
            //    new Ogrenci{ Id = 1, AdSoyad = "Veysel Uğur KIZMAZ"},
            //    new Ogrenci{ Id = 2, AdSoyad = "Emre YAĞMUR"},
            //    new Ogrenci{ Id = 3, AdSoyad = "Baran KIZMAZ"},
            //    new Ogrenci{ Id = 4, AdSoyad = "Umutcan SAVUR"},
            //    new Ogrenci{ Id = 5, AdSoyad = "Halil YILAMZ"},
            //    new Ogrenci{ Id = 6, AdSoyad = "Hakan ÖZSOY"},
            //    new Ogrenci{ Id = 7, AdSoyad = "Önder TURAN"},
            //};

            //Parallel.For(0, ogrenciler.Count, i =>
            //{
            //    Console.WriteLine("Ogrenci ID:" + ogrenciler[i].Id + " - Ad Soyad: " + ogrenciler[i].AdSoyad);
            //});
            #endregion

            #endregion


            #region Parallel Ornekler


            int[] numbers = Enumerable.Range(1, 100000).ToArray();

            #region Parallel.For 

            //Console.WriteLine("For\n");
            //Parallel.For(1, numbers.Length,
            //    i =>
            //    {
            //        if (i % 1500 == 0)
            //            Console.Write("{0} ", i.ToString());
            //    }
            //);

            //Console.WriteLine("\n\nFor(İçeriden başka metod çağırarak)\n");

            //Parallel.For(1, numbers.Length,
            //    (i) =>
            //    {
            //        if (i % 1500 == 0)
            //            Task1(i);
            //    }
            //);


            #endregion

            #region Parallel.ForEach

            //Console.WriteLine("\n\nForEach Örneği\n");
            //Parallel.ForEach(numbers, number =>
            //{
            //    if (number % 1500 == 0)
            //        Console.Write("{0} ", number.ToString());
            //}
            //);

            #endregion

            #region Parallel.Invoke

            Console.WriteLine("\n\n");


            Parallel.Invoke(
                () =>
                {
                    Console.WriteLine("Toplam Tek sayı hesabı başladı\n");
                    Console.WriteLine("Thread ID {0} ", Thread.CurrentThread.ManagedThreadId.ToString());
                    OddCount(numbers);
                    Console.WriteLine("Toplam Tek sayı bulma işi tamamlandı\n");
                },
                () =>
                {
                    Console.WriteLine("Toplam Çift sayı hesabı başladı\n");
                    EvenCount(numbers);
                    Console.WriteLine("Thread ID {0} ", Thread.CurrentThread.ManagedThreadId.ToString());
                    Console.WriteLine("Toplam Çift sayı bulma işi tamamlandı\n");
                },
                () =>
                {
                    Console.WriteLine("9 ile bölünenlerin toplamını bulma işi başladı\n");
                    NineCount(numbers);
                    Console.WriteLine("Thread ID {0} ", Thread.CurrentThread.ManagedThreadId.ToString());
                    Console.WriteLine("9 ile bölünenlerin toplamını bulma işi tamamlandı\n");
                }
        );

            #endregion
            #endregion
            Console.ReadLine();
        }

        static void Task1(int number)
        {
            Console.Write("{0} ", number.ToString());
        }

        static void EvenCount(int[] numbers)
        {
            int result = (from number in numbers
                          where number % 2 == 0
                          select number).Count();
            Console.WriteLine("\tDizi içerisinde {0} adet ÇİFT sayı vardır\n", result.ToString());
        }
        static void OddCount(int[] numbers)
        {
            int result = (from number in numbers
                          where number % 2 != 0
                          select number).Count();
            Console.WriteLine("\tDizi içerisinde {0} adet TEK sayı vardır\n", result.ToString());
        }

        static void NineCount(int[] numbers)
        {
            int result = (from number in numbers
                          where number % 9 == 0
                          select number).Count();
            Console.WriteLine("\tDizi içerisinde {0} adet 9 ile bölünebilen sayı vardır\n", result.ToString());
        }


    }
}
