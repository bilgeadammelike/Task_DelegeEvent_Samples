using ConsoleApp1.interfaces;
using ConsoleApp1.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DAO
{
    public class KategoriTasiyici2 : ITasiyici1<Kategori>
    {
        //Kategori Koleksiyonu.
        public List<Kategori> TumKategoriler { get; } = new List<Kategori>();

        //koleksiyona kategori ekle
        public void KategoriEkle(Kategori kategori) => TumKategoriler.Add(kategori);

        public int KategoriSayisi { get => TumKategoriler.Count; }
        //Koleksiyonun yineleyicisi
        public Iterator1<Kategori> YineleyiciOlustur()
        {
            //TODO 1: Yineleyiciyi döndür.
            //return null;

            return new KategoriIterator(this);

        }
    }
}
