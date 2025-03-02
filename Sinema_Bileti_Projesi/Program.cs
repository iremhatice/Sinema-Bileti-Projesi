namespace Sinema_Bileti_Projesi
{
    internal class Program
    {
        static string[] koltuklar = { "", "", "", "", "", "", "", "" };
        static int sayac = 0, koltuksecim;
        static string isim;
        static void Main(string[] args)
        {
            while (sayac != koltuklar.Length)
            {
                IsimAl();
                KoltukKontrol();
                Rezervasyon();
            }
            Cikis();
            Console.ReadLine();
        }

        private static void Cikis()
        {
            Console.WriteLine("Secilecek koltuk kalmamıstır.Programdan cıkmak istiyorsanız exit yazınız.");
            string cevap = Console.ReadLine().ToLower();
            if (cevap == "exit") Environment.Exit(0);
        }

        private static void IsimAl()
        {
            Console.WriteLine("Lütfen isminizi girin: ");
            isim = Console.ReadLine();
            for (int i = 0; i < isim.Length; i++)
            {
                if (char.IsDigit(isim[i]))
                {
                    Console.WriteLine("Isim sayısal karakter icermemelidir.");
                    IsimAl();
                }
            }
        }

        private static void KoltukKontrol()
        {
            for (int i = 0; i < koltuklar.Length; i++)
            {
                Console.WriteLine(koltuklar[i] == "" ? $"{i + 1}.koltuk boş" : $"{i + 1}. koltuk {koltuklar[i]} tarafından dolu");
            }
            Console.WriteLine(sayac == koltuklar.Length ? "Salon Dolu" : "Salon Boş");
        }

        private static void Rezervasyon()
        {
            try
            {
                Console.WriteLine("Istediginiz koltugu seçiniz: ");
                koltuksecim = Convert.ToInt32(Console.ReadLine()) - 1;
                if (koltuklar[koltuksecim] == "")
                {
                    koltuklar[koltuksecim] = isim;
                    sayac++;

                }
                else
                {
                    Console.WriteLine("Seçtiginiz koltuk dolu");
                    Rezervasyon();
                }
                Console.WriteLine($"{koltuksecim + 1}. koltuk {koltuklar[koltuksecim]} tarafından rezerve edilmiştir.");
                KoltukKontrol();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Olmayan koltuk secimi");
                Rezervasyon();
            }
            catch (Exception)
            {
                Console.WriteLine("Koltuk sayısı metinsel ifade icermez.");
                Rezervasyon();
            }



        }

    }
}
