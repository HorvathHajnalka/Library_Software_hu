using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtarrendszer
{
    public class Keszlet
    {
        private List<Konyv> keszlet;

        public Keszlet()
        {
            keszlet = new List<Konyv>();
        }

        public void KonyvTorles(string torlendoId)
        {
            int torlendoindex = -1;

            for (int i = 0; i < keszlet.Count(); i++)
            {
                if (keszlet[i].GetKonyvID() == torlendoId)
                {
                    torlendoindex = i;
                }
            }

            if (torlendoindex != -1)
            {
                keszlet.Remove(keszlet[torlendoindex]);

                string fajlUtvonal = "konyv.txt";
                //string torlendoSzoveg = ;

                //// Fájl tartalmának beolvasása soronként
                //List<string> sorok = File.ReadAllLines(fajlUtvonal).ToList();

                //// Törlendő sorok keresése és eltávolítása
                //sorok.RemoveAll(sor => sor.Contains(torlendoSzoveg));

                //// Módosított tartalom visszaírása a fájlba
                //File.WriteAllLines(fajlUtvonal, sorok);



                Console.WriteLine("A konyv torlese sikeres!");
            }
            else
            {
                Console.WriteLine("A konyv torlese sikertelen! A konyv nem talalhato!");
            }
        }
        public void CreateKonyv(Konyv konyv)
        {
            keszlet.Add(konyv);           
                       
        }

        public void Add(Konyv konyv)
        {
            keszlet.Add(konyv);
        }
        public void KonyvFelvitel()
        {
            
            bool uj_kolcsonzott = false, uj_eloJegyzett = false;
            bool uresparam = false;
            bool ervenytelenparam = false;

            Console.Write("Konyv azonositoja: ");
            string uj_konyvId = Console.ReadLine();
            Console.Write("Konyv cime: ");
            string uj_cim = Console.ReadLine();
            Console.Write("Konyv szerzoje: ");
            string uj_szerzo = Console.ReadLine();
            Console.Write("Konyv kiadoja: ");
            string uj_kiado = Console.ReadLine();
            Console.Write("Konyv kiadasanak eve: ");
            string input = Console.ReadLine();

            int uj_kiadasEve;           
            
            // input = Console.ReadLine();
            // bool eredmeny = Int32.TryParse(darab, out intDarab);
            // if (eredmeny)
             if (!(Int32.TryParse(input, out uj_kiadasEve)) || uj_kiadasEve <= 0)
            {                    
                ervenytelenparam = true;
            }           

            Console.Write("Konyv nyelve: ");
            string uj_nyelv = Console.ReadLine();
            Console.Write("Konyv kategoriaja: ");
            string uj_kategoria = Console.ReadLine();

            if (uj_konyvId == "" || uj_cim == "" || uj_szerzo == "" || uj_kiado == "" || uj_kiadasEve == 0 || uj_nyelv == "" || uj_kategoria == "")
            {
                uresparam = true;
            }

            Console.Write("Konyv ki van kolcsonozve: (igen/nem): ");
            string kolcsonzott_e = Console.ReadLine();
            if (kolcsonzott_e == "igen" || kolcsonzott_e == "Igen" || kolcsonzott_e == "i" || kolcsonzott_e == "I")
            {
                uj_kolcsonzott = true;
            }
            else if (kolcsonzott_e == "nem" || kolcsonzott_e == "Nem" || kolcsonzott_e == "n" || kolcsonzott_e == "N")
            {
                uj_kolcsonzott = false;
            }
            else
            {
                ervenytelenparam = true;
            }

            Console.Write("Konyv elo van jegyezve: (igen/nem): ");
            string elojegyzett_e = Console.ReadLine();

            if (elojegyzett_e == "igen" || elojegyzett_e == "Igen" || elojegyzett_e == "i" || elojegyzett_e == "I")
            {
                uj_eloJegyzett = true;
            }
            else if (elojegyzett_e == "nem" || elojegyzett_e == "Nem" || elojegyzett_e == "n" || elojegyzett_e == "N")
            {
                uj_eloJegyzett = false;
            }
            else
            {
                ervenytelenparam = true;
            }

            if (!uresparam || !ervenytelenparam)
            {
                Konyv uj_Konyv = new Konyv(uj_konyvId, uj_cim, uj_szerzo, uj_kiado, uj_kiadasEve, uj_nyelv, uj_kategoria, uj_kolcsonzott, uj_eloJegyzett);
                CreateKonyv(uj_Konyv);
                Console.WriteLine("Konyv felvitele sikeres.");
            }
            else if(ervenytelenparam)
            {
                Console.WriteLine("Ervenytelen parameter!");
            }
            else if (uresparam)
            {
                Console.WriteLine("Ures parameter!");
            }
        }

        public int PeldanySzamlalo(string cim)
        {
            int db = 0;
            foreach (Konyv konyv in keszlet)
            {
                if (konyv.GetCim() == cim)
                {
                    db++;
                }
            }
            return db;
        }

        public void Kiir()
        {
            foreach (Konyv konyv in keszlet)
            {
                Console.WriteLine($"{konyv.GetSzerzo()}: {konyv.GetCim()}, Peldanyszam: {PeldanySzamlalo(konyv.GetCim())}");
            }
        }

        public void KeresesSzures(string id_szuro, string cim_szuro, string szerzo_szuro, string kiado_szuro, string nyelv_szuro, string kategoria_szuro, string kiadas_eve_szuro, string kolcsonzott_szuro, string elojegyzett_szuro)
        {
            List<Konyv> ujLista = new List<Konyv>();
            bool torlendo_e = false;
            bool kiir = false;
            foreach (Konyv konyv in keszlet)
            {
                if (id_szuro != konyv.GetKonyvID() && id_szuro != "0")
                    torlendo_e = true;
                if (cim_szuro != konyv.GetCim() && cim_szuro != "0")
                    torlendo_e = true;
                if (szerzo_szuro != konyv.GetSzerzo() && szerzo_szuro != "0")
                    torlendo_e = true;
                if (kiado_szuro != konyv.GetKiado() && kiado_szuro != "0")
                    torlendo_e = true;
                if (nyelv_szuro != konyv.GetNyelv() && nyelv_szuro != "0")
                    torlendo_e = true;
                if (kategoria_szuro != konyv.GetKategoria() && kategoria_szuro != "0")
                    torlendo_e = true;

                if (kiadas_eve_szuro != "0")
                {
                    if (Convert.ToInt32(kiadas_eve_szuro) != konyv.GetKiadasEve())
                        torlendo_e = true;
                }
                if (kolcsonzott_szuro != konyv.GetKolcsonzott_STRING() && kolcsonzott_szuro != "0")
                    torlendo_e = true;
                if (elojegyzett_szuro != konyv.GetElojegyzett_STRING() && elojegyzett_szuro != "0")
                    torlendo_e = true;
                if (!torlendo_e) ujLista.Add(konyv);
            }
            foreach (Konyv konyv in ujLista)
            {
                konyv.KonyvKiir();
                kiir = true;
                Console.WriteLine();
            }
            if (!kiir)
            {
                Console.WriteLine("Nem talalhato konyv a megadott parameterekkel! ");
            }
        }

        public void ElerhetoKonyvek()
        {
            List<Konyv> konyvek = new List<Konyv>(keszlet);
            foreach (Konyv konyv in konyvek)
            {
                if (!konyv.GetKolcsonzott())
                {
                    konyv.KonyvKiir();
                }
            }
        }

        public List<Konyv> GetList() { return keszlet; }

        public bool KonyvElerheto_kolcs(string konyv_id)
        {
            bool kolcsonoztheto = false;
            if (keszlet.Count() != 0)
            {
                foreach (Konyv konyv in keszlet)
                {
                    if (!konyv.GetKolcsonzott() && konyv.GetKonyvID() == konyv_id)
                    {
                        kolcsonoztheto = true;
                    }
                }
            }
            return kolcsonoztheto;
        }
        public bool KonyvElerheto_eloj(string konyv_id)
        {
            bool elojegyezheto = false;
            if (keszlet.Count() != 0)
            {
                foreach (Konyv konyv in keszlet)
                {
                    if (!konyv.GetElojegyzett() && konyv.GetKonyvID() == konyv_id)
                    {
                        elojegyezheto = true;
                    }
                }
            }
            return elojegyezheto;
        }

        public Konyv GetObjectByID(string ID)
        {
            foreach (Konyv konyv in keszlet)
            {
                if (konyv.GetKonyvID() == ID)
                    return konyv;
            }
            return null;
        }
        public int GetNemKolcsonzottDb()
        {
            int db = 0;
            foreach (Konyv konyv in keszlet)
            {
                if (!konyv.GetKolcsonzott())
                    db++;
            }
            return db;
        }
    }
}
