using System;

namespace LokantaDeneme
{
    class Program
    {
        static void Main(string[] args)
        {
            string depoDosyaYolu = "Depo.txt";
            DepoYonetim depoYonetim = new DepoYonetim(depoDosyaYolu);

            while (true)
            {
                Console.WriteLine("1 - Ürün Ekle");
                Console.WriteLine("2 - Ürün Sil");
                Console.WriteLine("3 - Ürün Güncelle");
                Console.WriteLine("4 - Ürünleri Listele");
                Console.WriteLine("5 - Çıkış");
                Console.Write("Seçiminizi yapın (1-5): ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.Write("Ürün Adı: ");
                        string urunAdi = Console.ReadLine();
                        Console.Write("Üretim Tarihi: ");
                        string uretimTarihi = Console.ReadLine();
                        Console.Write("Son Kullanma Tarihi: ");
                        string sonKullanmaTarihi = Console.ReadLine();
                        Console.Write("Kalori (gram): ");
                        float kaloriGram = float.Parse(Console.ReadLine());
                        Console.Write("Stok Adeti: ");
                        float stokAdet = float.Parse(Console.ReadLine());
                        Console.Write("Fiyat: ");
                        float fiyat = float.Parse(Console.ReadLine());

                        Urun yeniUrun = new Urun(urunAdi, uretimTarihi, sonKullanmaTarihi, kaloriGram, stokAdet, fiyat);
                        depoYonetim.UrunEkle(yeniUrun);
                        break;

                    case "2":
                        Console.Write("Silmek istediğiniz ürünün adını girin: ");
                        string silinecekUrunAdi = Console.ReadLine();
                        depoYonetim.UrunSil(silinecekUrunAdi);
                        break;

                    case "3":
                        Console.Write("Güncellemek istediğiniz ürünün adını girin: ");
                        string guncellenecekUrunAdi = Console.ReadLine();

                        Console.Write("Yeni Ürün Adı: ");
                        string yeniUrunAdi = Console.ReadLine();
                        Console.Write("Yeni Üretim Tarihi: ");
                        string yeniUretimTarihi = Console.ReadLine();
                        Console.Write("Yeni Son Kullanma Tarihi: ");
                        string yeniSonKullanmaTarihi = Console.ReadLine();
                        Console.Write("Yeni Kalori (gram): ");
                        float yeniKaloriGram = float.Parse(Console.ReadLine());
                        Console.Write("Yeni Stok Adeti: ");
                        float yeniStokAdet = float.Parse(Console.ReadLine());
                        Console.Write("Yeni Fiyat: ");
                        float yeniFiyat = float.Parse(Console.ReadLine());

                        Urun yeniUrunBilgisi = new Urun(yeniUrunAdi, yeniUretimTarihi, yeniSonKullanmaTarihi, yeniKaloriGram, yeniStokAdet, yeniFiyat);
                        depoYonetim.UrunGuncelle(guncellenecekUrunAdi, yeniUrunBilgisi);
                        break;

                    case "4":
                        depoYonetim.UrunListele();
                        break;

                    case "5":
                        Console.WriteLine("Programdan çıkılıyor...");
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
