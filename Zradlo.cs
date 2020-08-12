using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Had
{
    public class Zradlo
    {
        public List<DilekZradla> Dilky = new List<DilekZradla>();
        public void Vykresli()
        {
            int pocetDilku = Dilky.Count();
            for (int n = 0; n < pocetDilku; n++)
            {
                Dilky[n].Vykresli();
            }
        }
        public void PridejDilek()
        {
            Dilky.Add(new DilekZradla());
        }
    }
}
