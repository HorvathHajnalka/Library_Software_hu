using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtarrendszer
{
    public abstract class Felhasznalo
    {
        protected string nev;
        protected string userId;
        protected string lakcim;
        protected string telefonszam;
        protected string email;
        protected string jelszo;
        protected string jogosultsag;
        //protected string beosztas;

        public Felhasznalo(string _nev, string _userId, string _lakcim, string _telefonszam, string _email, string _jelszo, string _jogosultsag)
        {
            nev = _nev;
            userId = _userId;
            lakcim = _lakcim;
            telefonszam = _telefonszam;
            email = _email;
            jelszo = _jelszo;
            jogosultsag = _jogosultsag;
        }

        public string GetNev() { return nev; }
        public string GetJelszo() { return jelszo; }
        public string GetJogosultsag() { return jogosultsag; }
        public string GetLakcim() { return lakcim; }
        public string GetTelefonszam() { return telefonszam; }
        public string GetEmail() { return email; }
        public string GetID() { return userId; }

        public void SetNev(string _nev) { nev = _nev; }
        public void SetUserId(string _userId) { userId = _userId; }
        public void SetLakcim(string _lakcim) { lakcim = _lakcim; }
        public void SetTelefonszam(string _telefonszam) { telefonszam = _telefonszam; }
        public void SetEmail(string _email) { email = _email; }
        public void SetJelszo(string _jelszo) { jelszo = _jelszo; }
        public void SetJogosultsag(string _jogosultsag) { jogosultsag = _jogosultsag; }        
        
    }
}
