using System;
using System.Collections.Generic;
using System.Text;

namespace OtoGaleri_G008
{
    class Uygulama
    {
        OtoGaleri OtoGaleri;
        public void Calistir()
        {
            Kur();
            SecimAl();
        }

        public void Kur()
        {
            OtoGaleri = new OtoGaleri();
            Console.WriteLine(@"Ekip üyeleri: Atanur Özkaldım, Emre Aydoğdu, Zeynep Küçük, Göktuğ Şahin
Galeri Otomasyon
1 - Araba Kirala(K)
2 - Araba Teslim Al(T)
3 - Kiradaki arabaları listele(R)
4 - Müsait arabaları listele(M)
5 - Tüm arabaları listele(A)
6 - Kiralama İptali(I)
7 - Yeli araba Ekle(Y)
8 - Araba sil(S)
9 - Bilgileri göster(G)");
        }
        public void SecimAl()
        {
            while (true)
            {

                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();
                Console.WriteLine();
                switch (secim.ToUpper())
                {
                    case "1":
                    case "K":
                        Console.WriteLine("-Araç Kirala-");
                        while (true)
                        {
                            Console.Write("Kiralanacak aracın plakası veya araç tipi: ");
                            string sonuc = Console.ReadLine().ToUpper();
                            ARAC_TIPI aracTipi;
                            if (Enum.TryParse(sonuc, true, out aracTipi))
                            {
                                if (OtoGaleri.AracKirala(aracTipi)) { break; }

                            }
                            else if (int.TryParse((sonuc.Substring(0, 2)), out int plakaBas) && (int.TryParse((sonuc.Substring(sonuc.Length - 4, 4)), out int plakaSon1) || int.TryParse((sonuc.Substring(sonuc.Length - 3, 3)), out int plakaSon2)))
                            {
                                if (OtoGaleri.AracKirala(sonuc)) { break; }
                            }
                            else { Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin."); }
                        }
                        break;
                    case "2":
                    case "T":
                        Console.WriteLine("-Araç Teslim-");
                        while (true)
                        {
                            Console.Write("Teslim edilecek aracın plakası: ");
                            string plaka = Console.ReadLine();
                            if (plaka.Length <= 6) { Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin"); }
                            else if (int.TryParse((plaka.Substring(0, 2)), out int plakaBas) && ((int.TryParse((plaka.Substring(plaka.Length - 4, 4)), out int plakaSon1)) || int.TryParse((plaka.Substring(plaka.Length - 3, 3)), out int plakaSon2)))
                            {
                                if (OtoGaleri.AracTeslimAl(plaka)) { break; }
                            }
                            else { Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin"); }
                        }

                        break;
                    case "3":
                    case "R":
                        Console.WriteLine("-Kiradaki tüm araçlar-");
                        OtoGaleri.TumAraclar(DURUM.KIRADA);
                        break;
                    case "4":
                    case "M":
                        Console.WriteLine("-Müsait tüm araçlar-");
                        OtoGaleri.TumAraclar(DURUM.GALERIDE);
                        break;
                    case "5":
                    case "A":
                        Console.WriteLine("-Tüm araçlar-");
                        OtoGaleri.TumAraclar();
                        break;
                    case "6":
                    case "I":
                        Console.WriteLine("-Kiralama iptali-");
                        while (true)
                        {
                            Console.Write("Kiralaması iptal edilecek aracın plakası: ");
                            string plaka = Console.ReadLine();
                            if (plaka.Length <= 7) { Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin"); }
                            else if (int.TryParse((plaka.Substring(0, 2)), out int plakaBas) && ((int.TryParse((plaka.Substring(plaka.Length - 4, 4)), out int plakaSon1)) || (int.TryParse((plaka.Substring(plaka.Length - 3, 3)), out int plakaSon2)) || int.TryParse((plaka.Substring(plaka.Length - 2, 2)), out int plakaSon3)))
                            {
                                if (OtoGaleri.KiralamaIptal(plaka)) { break; }
                            }
                            else { Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin"); }
                        }
                        break;
                    case "7":
                    case "Y":
                        Console.WriteLine("-Yeni Araç Ekle-");
                        OtoGaleri.AracEkle();
                        break;
                    case "8":
                    case "S":
                        Console.WriteLine("-Araç Sil-");
                        OtoGaleri.AracSil();
                        break;
                    case "9":
                    case "G":
                        Console.WriteLine("-Galeri Bilgileri-");
                        OtoGaleri.GaleriBilgileri();
                        break;
                    default:
                        Console.WriteLine("Hatalı giriş yaptınız. Lütfen tekrar deneyiniz");
                        break;
                }
            }
        }
    }
}
