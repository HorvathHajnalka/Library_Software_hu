using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtarrendszer
{
    public class Olvaso : Felhasznalo
    {
        private double tagdij_fizetendo;
        private double kesedelmi_fizetendo;
        private List<Kolcsonzes> kolcsonzesek;

        public double Tagdij { get; set; }
        public double Kesedelmi { get; set; }
        public string Nev { get; set; }
        public string ID { get; set; }
        public string Lakcim { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Jelszo { get; set; }
        public string Jogosultsag { get; set; }
        public List<Kolcsonzes> Kolcsonzes { get; set; }

        public Olvaso(double _tagdij_fizetendo, double _kesedelmi_fizetendo, string _nev, string _userId,
        string _lakcim, string _telefonszam, string _email, string _jelszo, string _jogosultsag) :
        base(_nev, _userId, _lakcim, _telefonszam, _email, _jelszo, _jogosultsag)
        {
            tagdij_fizetendo = _tagdij_fizetendo;
            kesedelmi_fizetendo = _kesedelmi_fizetendo;
            kolcsonzesek = new List<Kolcsonzes>();
        }

        // public void KeresesSzures() { }

        public void Fizetes()
        {
            Console.WriteLine($"Tagdij fizetendo: {GetTagdijFizetendo()} Ft");
            Console.WriteLine($"Kesedelmi dij fizetendo: {GetKesedelmiFizetendo()} Ft");

            if (GetKesedelmiFizetendo() == 0 && GetTagdijFizetendo() == 0)
            {
                Console.WriteLine("Nincs fizetendo osszeg.");
            }
            else if (GetKesedelmiFizetendo() != 0)
            {
                Console.WriteLine("Tagdij befizetese: 001");
                Console.WriteLine("Kesedelmi dij befizetese: 002");
                Console.Write("Kerem a kivant muvelet szamat: ");
                string muv_szam = Console.ReadLine();
                if (muv_szam == "001")
                {
                    if (GetTagdijFizetendo() != 0)
                    {
                        Console.WriteLine("A befizeteshez nyomja meg az ENTER billentyut!");
                        ConsoleKey bevitel;
                        do
                        {
                            bevitel = Console.ReadKey(true).Key;

                        } while (bevitel != ConsoleKey.Enter);

                        TagdijBefizetese();
                    }
                    else
                        Console.WriteLine("Nincs fizetendo osszeg.");
                }
                else if (muv_szam == "002")
                {
                    Console.WriteLine("A befizeteshez nyomja meg az ENTER billentyut!");
                    ConsoleKey bevitel;
                    do
                    {
                        bevitel = Console.ReadKey(true).Key;

                    } while (bevitel != ConsoleKey.Enter);
                    KesedelmidijBefizetes();

                }
                else
                {
                    Console.WriteLine("Ervenytelen muvelet! ");
                    Fizetes();
                }
            }
            else
            {
                Console.WriteLine("A befizeteshez nyomja meg az ENTER billentyut!");
                ConsoleKey bevitel;
                do
                {
                    bevitel = Console.ReadKey(true).Key;

                } while (bevitel != ConsoleKey.Enter);
                TagdijBefizetese();
            }
        }

        public void TagdijBefizetese()
        {
            tagdij_fizetendo = 0;
            Console.WriteLine("Sikeres befizetes! ");
            Console.WriteLine($"Tagdij fizetendo: {tagdij_fizetendo} Ft");
            Console.WriteLine($"Kesedelmi dij fizetendo: {kesedelmi_fizetendo} Ft");
        }
        public void KesedelmidijBefizetes()
        {
            kesedelmi_fizetendo = 0;
            Console.WriteLine("Sikeres befizetes! ");
            Console.WriteLine($"Tagdij fizetendo: {tagdij_fizetendo} Ft");
            Console.WriteLine($"Kesedelmi dij fizetendo: {kesedelmi_fizetendo} Ft");
        }

        public void AddKolcsonzes(Kolcsonzes kolcsonzes)
        {
            kolcsonzesek.Add(kolcsonzes);
        }
        public void KolcsonzesekKiir()
        {
            foreach (Kolcsonzes kolcsonzes in kolcsonzesek)
            {
                Console.WriteLine($"Kolcsonzes datuma: {kolcsonzes.GetKolcsDatum()}");
                Console.WriteLine($"Lejarat datuma: {kolcsonzes.GetLejarDatum()}");
                Console.WriteLine($"Kolcsonzes azonosito: {kolcsonzes.GetKolcsId()}");

                if (kolcsonzes.GetKonyvek() != null)
                {
                    foreach (Konyv konyv in kolcsonzes.GetKonyvek())
                    {
                        konyv.KonyvKiir();
                    }
                }
                else
                {
                    Console.WriteLine("Nincsenek konyvek!");
                }

                Console.WriteLine();
            }
        }

        //getterek, setterek
        public void SetTagdijFizetendo(double _fizetendo)
        {
            tagdij_fizetendo += _fizetendo;
        }

        public void SetKesedelmiFizetendo(double _fizetendo)
        {
            kesedelmi_fizetendo += _fizetendo;
        }

        public double GetKesedelmiFizetendo() { return kesedelmi_fizetendo; }
        public double GetTagdijFizetendo() { return tagdij_fizetendo; }     
        
        public List<Kolcsonzes> GetKolcsonzesek() { return kolcsonzesek; }
        public Kolcsonzes GetKolcsById(string k_id)
        {
            foreach (Kolcsonzes kolcs in kolcsonzesek)
            {
                if (kolcs.GetKolcsId() == k_id) { return kolcs; }
            }
            return null;
        }

        public string getObjectAsString()
        {
            return "";
        }
        
    }
    
}
