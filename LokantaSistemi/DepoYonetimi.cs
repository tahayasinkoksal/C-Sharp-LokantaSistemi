/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2022-2023 YAZ DÖNEMİ
**
** ÖDEV NUMARASI..........:1.Proje / Tasarım
** ÖĞRENCİ ADI............: Taha Yasin KÖKSAL
** ÖĞRENCİ NUMARASI.......: S221210271
** DERSİN ALINDIĞI GRUP...: A
****************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokantaSistemi
{
    //Yemeklerde kullanılacak urunler olacka burada

    //Ekleme, silme, guncelleme işlemleri burada yapılacak

    //Urunler urun classından yonetilecek, o class kullanılarak, ornek alarak islem yapılcak.

    public class DepoYonetim
    {
        private string depoDosyaYolu;

        public DepoYonetim(string depoDosyaYolu)
        {
            this.depoDosyaYolu = depoDosyaYolu;
        }


        public List<Urun> UrunListele()
        {
            List<Urun> urunListesi = new List<Urun>();
            try
            {
                
                
                string[] urunler = File.ReadAllLines(depoDosyaYolu);

                if (urunler.Length == 0)
                {
                    Console.WriteLine("Depoda hiç ürün bulunmamaktadır.");
                    return urunListesi;
                }
                else
                {
                    Console.WriteLine("Depodaki Ürünler:");
                    Console.WriteLine("-------------------");
                    foreach (string urunBilgisi in urunler)
                    {
                        string[] urunDetaylari = urunBilgisi.Split(',');
                        Console.WriteLine($"Ürün ID: {urunDetaylari[0]}");
                        Console.WriteLine($"Ürün Adı: {urunDetaylari[1]}");
                        Console.WriteLine($"Üretim Tarihi: {urunDetaylari[2]}");
                        Console.WriteLine($"Son Kullanma Tarihi: {urunDetaylari[3]}");
                        Console.WriteLine($"Kalori (gram): {urunDetaylari[4]}");
                        Console.WriteLine($"Stok Adeti: {urunDetaylari[5]}");
                        Console.WriteLine($"Fiyat: {urunDetaylari[6]}");
                        Console.WriteLine("-------------------");
                        Urun urun = new Urun(urunDetaylari[1], urunDetaylari[2], urunDetaylari[3], 
                            float.Parse( urunDetaylari[4]), float.Parse( urunDetaylari[5]), float.Parse( urunDetaylari[6]));
                        urunListesi.Add(urun);
                    }
                    return urunListesi;
                }
            }
            catch (Exception ex)
            {
                return urunListesi;
                //Console.WriteLine("Ürünler listelenirken bir hata oluştu: " + ex.Message);
            }
        }


        public void UrunEkle(Urun urun)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(depoDosyaYolu))
                {
                    string urunBilgisi = $"{urun.UrunID},{urun.UrunAdi},{urun.UretimTarihi},{urun.SonKullanmaTarihi},{urun.KaloriGram},{urun.StokAdet},{urun.Fiyat}";
                    writer.WriteLine(urunBilgisi);
                }
                Console.WriteLine("Ürün başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ürün eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        public string UrunSil(string urunAdi)
        {
            try
            {
                List<string> lines = new List<string>(File.ReadAllLines(depoDosyaYolu));
                bool urunSilindi = false;

                using (StreamWriter writer = new StreamWriter(depoDosyaYolu))
                {
                    foreach (string line in lines)
                    {
                        string[] urunBilgisi = line.Split(',');
                        if (urunBilgisi[1] == urunAdi)
                        {
                            urunSilindi = true;
                            continue; // Ürünü yazmaz, yani siler.
                        }
                        writer.WriteLine(line);
                    }
                }

                if (urunSilindi)
                    return "Ürün başarıyla silindi.";
                    //Console.WriteLine("Ürün başarıyla silindi.");

                else
                    return "Ürün bulunamadı.";
                    //Console.WriteLine("Ürün bulunamadı.");
            }
            catch (Exception ex)
            {
                return "Ürün silinirken bir hata oluştu";
                Console.WriteLine("Ürün silinirken bir hata oluştu: " + ex.Message);
            }
        }

        public string UrunGuncelle(string urunAdi, Urun yeniUrunBilgisi)
        {
            try
            {
                List<string> lines = new List<string>(File.ReadAllLines(depoDosyaYolu));
                bool urunGuncellendi = false;

                for (int i = 0; i < lines.Count; i++)
                {
                    string[] urunBilgisi = lines[i].Split(',');
                    if (urunBilgisi[1] == urunAdi)
                    {
                        urunGuncellendi = true;
                        string urunBilgisiStr = $"{yeniUrunBilgisi.UrunID},{yeniUrunBilgisi.UrunAdi},{yeniUrunBilgisi.UretimTarihi},{yeniUrunBilgisi.SonKullanmaTarihi},{yeniUrunBilgisi.KaloriGram},{yeniUrunBilgisi.StokAdet},{yeniUrunBilgisi.Fiyat}";
                        lines[i] = urunBilgisiStr;
                    }
                }

                if (urunGuncellendi)
                {
                    File.WriteAllLines(depoDosyaYolu, lines);
                    //Console.WriteLine("Ürün başarıyla güncellendi.");
                    return "Ürün başarıyla güncellendi";
                }
                else
                {
                    //Console.WriteLine("Ürün bulunamadı.");
                    return "Ürün bulunamadı.";
                }
            }
            catch (Exception ex)
            {
                return "Ürün güncellenirken bir hata oluştu";
                //Console.WriteLine("Ürün güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

        //sadece depodaki urun adlari
        public List<string> UrunAdListele()

        {
            List<string> urunListesi = new List<string>();
            try
            {


                string[] urunler = File.ReadAllLines(depoDosyaYolu);

                if (urunler.Length == 0)
                {
                    Console.WriteLine("Depoda hiç ürün bulunmamaktadır.");
                    return urunListesi;
                }
                else
                {
                    Console.WriteLine("Depodaki Ürünler:");
                    Console.WriteLine("-------------------");
                    foreach (string urunBilgisi in urunler)
                    {
                        string[] urunDetaylari = urunBilgisi.Split(',');

                        //Console.WriteLine($"Ürün Adı: {urunDetaylari[1]}");
                        urunListesi.Add(urunDetaylari[1]);
                        
                    }
                    return urunListesi;
                }
            }
            catch (Exception ex)
            {
                return urunListesi;
                //Console.WriteLine("Ürünler listelenirken bir hata oluştu: " + ex.Message);
            }
        }

    }
}
