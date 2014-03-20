using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuincentrumBase
{
    public class Soort
    {
        private String soortNaamValue;
        private int soortNrValue;
        public String SoortNaam
        {
            get { return soortNaamValue; }
            set { soortNaamValue = value; }
        }
        public int SoortNr
        {
            get { return soortNrValue; }
            set { soortNrValue = value; }
        }
        public Soort(String nSoort, int nSoortNr)
        {
            SoortNaam = nSoort;
            SoortNr = nSoortNr;
        }
        public override String ToString()
        {
            return SoortNaam;
        }
    }
}
