using ConsoleApp1.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //iteration pattern
    class Program
    {
        static void Main(string[] args)
        {
            KategoriTasiyici2 kategoriTasiyici = new KategoriTasiyici2();
            kategoriTasiyici.KategoriEkle(new Kategori { KategoriAdi = "Tekstil", Aciklama = "Tekstil ürünleri" });
            kategoriTasiyici.KategoriEkle(new Kategori { KategoriAdi = "Elektronik", Aciklama = "Elektronik ürünler" });
            kategoriTasiyici.KategoriEkle(new Kategori { KategoriAdi = "Mobilya", Aciklama = "Mobilya ürünleri" });

            var iterator = kategoriTasiyici.YineleyiciOlustur();

            while (iterator.BirSonraki())
            {
                Console.WriteLine(iterator.SuAnkiOge.KategoriAdi);
            }
            Console.ReadLine();
        }
    }
}
