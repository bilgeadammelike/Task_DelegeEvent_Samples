using ConsoleApp1.DAO;
using ConsoleApp1.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Iterator
{
    public class KategoriIterator : Iterator1<Kategori>
    {
        //Çalışılacak taşıyıcı nesne:
        private KategoriTasiyici2 kategoriTasiyici;
        //taşıyıcı nesne, constructor'da belirtiliyor:
        public KategoriIterator(KategoriTasiyici2 kategoriTasiyici)
        {
            this.kategoriTasiyici = kategoriTasiyici;
        }

        //bir ögeden diğerine geçişi yöneten algoritmanın ana noktası, koleksiyonun aktif index değerini bellekte tutmak:
        private int aktifIndex = 0;

        public Kategori SuAnkiOge { get; private set; }

        public bool BirSonraki()
        {
            if (aktifIndex < kategoriTasiyici.KategoriSayisi)
            {
                SuAnkiOge = kategoriTasiyici.TumKategoriler[aktifIndex++];
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
