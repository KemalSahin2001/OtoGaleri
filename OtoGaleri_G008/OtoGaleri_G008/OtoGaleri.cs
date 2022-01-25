using System;
using System.Collections.Generic;

namespace OtoGaleri_G008
{
    class OtoGaleri
    {
        public List<Araba> Arabalar { get; set; }
        public int ToplamAracSayisi { get { return Arabalar.Count; } }
        public int ToplamAracKiralamaSuresi
        {
            get
            {
                int toplamSure = 0;
                foreach (var item in Arabalar)
                {
                    int itemSure = 0;
                    foreach (var kira in item.Kiralanmalar)
                    {
                        itemSure += kira.Sure;
                    }
                    toplamSure += itemSure;
                }
                return toplamSure;
            }
        }
        public int ToplamAracKiralamaAdedi
        {
            get
            {
                int toplamAdet = 0;
                foreach (var item in Arabalar)
                {
                    toplamAdet += item.Kiralanmalar.Count;
                }
                return toplamAdet;
            }
        }
        public double Ciro
        {
            /*get
            {
                float toplamKazanc = 0;
                foreach (var item in Arabalar)
                {
                    int itemSure = 0;
                    foreach (var kira in item.Kiralanmalar)
                    {
                        itemSure += kira.Sure;
                    }
                    toplamKazanc += (item.KiralamaBedeli * itemSure);
                }
                return toplamKazanc;
            }*/
            get; set;
        }
        public OtoGaleri()
        {
            Arabalar = new List<Araba>();
            SahteVeri();
        }
        public void SahteVeri()
        {
            Arabalar.Add(new Araba("34AB1234", "FIAT", 100, ARAC_TIPI.SEDAN));
            Arabalar.Add(new Araba("16AB1223", "PORSCHE", 500, ARAC_TIPI.SUV));
            Arabalar.Add(new Araba("35AB4321", "VOLKSWAGEN", 250, ARAC_TIPI.SEDAN));
            Arabalar.Add(new Araba("07ABC1214", "AUDI", 350, ARAC_TIPI.HATCHBACK));
        }
        public bool AracKirala(string plaka)
        {
            bool sonuc = false;
            foreach (var item in Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    if (item.Durum == DURUM.KIRADA)
                    {
                        Console.WriteLine("Araç müsait değil. Başka bir araç seçin");
                        return false;
                    }
                    else
                    {
                        Console.Write("Kiralama süresi: ");
                        int sure = int.Parse(Console.ReadLine());
                        Kira yeniKira = new Kira();
                        yeniKira.Sure = sure;
                        yeniKira.Tarih = DateTime.Now;
                        item.Kiralanmalar.Add(yeniKira);
                        item.Durum = DURUM.KIRADA;
                        this.Ciro += item.KiralamaBedeli * sure;
                        Console.WriteLine("\n{0} Plakalı araç {1} saatliğine kiralandı.", item.Plaka, sure);
                        Console.WriteLine();
                        return true;
                    }
                }
            }
            if (!sonuc)
            {
                Console.WriteLine("Giriş Tanımlanamadı.Tekrar deneyin.");
                return false;
            }
            return false;
        }
        public bool AracKirala(ARAC_TIPI aracTipi)
        {
            bool sonuc = false;
            foreach (var item in Arabalar)
            {
                if (item.AracTipi == aracTipi)
                {
                    sonuc = true;
                    if (item.Durum == DURUM.KIRADA)
                    {
                        sonuc = false;
                    }
                    else
                    {
                        Console.Write("Kiralama süresi: ");
                        int sure = int.Parse(Console.ReadLine());
                        Kira yeniKira = new Kira();
                        yeniKira.Sure = sure;
                        yeniKira.Tarih = DateTime.Now;
                        item.Kiralanmalar.Add(yeniKira);
                        item.Durum = DURUM.KIRADA;
                        this.Ciro += item.KiralamaBedeli * sure;
                        Console.WriteLine("\n{0} Plakalı araç {1} saatliğine kiralandı.", item.Plaka, sure);
                        Console.WriteLine();
                        return true;
                    }
                }
            }
            if (!sonuc)
            {
                Console.WriteLine("Araç müsait değil. Başka bir araç seçin");
                return false;
            }
            return false;
        }
        public bool KiralamaIptal(string plaka)
        {
            Console.WriteLine();
            bool sonuc = false;
            foreach (var item in Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    sonuc = true;
                    if (item.Durum == DURUM.GALERIDE)
                    {
                        Console.WriteLine("Hatalı giriş yapıldı. Araç zaten galeride.");
                        return false;
                    }
                    else
                    {
                        int sure = 0;
                        item.Durum = DURUM.GALERIDE;
                        sure = item.Kiralanmalar[item.Kiralanmalar.Count - 1].Sure;
                        this.Ciro -= item.KiralamaBedeli * sure;
                        item.Kiralanmalar.RemoveAt(item.Kiralanmalar.Count - 1);
                        Console.WriteLine("İptal Gerçekleştirildi.");
                        return true;
                    }
                }
            }
            if (!sonuc)
            {
                Console.WriteLine("Galeriye ait bu plakada araç yok.");
                return false;
            }
            return sonuc;

        }
        public void AracEkle()
        {
            string Plaka;
        plaka:
            Console.Write("Plaka: ");
            Plaka = Console.ReadLine();
            bool sonuc = false;
            foreach (var item in Arabalar)
            {
                if (item.Plaka == Plaka.ToUpper())
                {
                    sonuc = true;
                    break;
                }
            }
            if (sonuc)
            {
                Console.WriteLine("Aynı plakada araç mevcut. Girdiğiniz plakayı kontrol edin.");
                goto plaka;
            }
            Console.Write("Marka: ");
            string Marka = Console.ReadLine();
            Console.Write("KiralamaBedeli: ");
            int kiralamaBedeli = int.Parse(Console.ReadLine());
            Console.Write("Araç Tipleri:\n-{0} için 1\n-{1} için 2\n-{2} için 3\nAraç Tipi: ", ARAC_TIPI.SUV, ARAC_TIPI.HATCHBACK, ARAC_TIPI.SEDAN);
            int aracTip = int.Parse(Console.ReadLine());
            ARAC_TIPI aracTipi = (ARAC_TIPI)(Enum.GetValues(ARAC_TIPI.SEDAN.GetType())).GetValue(aracTip - 1);
            Arabalar.Add(new Araba(Plaka.ToUpper(), Marka.ToUpper(), kiralamaBedeli, aracTipi));
            Console.WriteLine("Araç başarılı bir şekilde eklendi.");
        }
        public void AracSil()
        {
            string Plaka;
        plaka:
            Console.Write("Silinecek aracın plakası: ");
            Plaka = Console.ReadLine();
            bool sonuc = false;
            foreach (var item in Arabalar)
            {
                if (item.Plaka == Plaka.ToUpper())
                {
                    sonuc = true;
                    Arabalar.Remove(item);
                    Console.WriteLine("\nAraç başarı bir şekilde silindi.");
                    return;
                }
            }
            if (!sonuc)
            {
                Console.WriteLine("Aynı plakada araç mevcut değil. Lütfen plakayı kontrol edin.");
                goto plaka;
            }
        }
        public void GaleriBilgileri()
        {
            Console.WriteLine("Toplam Araç Sayısı: " + this.ToplamAracSayisi);
            int kiradakiArac = 0;
            foreach (var item in Arabalar)
            {
                if (item.Durum == DURUM.KIRADA)
                {
                    kiradakiArac++;
                }
            }
            Console.WriteLine("Kiradaki Araç Sayısı: " + kiradakiArac);
            Console.WriteLine("Bekleyen Araç Sayısı: " + (this.ToplamAracSayisi - kiradakiArac));
            Console.WriteLine("Toplam araç kiralama süresi: " + this.ToplamAracKiralamaSuresi);
            Console.WriteLine("Toplam araç kiralama adedi: " + this.ToplamAracKiralamaAdedi);
            Console.WriteLine("Ciro: " + this.Ciro);
        }
        public bool AracTeslimAl(string plaka)
        {
            bool sonuc = false;
            foreach (var item in Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    sonuc = true;
                    if (item.Durum == DURUM.GALERIDE)
                    {
                        Console.WriteLine("Hatalı giriş yapıldı. Araç zaten galeride.");
                        return false;
                    }
                    else
                    {
                        item.Durum = DURUM.GALERIDE;
                        Console.WriteLine("\nAraç galeride beklemeye alındı.");
                        return true;
                    }
                }
            }
            if (!sonuc)
            {
                Console.WriteLine("Galeriye ait bu plakada bir araç yok.");
                return false;
            }
            return sonuc;
        }
        public void TumAraclar()
        {
            Console.WriteLine();
            string ustMetin = "Plaka".PadRight(15) + "Marka".PadRight(15) + "K. Bedeli".PadRight(15) + "Araç Tipi".PadRight(15) + "K. Sayısı".PadRight(15) + "Durum".PadRight(13);
            Console.WriteLine(ustMetin);
            for (int i = 0; i < ustMetin.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("\n");
            foreach (var item in Arabalar)
            {
                Console.WriteLine(item.Plaka.PadRight(15) + item.Marka.PadRight(15) + item.KiralamaBedeli.ToString().PadRight(15) + item.AracTipi.ToString().PadRight(15) + item.Kiralanmalar.Count.ToString().PadRight(15) + (item.Durum.ToString().Substring(0, 1).ToUpper() + item.Durum.ToString().Substring(1).ToLower()).PadRight(13));

            }
            Console.WriteLine();
        }
        public void TumAraclar(DURUM durum)
        {
            bool sonuc = false;
            Console.WriteLine();
            string ustMetin = "Plaka".PadRight(15) + "Marka".PadRight(15) + "K. Bedeli".PadRight(15) + "Araç Tipi".PadRight(15) + "K. Sayısı".PadRight(15) + "Durum".PadRight(13);
            Console.WriteLine(ustMetin);
            for (int i = 0; i < ustMetin.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("\n");
            foreach (var item in Arabalar)
            {
                if (item.Durum == durum)
                {
                    sonuc = true;
                    Console.WriteLine(item.Plaka.PadRight(15) + item.Marka.PadRight(15) + item.KiralamaBedeli.ToString().PadRight(15) + item.AracTipi.ToString().PadRight(15) + item.Kiralanmalar.Count.ToString().PadRight(15) + (item.Durum.ToString().Substring(0, 1).ToUpper() + item.Durum.ToString().Substring(1).ToLower()).PadRight(13));

                }
            }
            if (!sonuc)
            {
                if (DURUM.GALERIDE == durum)
                {
                    Console.WriteLine("Galeride araç bulunmamaktadir.");
                }
                else
                {
                    Console.WriteLine("Kirada araç bulunmamaktadir.");
                }
            }
            Console.WriteLine();

        }
    }
}
