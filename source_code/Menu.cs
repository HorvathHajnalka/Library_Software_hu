using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtarrendszer
{
    public class Menu
    {
        public static Felhasznalo Login_Logout(Felhasznalok f)
        {
            bool loggedIn = false;
            string felhasznalonev, jelszo;
            Felhasznalo felhasznalo = null;

            while (!loggedIn)
            {
                Console.Write("Felhasznalonev: ");
                felhasznalonev = Console.ReadLine();
                Console.Write("Jelszo: ");
                jelszo = Console.ReadLine();
                for (int i = 0; i < f.GetSize(); i++)
                {
                    if (f.GetNameByIndex(i) == felhasznalonev && f.GetPasswordByIndex(i) == jelszo)
                    {
                        loggedIn = true;
                        Console.WriteLine("Sikeres bejelentkezes!");
                        felhasznalo = f.GetObjectByIndex(i);
                        break;
                    }
                }
                if (!loggedIn)
                { Console.WriteLine("Sikertelen bejelentkezes!"); }
            }
            return felhasznalo;
        }

        public static string Muveletek(string tipus)
        {
            string muveletszam;
            Console.WriteLine($"Belepve {tipus}kent");
            Console.WriteLine("Lehetseges muveletek:");

            if (tipus == "admin") //kesz, kezelve
            {
                Console.WriteLine("Felhasznalo letrehozasa: 001"); // kesz, kezelve
                Console.WriteLine("Felhasznalo torlese: 002"); // kesz, kezelve
                Console.WriteLine("Felhasznalo adatainak frissitese: 003"); // kesz, kezelve
                Console.WriteLine("Felhasznalok szamainak listazasa: 004"); // kesz, kezelve
                Console.WriteLine("Osszes Felhasznalo listazasa: 005"); // kesz, kezelve
            }
            else if (tipus == "konyvtaros")
            {
                Console.WriteLine("Kereses es szures: 001"); // kesz, kezelve
                Console.WriteLine("Konyv felvitele a rendszerbe: 002"); // kesz,kezelve
                Console.WriteLine("Konyv torlese: 003"); // kesz, kezelve
                Console.WriteLine("Kolcsonzes felvitele a rendszerbe: 004"); // kesz, kezelve
                Console.WriteLine("Kolcsonzes teljesites felvitele a rendszerbe: 005"); // kesz, kezelve
                Console.WriteLine("Elerheto konyvek listazasa: 006"); // kesz, kezelve
            }
            else if (tipus == "olvaso")
            {
                Console.WriteLine("Kereses es szures: 001"); // kesz, kezelve
                Console.WriteLine("Elerheto konyvek listazasa: 002"); // kesz, kezelve
                Console.WriteLine("Elojegyzes: 003"); // kesz, kezelve
                Console.WriteLine("Befizetes: 004"); // kesz, kezelve
                Console.WriteLine("Hosszabbitas: 005"); //kesz, kezelve
                Console.WriteLine("Kolcsonzesek listazasa: 006"); //kesz, kezelve
            }
            Console.WriteLine();
            Console.Write("Kerem a kivant muvelet szamat: ");
            muveletszam = Console.ReadLine();
            Console.WriteLine();
            return muveletszam;
        }

        public static void Iranyito(string tipus, string muv_szam, Felhasznalok f, Keszlet k, Felhasznalo felhasznalo)
        {
            if (tipus == "admin")
            {
                AdminMuveletek(muv_szam, f);
            }
            else if (tipus == "konyvtaros")
            {
                KonyvtarosMuveletek(muv_szam, k, f);
            }
            else if (tipus == "olvaso")
            {
                Olvaso o = felhasznalo as Olvaso;
                OlvasoMuveletek(muv_szam, k, o);
            }
        }

        public static void AdminMuveletek(string muv_szam, Felhasznalok f)
        {
            if (muv_szam == "001")
            {

                string uj_nev, uj_id, uj_cim, uj_telszam, uj_email, uj_jelszo, uj_jogosultsag, uj_beosztas;
                bool uresparam = false;

                Console.Write("Nev: ");
                uj_nev = Console.ReadLine();
                Console.Write("ID: ");
                uj_id = Console.ReadLine();
                Console.Write("Lakcim: ");
                uj_cim = Console.ReadLine();
                Console.Write("Telefonszam: ");
                uj_telszam = Console.ReadLine();
                Console.Write("Email: ");
                uj_email = Console.ReadLine();
                Console.Write("Jelszo: ");
                uj_jelszo = Console.ReadLine();
                Console.Write("Jogosultsag(admin/konyvtaros/olvaso): ");
                uj_jogosultsag = Console.ReadLine();

                if (uj_nev == "" || uj_id == "" || uj_cim == "" || uj_telszam == "" || uj_email == "" || uj_jelszo == "" || uj_jogosultsag == "")
                {
                    uresparam = true;
                }

                if (!uresparam)
                {
                    if (uj_jogosultsag == "admin")
                    {
                        Console.Write("Beosztas: ");
                        uj_beosztas = Console.ReadLine();
                        Adminisztrator admin_plusz = new Adminisztrator(uj_beosztas, uj_nev, uj_id, uj_cim, uj_telszam, uj_email, uj_jelszo, uj_jogosultsag);
                        f.CreateFelhasznalo(admin_plusz);
                        Console.WriteLine("Felhasznalo letrehozasa sikeres! ");
                    }
                    else if (uj_jogosultsag == "konyvtaros")
                    {
                        Console.Write("Beosztas: ");
                        uj_beosztas = Console.ReadLine();
                        Konyvtaros konyvtaros_plusz = new Konyvtaros(uj_beosztas, uj_nev, uj_id, uj_cim, uj_telszam, uj_email, uj_jelszo, uj_jogosultsag);
                        f.CreateFelhasznalo(konyvtaros_plusz);
                        Console.WriteLine("Felhasznalo letrehozasa sikeres! ");
                    }
                    else if (uj_jogosultsag == "olvaso")
                    {
                        Olvaso olvaso_plusz = new Olvaso(0.0, 0.0, uj_nev, uj_id, uj_cim, uj_telszam, uj_email, uj_jelszo, uj_jogosultsag);
                        f.CreateFelhasznalo(olvaso_plusz);
                        Console.WriteLine("Felhasznalo letrehozasa sikeres! ");
                    }
                    else
                    {
                        Console.WriteLine("Ervenytelen jogosultsag!");
                    }
                }
                else
                {
                    Console.WriteLine("Ures parameter!");
                }
            }
            else if (muv_szam == "002")
            {
                string torlendo;
                f.MindenkitListaz();
                Console.Write("Torlendo felhasznalo azonositoja: ");
                torlendo = Console.ReadLine();
                f.DeleteFelhasznalo(torlendo);
            }
            else if (muv_szam == "003")
            {
                f.MindenkitListaz();
                f.UpdateFelhasznalo();
            }

            else if (muv_szam == "004")
            {
                f.FelhasznaloTipusSzamlalo();
            }
            else if (muv_szam == "005")
            {
                f.MindenkitListaz();
            }
            else
            {
                Console.WriteLine("Ervenytelen muvelet! ");
                Console.Write("Kerem a kivant muvelet szamat: ");
                muv_szam = Console.ReadLine();
                AdminMuveletek(muv_szam, f);
            }

        }
        public static void KonyvtarosMuveletek(string muv_szam, Keszlet k, Felhasznalok f)
        {
            if (muv_szam == "001")
            {
                NagyKeresesSzures(k);

            }
            else if (muv_szam == "002")
            {
                k.KonyvFelvitel();
            }
            else if (muv_szam == "003")
            {
                NagyKeresesSzures(k);
                string torlendoId;
                Console.Write("Adja meg a torlendo konyv ID-jet: ");
                torlendoId = Console.ReadLine();
                k.KonyvTorles(torlendoId);
            }
            else if (muv_szam == "004")
            {
                f.OlvasokatListaz();
                Console.Write("Kerem az olvaso Id-jet: ");
                string olvasoId = Console.ReadLine();
                Console.Write("Kerem a kolcsonzes  Id-jet: ");
                string kolcsId = Console.ReadLine();
                if (f.GetObjectByID(olvasoId) is Olvaso && f.GetObjectByID(olvasoId) != null)
                {
                    Kolcsonzes kolcs = new Kolcsonzes(olvasoId, kolcsId);

                    NagyKeresesSzures(k);

                    Console.Write("Kikolcsonozni kivant konyvek szama (maximum 10 db): ");
                    string darab = Console.ReadLine();
                    int intDarab;
                    //int kolcsonozheto = k.GetNemKolcsonzottDb();
                    bool eredmeny = Int32.TryParse(darab, out intDarab);
                    if (eredmeny)
                    {
                        if (intDarab > 0 && intDarab < 11 && intDarab < k.GetList().Count() && k.GetNemKolcsonzottDb() > 0 && intDarab <= k.GetNemKolcsonzottDb())
                        {
                            for (int i = 0; i < intDarab; i++)
                            {
                                if (k.GetNemKolcsonzottDb() > 0)
                                {
                                    Console.Write("Kerem a kolcsonozni kivant konyv id-jet: ");
                                    string konyv_id = Console.ReadLine();
                                    if (k.KonyvElerheto_kolcs(konyv_id))
                                    {
                                        kolcs.AddKonyv(konyv_id, k);
                                    }
                                    else
                                    {
                                        Console.WriteLine("A megadott azonositoval konyv nem kolcsonozheto!");
                                        i--;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Nincs elég kölcsönözhető könyv!");
                                }
                            }
                            Olvaso o = f.GetObjectByID(olvasoId) as Olvaso;
                            o.AddKolcsonzes(kolcs);
                            Console.WriteLine("Kolcsonzes sikeres!");
                            
                        }
                        else
                        {
                            Console.WriteLine("A beolvasott erteknek 1 es 10 kozotti szamnak kell lennie es nem lehet nagyobb a keszlet, valamint a kolcsonozheto konyvek darabszamanal!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("A beolvasott ertek nem megfelelo szam.");
                    }

                    //int intDarab = int.Parse(darab);
                    //for (int i = 0; i < intDarab; i++)
                    //{
                    //    Console.Write("Kerem a kolcsonozni kivant konyv id-jet: ");
                    //    string konyv_id = Console.ReadLine();
                    //    kolcs.AddKonyv(konyv_id, k);
                    //}
                    //if (intDarab > 0)
                    //{
                    //    Olvaso o = f.GetObjectByID(olvasoId) as Olvaso;
                    //    o.AddKolcsonzes(kolcs);
                    //    Console.WriteLine("Kolcsonzes sikeres!");
                    //}
                }
                else
                {
                    Console.Write("Helytelen azonosito!");
                }

            }
            else if (muv_szam == "005")
            {
                f.OlvasokatListaz();
                Console.Write("Adja meg az olvaso Id-jet: ");
                string olvasoID = Console.ReadLine();
                if (f.GetObjectByID(olvasoID) is Olvaso)
                {
                    Olvaso o = f.GetObjectByID(olvasoID) as Olvaso;
                    List<Kolcsonzes> kolcsonzesek = o.GetKolcsonzesek();
                    if (kolcsonzesek.Count() != 0)
                    {
                        o.KolcsonzesekKiir();
                        Console.Write("Melyik Id-ju konyvet kivanja torolni a kolcsonzesekbol? ");
                        string torlendoId = Console.ReadLine();
                        bool sikeres = false;
                        int torlendoindex = -1;

                        foreach (Kolcsonzes kolcs in kolcsonzesek)
                        {
                            if (kolcs.GetKonyvek() != null)
                            {
                                //foreach (Konyv konyv in kolcs.GetKonyvek())
                                //{
                                    //if (torlendoId == kolcs.GetKonyvek()[].GetKonyvID())
                                        torlendoindex = kolcs.KolcsonzesTeljesitve(torlendoId);
                                //}
                                if (torlendoindex != -1)
                                {
                                    kolcs.GetKonyvek().Remove(kolcs.GetKonyvek()[torlendoindex]);
                                    Console.WriteLine("A konyv torlese a kolcsonzesbol sikeres!");
                                    sikeres = true;
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nem talalhato konyv! ");
                            }                            
                        }

                        if (!sikeres)
                        {
                            Console.WriteLine("A konyv torlese a kolcsonzesbol sikertelen! A konyv nem talalhato!");
                        }

                        torlendoindex = -1;

                        for (int i = 0; i < kolcsonzesek.Count(); i++)
                        {
                            if (kolcsonzesek[i].GetKonyvek().Count == 0)
                            {
                                torlendoindex = i;
                                break;
                            }
                        }
                        if (torlendoindex != -1)
                        {

                            kolcsonzesek.Remove(kolcsonzesek[torlendoindex]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nincs kolcsonzes! ");
                    }
                }
                else
                {
                    Console.WriteLine("Helytelen a megadott Id! ");
                    KonyvtarosMuveletek(muv_szam, k, f);
                }
            }
            else if (muv_szam == "006")
            {
                k.ElerhetoKonyvek();
            }
            else
            {
                Console.WriteLine("Ervenytelen muvelet! ");
                Console.Write("Kerem a kivant muvelet szamat: ");
                muv_szam = Console.ReadLine();
                KonyvtarosMuveletek(muv_szam, k, f);
            }
        }

        public static void OlvasoMuveletek(string muv_szam, Keszlet k, Olvaso olvaso)
        {

            if (muv_szam == "001")
            {
                NagyKeresesSzures(k);
            }
            else if (muv_szam == "002")
            {
                k.ElerhetoKonyvek();
            }
            else if (muv_szam == "003")
            {

                NagyKeresesSzures(k);
                DateTime maiDatum = DateTime.Now;
                string formataltDatum = maiDatum.ToString("yyyy.MM.dd");
                string olvasoId = olvaso.GetID();
                Elojegyzes e = new Elojegyzes(formataltDatum, olvasoId);

                Console.Write("Hany darab konyvet szeretnel elojegyeztetni? ");
                string darab = Console.ReadLine();
                int intDarab;
                bool eredmeny = Int32.TryParse(darab, out intDarab);
                if (eredmeny)
                {
                    if (intDarab > 0 && intDarab < 11 && intDarab < k.GetList().Count())
                    {
                        for (int i = 0; i < intDarab; i++)
                        {
                            Console.Write("Kerem az elojegyezni kivant konyv id-jet: ");
                            string konyv_id = Console.ReadLine();
                            if (k.KonyvElerheto_eloj(konyv_id))
                            {
                                e.AddKonyv(konyv_id, k);
                            }
                            else
                            {
                                Console.WriteLine("A megadott azonositoval konyv nem elojegyezheto!");
                                i--;
                            }
                        }
                        Console.WriteLine("Elojegyzes sikeres!");
                    }
                    else
                    {
                        Console.WriteLine("A beolvasott erteknek 1 és 10 kozotti szamnak kell lennie es nem lehet nagyobb a keszlet darabszamanal!");
                    }
                }
                else 
                {
                    Console.WriteLine("A beolvasott ertek nem megfelelo szam.");
                }

            }
            else if (muv_szam == "004")
            {
                olvaso.Fizetes();
                
            }
            else if (muv_szam == "005")
            {
                olvaso.KolcsonzesekKiir();
                Console.WriteLine("Melyik kolcsonzest szeretne meghosszabbitani? Adja meg az azonositojat: ");
                string azon = Console.ReadLine();
                Kolcsonzes kolcs = olvaso.GetKolcsById(azon);

                if (kolcs != null)
                {
                    kolcs.Hosszabbitas();
                }
                else
                {
                    Console.WriteLine("Nincs ilyen azonositoju kolcsonzes!");
                }
            }
            else if (muv_szam == "006")
            {
                olvaso.KolcsonzesekKiir();
            }
            else
            {
                Console.WriteLine("Ervenytelen muvelet! ");
                Console.Write("Kerem a kivant muvelet szamat: ");
                muv_szam = Console.ReadLine();
                OlvasoMuveletek(muv_szam, k, olvaso);
            }
        }

        public static void NagyKeresesSzures(Keszlet k)
        {
            string id_szuro, cim_szuro, szerzo_szuro, kiado_szuro, nyelv_szuro, kategoria_szuro, ertek, ertek2, kiadas_eve_szuro, kolcsonzott_szuro, elojegyzett_szuro;

            Console.WriteLine("Szurofeltetelek megadasa (0 = nincs szures)");
            Console.Write("Id megadasa: ");
            id_szuro = Console.ReadLine();
            Console.Write("Cim megadasa: ");
            cim_szuro = Console.ReadLine();
            Console.Write("Szerzo megadasa: ");
            szerzo_szuro = Console.ReadLine();
            Console.Write("Kiado megadasa: ");
            kiado_szuro = Console.ReadLine();
            Console.Write("Kiadas evenek megadasa: ");
            kiadas_eve_szuro = Console.ReadLine();
            Console.Write("Nyelv megadasa: ");
            nyelv_szuro = Console.ReadLine();
            Console.Write("Kategoria megadasa: ");
            kategoria_szuro = Console.ReadLine();
            Console.Write("Kolcsonzott megadasa(i/h): ");
            ertek = Console.ReadLine();
            kolcsonzott_szuro = "0";
            if (ertek == "0")
            {
                kolcsonzott_szuro = "0";
            }
            else if (ertek == "i")
            {
                kolcsonzott_szuro = "true";
            }
            else if (ertek == "h")
            {
                kolcsonzott_szuro = "false";
            }
            else if (ertek == "")
            {
                kolcsonzott_szuro = "";
            }
            else
            {
                kolcsonzott_szuro = "ervenytelen";
            }
            Console.Write("Elojegyzett megadasa(i/h): ");
            ertek2 = Console.ReadLine();
            elojegyzett_szuro = "0";
            if (ertek2 == "0")
            {
                elojegyzett_szuro = "0";
            }
            else if (ertek2 == "i")
            {
                elojegyzett_szuro = "true";
            }
            else if (ertek2 == "h")
            {
                elojegyzett_szuro = "false";
            }
            else if (ertek2 == "")
            {
                elojegyzett_szuro = "";
            }
            else
            {
                kolcsonzott_szuro = "ervenytelen";
            }
            if (id_szuro == "" || cim_szuro == "" || szerzo_szuro == "" || kiado_szuro == "" || kiadas_eve_szuro == "" || nyelv_szuro == ""
                || kategoria_szuro == "" || elojegyzett_szuro == "" || kolcsonzott_szuro == "")
            {
                Console.WriteLine("Ures parameter! ");
            }
            else if (elojegyzett_szuro == "ervenytelen" || kolcsonzott_szuro == "ervenytelen")
            {
                Console.WriteLine("Ervenytelen parameter! ");
            }
            else
            {
                k.KeresesSzures(id_szuro, cim_szuro, szerzo_szuro, kiado_szuro, nyelv_szuro, kategoria_szuro, kiadas_eve_szuro,
                 kolcsonzott_szuro, elojegyzett_szuro);
            }
        }

    }
}
