using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.interfaces
{
    public interface Iterator1<T>
    {
        //2. Yineleyici, çalıştığı ögeyi döndürebilmeli
        T SuAnkiOge { get; }
        //3. Varsa bir sonraki ögeye geç. 
        bool BirSonraki();
    }
}
