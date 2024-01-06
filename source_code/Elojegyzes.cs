using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtarrendszer
{
    public class Elojegyzes
    {
        private List<Konyv> konyvek;
        private string datum;
        private string olvasoId;

        public Elojegyzes(string _datum, string _olvasoId)
        {
            datum = _datum;
            olvasoId = _olvasoId;
            konyvek = new List<Konyv>();
        }

        
        public void AddKonyv(string id, Keszlet k)
        {
            foreach (Konyv konyv in k.GetList())
            {
                if (konyv.GetKonyvID() == id)
                {
                    konyv.SetElojegyzett(true);
                    konyvek.Add(konyv);

                }
            }
        }
                
    }
}
