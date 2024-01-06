using System;
using System.IO;
using Newtonsoft.Json;

namespace Konyvtarrendszer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string kivesz = "false";
            Felhasznalok f = new Felhasznalok();
            List<Olvaso> olvasok = new List<Olvaso>();
            Keszlet k = new Keszlet();
            List<Kolcsonzes> kolcs = new List<Kolcsonzes>();

            // beolvasas - konyvek
            using (StreamReader reader = new StreamReader("konyv.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string sor = reader.ReadLine();

                    string[] darab = sor.Split(";");

                    string azonosito = darab[0];
                    string cim = darab[1];
                    string szerzo = darab[2];
                    string kiado = darab[3];
                    int kiadas_eve = Convert.ToInt32(darab[4]);
                    string nyelv = darab[5];
                    string kategoria = darab[6];
                    bool kolcsonzott_e = Convert.ToBoolean(darab[7]);
                    bool elojegyzett_e = Convert.ToBoolean(darab[8]);

                    Konyv konyv = new Konyv(azonosito, cim, szerzo, kiado, kiadas_eve, nyelv, kategoria, kolcsonzott_e, elojegyzett_e);
                    k.CreateKonyv(konyv);
                }
            }

            // beolvasas - felhasznalok

            using (StreamReader reader = new StreamReader("felhasznalo.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string sor = reader.ReadLine();

                    string[] darab = sor.Split(";");

                    //név, azonosító, lakcím, telefonszám, email, jelszó, jogosultság, beosztás, fizetendő tagdíj és fizetendő kölcsönzési díj

                    string nev = darab[0];
                    string azonosito = darab[1];
                    string lakcim = darab[2];
                    string telszam = darab[3];
                    string email = darab[4];
                    string jelszo = darab[5];
                    string jogosultsag = darab[6];
                    
                    if (jogosultsag == "konyvtaros")
                    {
                        string beosztas = darab[7];
                        Konyvtaros konyvtaros = new Konyvtaros(beosztas, nev, azonosito, lakcim, telszam, email, jelszo, jogosultsag);
                        f.CreateFelhasznalo(konyvtaros);

                    }
                    else if (jogosultsag == "admin")
                    {
                        string beosztas = darab[7];
                        Adminisztrator admin = new Adminisztrator(beosztas, nev, azonosito, lakcim, telszam, email, jelszo, jogosultsag);
                        f.CreateFelhasznalo(admin);
                    }
                }
            }

            // beolvasas - olvasok
            
            string json = System.IO.File.ReadAllText("adatok.json");
            List<Olvaso> olvasok_be = JsonConvert.DeserializeObject<List<Olvaso>>(json);

            // Most már rendelkezel a deszerializált objektumok listájával
            foreach (var olv1 in olvasok_be)
            {
                Olvaso op = new Olvaso(olv1.Tagdij, olv1.Kesedelmi,
                    olv1.Nev, olv1.ID, olv1.Lakcim, olv1.Tel, olv1.Email,
                    olv1.Jelszo, olv1.Jogosultsag);
                foreach (var kolcsonz in olv1.Kolcsonzes)
                {
                    Kolcsonzes kolcsp = new Kolcsonzes();
                    kolcsp.SetKolcsDatum(kolcsonz.Kolcsonzes_datum);
                    kolcsp.SetLeDatum(kolcsonz.Lejarat_datum);
                    kolcsp.SetOlvId(kolcsonz.Olvaso_id);
                    kolcsp.SetKolcsId(kolcsonz.Kolcs_id);
                    {
                        foreach (var kp in kolcsonz.Konyvek)
                        {
                            //Console.WriteLine("egy konyvet hozzaad");
                            kolcsp.AddKonyv(kp.Konyv_id, k);
                            
                        }


                        op.AddKolcsonzes(kolcsp);
                    }
                    olvasok.Add(op);
                }

                f.CreateFelhasznalo(op);

            }

            while (true)
            {
            Bejelentkezes:
                Console.Clear();
                Felhasznalo felhasznalo = Menu.Login_Logout(f);
                string tipus = felhasznalo.GetJogosultsag();
            Iranyitopult:
                Console.Clear();
                string muveletszam = Menu.Muveletek(tipus);
                Menu.Iranyito(tipus, muveletszam, f, k, felhasznalo);

                Console.WriteLine("Munkamenet folytatasa [ENTER]");
                Console.WriteLine("Kijelentkezes [ESC]");
                ConsoleKey bevitel;
                do
                {
                    bevitel = Console.ReadKey(true).Key;
                    Console.Clear();
                    switch (bevitel)
                    {
                        case ConsoleKey.Enter:
                            goto Iranyitopult;

                        case ConsoleKey.Escape:
                            
                            // json torol
                            try
                            {
                                // Ellenőrzés, hogy a fájl létezik-e
                                string filePath = "adatok.json";
                                if (File.Exists(filePath))
                                {
                                    File.Delete(filePath); // Fájl törlése
                                    //Console.WriteLine("A JSON fájl sikeresen törölve.");
                                }
                                else
                                {
                                    Console.WriteLine("A fájl nem létezik.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Hiba történt a fájl törlése közben: {ex.Message}");
                            }

                            // uj json
                            olvasok.Clear();
                            foreach(Felhasznalo felhasznalo01 in f.GetList())
                            {
                                if(felhasznalo01 is Olvaso)
                                {
                                    olvasok.Add(felhasznalo01 as Olvaso);
                                }
                            }


                            List<object> adatokLista = new List<object>();

                            foreach (Olvaso o in olvasok)
                            {
                                //Console.WriteLine("belep");
                                var kolcsonzesekLista = new List<object>();
                                foreach (Kolcsonzes ko in o.GetKolcsonzesek())
                                {
                                    var konyveklista = new List<object>();
                                    foreach (Konyv konyv in ko.GetKonyvek())
                                    {
                                        //ko.getkonyvek-ben 1 konyv
                                        //Console.WriteLine("Egy könyvet kivesz");
                                        var konyv1 = new
                                        {
                                            Konyv_id = konyv.GetKonyvID(),
                                            Cim = konyv.GetCim(),
                                            Szerzo = konyv.GetSzerzo(),
                                            Kiado = konyv.GetKiado(),
                                            Kiadas_eve = konyv.GetKiadasEve(),
                                            Nyelv = konyv.GetNyelv(),
                                            Kategoria = konyv.GetKategoria(),
                                            Kolcsonzott = konyv.GetKolcsonzott(),
                                            Elojegyzett = konyv.GetElojegyzett()
                                        };
                                        konyveklista.Add(konyv1);
                                    }
                                    var kolcs_var = new
                                    {
                                        Konyvek = konyveklista,
                                        Kolcsonzes_datum = ko.GetKolcsDatum(),
                                        Lejarat_datum = ko.GetLejarDatum(),
                                        Olvaso_id = ko.GetOlvasoId(),
                                        Kolcs_id = ko.GetKolcsId()
                                    };
                                    kolcsonzesekLista.Add(kolcs_var);
                                }
                                var adatok = new
                                {
                                    Tagdij = o.GetTagdijFizetendo(),
                                    Kesedelmi = o.GetKesedelmiFizetendo(),
                                    Nev = o.GetNev(),
                                    ID = o.GetID(),
                                    Lakcim = o.GetLakcim(),
                                    Tel = o.GetTelefonszam(),
                                    Email = o.GetEmail(),
                                    Jelszo = o.GetJelszo(),
                                    Jogosultsag = o.GetJogosultsag(),
                                    Kolcsonzes = kolcsonzesekLista
                                };

                                adatokLista.Add(adatok);
                            }

                            // JSON fájl létrehozása és adatok beleírása
                            var jsonAdatok = JsonConvert.SerializeObject(adatokLista, Formatting.Indented);
                            File.WriteAllText("adatok.json", jsonAdatok);


                            // felhasznalok kiir

                            using (StreamWriter writer = new StreamWriter("felhasznalo.txt"))
                            {
                                foreach (Felhasznalo felhaszn in f.GetList())
                                {
                                    /*
                                    if (felhaszn is Olvaso)
                                    {
                                        Olvaso olvaso = felhaszn as Olvaso;
                                        writer.WriteLine(olvaso.getObjectAsString());
                                    }*/

                                    if (felhaszn is Konyvtaros)
                                    {
                                        Konyvtaros konyvt = felhaszn as Konyvtaros;
                                        writer.WriteLine(konyvt.GetObjectAsString());
                                    }


                                    if (felhaszn is Adminisztrator)
                                    {
                                        Adminisztrator admin = felhaszn as Adminisztrator;
                                        writer.WriteLine(admin.GetObjectAsString());
                                    }
                                }
                            }

                            // konyvek kiir

                            using (StreamWriter writer = new StreamWriter("konyv.txt"))
                            {
                                foreach (Konyv konyv in k.GetList())
                                {
                                    writer.WriteLine(konyv.GetObjectAsString());
                                }

                            }
                           
                            goto Bejelentkezes;
                        
                    }
                } while (bevitel != ConsoleKey.Enter && bevitel != ConsoleKey.Escape);
            }

        }
    }
}
