using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Konyvtarrendszer
{
    public class Kolcsonzes
    {
        private List<Konyv> konyvek;
        private string kolcsonzesDatum;
        private string lejaratDatum;
        private string olvasoId;
        private string kolcsID;

        public List<Konyv> Konyvek { get; set; }
        public string Kolcsonzes_datum { get; set; }
        public string Lejarat_datum { get; set; }
        public string Olvaso_id { get; set; }

        public string Kolcs_id { get; set; }

        [JsonConstructor]
        public Kolcsonzes(string kolcsonzesDatum, string lejaratDatum, string olvasoId, string kolcsID)
        {
            // Inicializáló logika
            Kolcsonzes_datum = kolcsonzesDatum;
            Lejarat_datum = lejaratDatum;
            Olvaso_id = olvasoId;
            Kolcs_id = kolcsID;
            konyvek = new List<Konyv>();
        }
        public Kolcsonzes()
        {
            konyvek = new List<Konyv>();
            // Inicializáló logika
        }
        public Kolcsonzes(string _kolcsonzesDatum, string _lejaratDatum, string _olvasoId, string[] konyvid, Keszlet k, string _kolcs_id)
        {
            kolcsonzesDatum = _kolcsonzesDatum;
            lejaratDatum = _lejaratDatum;
            olvasoId = _olvasoId;
            konyvek = new List<Konyv>();
            kolcsID = _kolcs_id;

            foreach(string id in konyvid)
            {               
                konyvek.Add(k.GetObjectByID(id));
            }
        }

        public Kolcsonzes(string olvasoId, string kolcsID)
        {
            this.kolcsID = kolcsID;
            this.olvasoId = olvasoId;
            konyvek = new List<Konyv>();
            DateTime maiDatum = DateTime.Now;
            kolcsonzesDatum = maiDatum.ToString("yyyy.MM.dd");


            lejaratDatum = Plusz1Honap(kolcsonzesDatum);

        }

        public void AddKonyv(string id, Keszlet k)
        {
            foreach (Konyv konyv in k.GetList())
            {
                if (konyv.GetKonyvID() == id)
                {
                    konyv.SetKolcsonzott(true);
                    konyvek.Add(konyv);

                }
            }
        }


        public int KolcsonzesTeljesitve(string torlendoId)
        {            
            int torlendoindex = -1;

            for (int i = 0; i < konyvek.Count(); i++)
            {
                if (konyvek[i].GetKonyvID() == torlendoId)
                {
                    torlendoindex = i;
                }
            }            
            return torlendoindex;
        }

        public void Hosszabbitas()
        {
            bool sikeres = false;
            foreach(Konyv k in konyvek)
            {
                if (!k.GetElojegyzett())
                {
                    lejaratDatum = Plusz1Honap(lejaratDatum);
                    Console.Write($"Hosszabbitas sikeres! Az uj lejarati datum: {lejaratDatum}\n");
                    sikeres = true;
                    break;
                }
            }

            if (!sikeres)
            {
                Console.WriteLine("Ezt a konyvet valaki mas mar elojegyezte, nem tudod meghosszabbitani a kolcsonzest!\n");
            }
        }

        public string Plusz1Honap(string alapDatum)
        {
            string[] datum = alapDatum.Split('.');

            if (datum[1] == "01") datum[1] = "02";
            else if (datum[1] == "02") datum[1] = "03";
            else if (datum[1] == "03") datum[1] = "04";
            else if (datum[1] == "04") datum[1] = "05";
            else if (datum[1] == "05") datum[1] = "06";
            else if (datum[1] == "06") datum[1] = "07";
            else if (datum[1] == "07") datum[1] = "08";
            else if (datum[1] == "08") datum[1] = "09";
            else if (datum[1] == "09") datum[1] = "10";
            else if (datum[1] == "10") datum[1] = "11";
            else if (datum[1] == "11") datum[1] = "12";
            else if (datum[1] == "12")
            {
                int ev = Convert.ToInt32(datum[0]) + 1;
                datum[0] = Convert.ToString(ev);                
                datum[1] = "01";
            }
            string ujdatum = datum[0] + "." + datum[1] + "." + datum[2];
            return ujdatum;
        }


        public string GetKolcsDatum() { return kolcsonzesDatum; }
        public string GetLejarDatum() { return lejaratDatum; }
        public string GetOlvasoId() { return olvasoId; }
        public List<Konyv> GetKonyvek() { return konyvek; }
        public string GetKolcsId(){return kolcsID;}

        public string GetObjectAsString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Konyv konyv in konyvek)
            {
                sb.Append(konyv.GetKonyvID());
                sb.Append("\t");
            }
            sb.Remove(sb.Length - 1, 1); //törlöm az utcsó tabot

            sb.Append($";{kolcsonzesDatum};{lejaratDatum};{olvasoId}");
            string result = sb.ToString();
            return result;
        }
        public void SetKolcsDatum(string kd)
        {
            kolcsonzesDatum = kd;
        }
        public void SetLeDatum(string ld)
        {
            lejaratDatum = ld;
        }
        public void SetOlvId(string od)
        {
            olvasoId = od;
        }
        public void SetKolcsId(string kolcsid)
        {
            kolcsID = kolcsid;
            //Kolcs_id = kolcsid;
        }


        //eddig

    }
}
