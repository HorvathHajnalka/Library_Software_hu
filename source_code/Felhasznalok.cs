using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtarrendszer
{
    public class Felhasznalok
    {
        private List<Felhasznalo> felhasznalok = new List<Felhasznalo>();

        public void CreateFelhasznalo(Felhasznalo felhasznalo)
        {
            felhasznalok.Add(felhasznalo);
            //adatok irasa a fajlba
            
        }

        public void Add(Felhasznalo felhasznalo) {
            felhasznalok.Add(felhasznalo);
        }

        public void DeleteFelhasznalo(string userId)
        {
            
            int torlendoindex = -1;

            for (int i = 0; i < felhasznalok.Count(); i++)
            {
                if (felhasznalok[i].GetID() == userId)
                {
                    torlendoindex = i;
                }
            }

            if (torlendoindex != -1)
            {
                felhasznalok.Remove(felhasznalok[torlendoindex]);
                Console.WriteLine("Felhasznalo torlese sikeres!");
            }
            else
            {
                Console.WriteLine("Felhasznalo torlese sikertelen! A felhasznalo nem talalhato!");
            }
            


            /*
            Felhasznalo felhasznalo = felhasznalok.Find(f => f.GetID() == userId);

            if (felhasznalo != null)
            {
                felhasznalok.Remove(felhasznalo);
                Console.WriteLine($"{userId} felhasználó törlése sikeres!");
            }
            else
            {
                Console.WriteLine($"{userId} felhasználó nem található!");
            }*/
        }

        public void UpdateFelhasznalo()
        {
            Console.Write("Modositando felhasznalo azonositoja: ");
            string id = Console.ReadLine();
            int modositandoIndex = GetIndexByID(id);
            if (modositandoIndex != -1) {
                string muveletszam;

                Console.WriteLine("Nev modositas: 031");
                Console.WriteLine("ID modositas: 032");
                Console.WriteLine("Lakcim modositas: 033");
                Console.WriteLine("Telefonszam modositas: 034");
                Console.WriteLine("Email modositas: 035");
                Console.WriteLine("Jelszo modositas: 036");
                Console.WriteLine("Jogosultsag modositas: 037");
                if (felhasznalok[modositandoIndex].GetJogosultsag() == "admin" || felhasznalok[modositandoIndex].GetJogosultsag() == "konyvtaros")
                {
                    Console.WriteLine("Beosztas modositas: 038");
                }
                if (felhasznalok[modositandoIndex].GetJogosultsag() == "olvaso")
                {
                    Console.WriteLine("Tagdij hozzaadas: 039");
                    Console.WriteLine("Kesedelmi dij hozzaadas: 040");
                }
                Console.Write("Kerem a kivant muvelet szamat: ");
                muveletszam = Console.ReadLine();

                if (muveletszam == "031")
                {
                    Console.Write("Uj nev: ");
                    string uj_nev = Console.ReadLine();
                    if (uj_nev != "")
                    {
                        felhasznalok[modositandoIndex].SetNev(uj_nev);
                        Console.WriteLine("Sikeres modositas!");
                    }
                    else
                    {
                        Console.WriteLine("Sikertelen modositas!");
                    }
                }
                else if (muveletszam == "032")
                {
                    Console.Write("Uj ID: ");
                    string uj_id = Console.ReadLine();
                    if (uj_id != "")
                    {
                        felhasznalok[modositandoIndex].SetUserId(uj_id);
                        Console.WriteLine("Sikeres modositas!");
                    }
                    else 
                    {
                        Console.WriteLine("Sikertelen modositas!");
                    }
                    
                }
                else if (muveletszam == "033")
                {
                    Console.Write("Uj lakcim: ");
                    string uj_lakcim = Console.ReadLine();
                    if (uj_lakcim != "")
                    {
                        felhasznalok[modositandoIndex].SetLakcim(uj_lakcim);
                        Console.WriteLine("Sikeres modositas!");
                    }
                    else 
                    {
                        Console.WriteLine("Sikertelen modositas!");
                    }
                }
                else if (muveletszam == "034")
                {
                    Console.Write("Uj telefonszam: ");
                    string uj_tel = Console.ReadLine();
                    if (uj_tel != "")
                    {
                        felhasznalok[modositandoIndex].SetTelefonszam(uj_tel);
                        Console.WriteLine("Sikeres modositas!");
                    }
                    else 
                    {
                        Console.WriteLine("Sikertelen modositas!");
                    }
                        
                }
                else if (muveletszam == "035")
                {
                    Console.Write("Uj email: ");
                    string uj_email = Console.ReadLine();
                    if (uj_email != "")
                    {
                        felhasznalok[modositandoIndex].SetEmail(uj_email);
                        Console.WriteLine("Sikeres modositas!");
                    }
                    else 
                    {
                        Console.WriteLine("Sikertelen modositas!");
                    }
                    
                }
                else if (muveletszam == "036")
                {
                    Console.Write("Uj jelszo: ");
                    string uj_jelszo = Console.ReadLine();
                    if (uj_jelszo != "")
                    {
                        felhasznalok[modositandoIndex].SetJelszo(uj_jelszo);
                        Console.WriteLine("Sikeres modositas!");
                    }
                    else
                    {
                        Console.WriteLine("Sikertelen modositas!");
                    }
                }
                else if (muveletszam == "037")
                {
                    Console.Write("Uj jogosultsag: ");
                    string uj_jogosultsag = Console.ReadLine();
                    if (uj_jogosultsag == "admin" || uj_jogosultsag == "olvaso" || uj_jogosultsag == "konyvtaros")
                    {
                        felhasznalok[modositandoIndex].SetJogosultsag(uj_jogosultsag);
                        Console.WriteLine("Sikeres modositas!");
                    }
                    else
                    {
                        Console.WriteLine("Sikertelen modositas!");
                    }
                }
                else if (muveletszam == "038")
                {
                    Console.Write("Uj beosztas: ");
                    string uj_beosztas = Console.ReadLine();
                    if (uj_beosztas != "")
                    {
                        //nemtom, igy mmukszik-e
                        if(felhasznalok[modositandoIndex] is Adminisztrator)
                        {
                            Adminisztrator admin = felhasznalok[modositandoIndex] as Adminisztrator;
                            admin.SetBeosztas(uj_beosztas);
                            Console.WriteLine("Sikeres modositas!");
                        }
                        else if(felhasznalok[modositandoIndex] is Konyvtaros)
                        {
                            Konyvtaros konyvt = felhasznalok[modositandoIndex] as Konyvtaros;
                            konyvt.SetBeosztas(uj_beosztas);
                            Console.WriteLine("Sikeres modositas!");
                        }
                    }
                    else 
                    {
                        Console.WriteLine("Sikertelen modositas!");
                    }
                    
                }
                else if (muveletszam == "039")
                {
                    Console.Write("Hozzadando osszeg (tagdij): ");
                    double osszeg;
                    string input = Console.ReadLine();
                    if (Double.TryParse(input, out osszeg) && osszeg > 0.00)
                    {
                        Olvaso o = felhasznalok[modositandoIndex] as Olvaso;
                        o.SetTagdijFizetendo(Convert.ToDouble(osszeg));
                        Console.WriteLine("Sikeres modositas!");
                    }
                    else
                    {
                        Console.WriteLine("Sikertelen modositas!");
                    }
                    
                }
                else if (muveletszam == "040")
                {
                    Console.Write("Hozzadando osszeg (kesedelmi dij): ");
                    double osszeg;
                    string input = Console.ReadLine();
                    if (Double.TryParse(input, out osszeg) && osszeg > 0.00)
                    {
                        Olvaso o = felhasznalok[modositandoIndex] as Olvaso;
                        o.SetKesedelmiFizetendo(Convert.ToDouble(osszeg));
                        Console.WriteLine("Sikeres modositas!");
                    }
                    else
                    {
                        Console.WriteLine("Sikertelen modositas!");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Ervenytelen muvelet! ");
                    UpdateFelhasznalo();
                }
            }
            else
            {
                Console.WriteLine("Ervenytelen azonosito! ");
            }
        }

        public void FelhasznaloTipusSzamlalo()
        {
            int adminCount = 0, konyvtarosCount = 0, olvasoCount = 0;

            foreach (Felhasznalo felhasznalo in felhasznalok)
            {
                switch (felhasznalo.GetJogosultsag())
                {
                    case "admin":
                        adminCount++;
                        break;
                    case "konyvtaros":
                        konyvtarosCount++;
                        break;
                    case "olvaso":
                        olvasoCount++;
                        break;
                }
            }

            Console.WriteLine($"Admin: {adminCount} fo");
            Console.WriteLine($"Konyvtaros: {konyvtarosCount} fo");
            Console.WriteLine($"Olvaso: {olvasoCount} fo");
        }

        public void MindenkitListaz()
        {
            foreach (Felhasznalo felhasznalo in felhasznalok)
            {
                Console.WriteLine($"Jogosultsag: {felhasznalo.GetJogosultsag()}");
                Console.WriteLine($"Nev: {felhasznalo.GetNev()}");
                Console.WriteLine($"ID: {felhasznalo.GetID()}");
                Console.WriteLine($"Lakcim: {felhasznalo.GetLakcim()}");
                Console.WriteLine($"Telefonszam: {felhasznalo.GetTelefonszam()}");
                Console.WriteLine($"E-mail: {felhasznalo.GetEmail()}");
                if ( felhasznalo is Konyvtaros)
                {
                    Konyvtaros konyvtaros = felhasznalo as Konyvtaros;
                    Console.WriteLine($"Beosztas: {konyvtaros.GetBeosztas()}");
                }
                if ( felhasznalo is Adminisztrator)
                {
                    Adminisztrator admin = felhasznalo as Adminisztrator;
                    Console.WriteLine($"Beosztas: {admin.GetBeosztas()}");
                }
                if (felhasznalo is Olvaso)
                {
                    Olvaso olvaso = felhasznalo as Olvaso;
                    Console.WriteLine($"Fizetendo tagdij: {olvaso.GetTagdijFizetendo()}");
                    Console.WriteLine($"Fizetendo kesedelmi dij: {olvaso.GetKesedelmiFizetendo()}");
                }
                Console.WriteLine();
            }
        }

        public void OlvasokatListaz()
        {
            foreach (Felhasznalo felhasznalo in felhasznalok)
            {
                if (felhasznalo.GetJogosultsag() == "olvaso")
                {
                    Olvaso olvaso = felhasznalo as Olvaso;
                    Console.WriteLine($"Jogosultsag: {olvaso.GetJogosultsag()}");
                    Console.WriteLine($"Nev: {olvaso.GetNev()}");
                    Console.WriteLine($"ID: {olvaso.GetID()}");
                    Console.WriteLine($"Lakcim: {olvaso.GetLakcim()}");
                    Console.WriteLine($"Telefonszam: {olvaso.GetTelefonszam()}");
                    Console.WriteLine($"E-mail: {olvaso.GetEmail()}");
                    Console.WriteLine($"Fizetendo tagdij: {olvaso.GetTagdijFizetendo()}");
                    Console.WriteLine($"Fizetendo kesedelmi dij: {olvaso.GetKesedelmiFizetendo()}");
                    Console.WriteLine();
                }
            }
        }

        public Felhasznalo GetObjectByIndex(int index)
        {
            if (index >= 0 && index < felhasznalok.Count)
            {
                return felhasznalok[index];
            }
            return null;            
        }

        public Felhasznalo GetObjectByID(string ID)
        {
            foreach(Felhasznalo felhasznalo in felhasznalok)
            {
                if(felhasznalo.GetID() == ID)
                    return felhasznalo;
            }
            return null;
        }


        public string GetNameByIndex(int index)
        {
            if (index >= 0 && index < felhasznalok.Count)
            {
                return felhasznalok[index].GetNev();
            }
            return null;
        }

        public string GetPasswordByIndex(int index)
        {
            if (index >= 0 && index < felhasznalok.Count)
            {
                return felhasznalok[index].GetJelszo();
            }
            return null;
        }

        public string GetAuthorityByIndex(int index)
        {
            if (index >= 0 && index < felhasznalok.Count)
            {
                return felhasznalok[index].GetJogosultsag();
            }
            return null;
        }

        public string GetIDByIndex(int index)
        {
            if (index >= 0 && index < felhasznalok.Count)
            {
                return felhasznalok[index].GetID();
            }
            return null;
        }

        public int GetIndexByID(string id)
        {
            for (int i = 0; i < felhasznalok.Count; i++)
            {
                if (felhasznalok[i].GetID() == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetSize()
        {
            return felhasznalok.Count;
        }

        public List<Felhasznalo> GetList() { return  felhasznalok; }
    }
}
