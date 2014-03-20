using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuincentrumBase
{
    public class Plant
    {
        private String plantNaam;
        private int plantNr;
        private int levNr;
        private Decimal prijs;
        private String kleur;
        public String PlantNaam
        {
            get { return plantNaam; }
            set { plantNaam = value; }
        }
        public int PlantNr
        {
            get { return plantNr; }
            set { plantNr = value; }
        }
        public int LevNr
        {
            get { return levNr; }
            set { levNr = value; }
        }
        public Decimal Prijs
        {
            get { return prijs; }
            set { prijs = value; }
        }
        public String Kleur
        {
            get { return kleur; }
            set { kleur = value; }
        }

        public Plant(String nPlantNaam, int nPlantNr, int nLevNr, Decimal nPrijs, String nKleur)
        {
            PlantNaam = nPlantNaam;
            PlantNr = nPlantNr;
            LevNr = nLevNr;
            Prijs = nPrijs;
            Kleur = nKleur;
        }
        public Plant() { }

        public override string ToString()
        {
            return PlantNaam;
        }
    }
}
