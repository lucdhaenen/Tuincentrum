using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuincentrumBase
{
    public class Leverancier
    {
        private Int32 levNrValue;
        private string naamValue;
        private string adresValue;
        private string postNrValue;
        private string woonplaatsValue;

        public Int32 LevNr
        { get { return levNrValue; } }

        public string Naam
        {
            get { return naamValue; }
            set { naamValue = value; }
        }

        public string Adres
        {
            get { return adresValue; }
            set { adresValue = value; }
        }

        public string PostNr
        {
            get { return postNrValue; }
            set { postNrValue = value; }
        }

        public string Woonplaats
        {
            get { return woonplaatsValue; }
            set { woonplaatsValue = value; }
        }

        public Leverancier(Int32 levNr, string naam, string adres, string postNr, string woonplaats)
        {
            levNrValue = levNr;
            this.Naam = naam;
            this.Adres = adres;
            this.PostNr = postNr;
            this.Woonplaats = woonplaats;
        }
    }
}
