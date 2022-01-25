using System;
using System.Collections.Generic;
using System.Text;

namespace OtoGaleri_G008
{
    
    class Araba
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public float KiralamaBedeli { get; set; }
        public ARAC_TIPI AracTipi { get; set; }
        public List<Kira> Kiralanmalar { get; set; }
        public DURUM Durum { get; set; }
        public Araba(string plaka, string marka, int kiralamaBedeli, ARAC_TIPI aracTipi)
        {
            this.Plaka = plaka;
            this.Marka = marka;
            this.KiralamaBedeli = (float) kiralamaBedeli;
            this.AracTipi = aracTipi;
            this.Durum = DURUM.GALERIDE;
            this.Kiralanmalar = new List<Kira>();
        }
    }
    
    public enum DURUM
    {
        KIRADA,
        GALERIDE
    }

    public enum ARAC_TIPI
    {
        SUV,
        HATCHBACK,
        SEDAN
    }

}
