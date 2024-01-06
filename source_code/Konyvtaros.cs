using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtarrendszer
{
    public class Konyvtaros : Felhasznalo
    {
        private string beosztas;

        public Konyvtaros(string _beosztas, string _nev, string _userId, string _lakcim, string _telefonszam, string _email, string _jelszo, string _jogosultsag)
            : base(_nev, _userId, _lakcim, _telefonszam, _email, _jelszo, _jogosultsag)
        {
            beosztas = _beosztas;
        }

        public string GetObjectAsString()
        {
            return $"{nev};{userId};{lakcim};{telefonszam};{email};{jelszo};{jogosultsag};{beosztas}";
        }

        public string GetBeosztas() { return beosztas; }

        public void SetBeosztas(string _beosztas) { beosztas = _beosztas; }
    }
}
