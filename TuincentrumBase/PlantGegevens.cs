using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuincentrumBase
{
    public class PlantGegevens
    {
        private String naamValue;
        private String soortValue;
        private String leverancierValue;
        private String kleurValue;
        private Decimal kostprijsValue;
        public String Naam
        {
            get { return naamValue; }
            set { naamValue = value; }
        }
        public String Soort
        {
            get { return soortValue; }
            set { soortValue = value; }
        }
        public String Leverancier
        {
            get { return leverancierValue; }
            set { leverancierValue = value; }
        }
        public String Kleur
        {
            get { return kleurValue; }
            set { kleurValue = value; }
        }
        public Decimal Kostprijs
        {
            get { return kostprijsValue; }
            set { kostprijsValue = value; }
        }

        public PlantGegevens(String nNaam, String nSoort, String nLeverancier, String nKleur, Decimal nKostprijs)
        {
            Naam = nNaam;
            Soort = nSoort;
            Leverancier = nLeverancier;
            Kleur = nKleur;
            Kostprijs = nKostprijs;
        }
    }
}
