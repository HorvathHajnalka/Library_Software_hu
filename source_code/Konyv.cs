using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtarrendszer
{
    public class Konyv
    {
        private string konyvId;
        private string cim;
        private string szerzo;
        private string kiado;
        private int kiadasEve;
        private string nyelv;
        private string kategoria;
        private bool kolcsonzott;
        private bool elojegyzett;

        public string Konyv_id { get; set; }
        public string Cim { get; set; }
        public string Szerzo { get; set; }
        public string Kiado { get; set; }
        public int Kiadas_eve { get; set; }
        public string Nyelv { get; set; }
        public string Kategoria { get; set; }
        public bool Kolcsonzott { get; set; }
        public bool Elojegyzett { get; set; }

        public Konyv(string _konyvId, string _cim, string _szerzo, string _kiado, int _kiadasEve,
            string _nyelv, string _kategoria, bool _kolcsonzott, bool _eloJegyzett)
        {
            konyvId = _konyvId;
            cim = _cim;
            szerzo = _szerzo;
            kiado = _kiado;
            kiadasEve = _kiadasEve;
            nyelv = _nyelv;
            kategoria = _kategoria;
            kolcsonzott = _kolcsonzott;
            elojegyzett = _eloJegyzett;
        }

        public void KonyvKiir(){
            Console.WriteLine($"Id: {konyvId}, Cim: {cim}, Szerzo: {szerzo}, Kiado: {kiado}, Kiadas eve: {kiadasEve}, Nyelv: {nyelv}, Kategoria: {kategoria}, Kolcsonzott: {kolcsonzott}, Elojegyzett: {elojegyzett} ");
        }

        public void SetKolcsonzott(bool kolcsonzott_e) { kolcsonzott = kolcsonzott_e; }

        public void SetElojegyzett(bool eloJegyzett_e) { elojegyzett = eloJegyzett_e; }

        public string GetKonyvID() { return konyvId; }
        public string GetSzerzo() { return szerzo; }
        public string GetCim() { return cim; }
        public string GetKiado() { return kiado; }
        public int GetKiadasEve() { return kiadasEve; }
        public string GetNyelv() { return nyelv; }
        public string GetKategoria() { return kategoria; }
        public bool GetKolcsonzott() { return kolcsonzott; }
        public bool GetElojegyzett() { return elojegyzett; }

        public string GetKolcsonzott_STRING() 
        {
            if (kolcsonzott)
                return "true";
            else
                return "false"; 
        }
        public string GetElojegyzett_STRING() 
        {
            if (elojegyzett)
                return "true";
            else
                return "false"; 
        }

        public string GetObjectAsString()
        {
            return $"{konyvId};{cim};{szerzo};{kiado};{kiadasEve};{nyelv};{kategoria};{kolcsonzott};{elojegyzett}";
        }
    }
}
