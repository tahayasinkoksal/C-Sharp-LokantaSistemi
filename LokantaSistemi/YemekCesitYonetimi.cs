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
using static System.Windows.Forms.LinkLabel;

namespace LokantaSistemi
{
    public class YemekCesitYonetimi
    {

        private string depoDosyaYolu;

        public YemekCesitYonetimi() {
            this.depoDosyaYolu = "YemekCesit.txt";
        }
        
        public string YemekCesitEkle(Yiyecek yiyecek)
        {
            //yemekCesit.txt kaydet
            //aynı zamanda malzeme dizisindeki elemenları malzeme.txt ye kaydet

            try
            {
                using (StreamWriter writer = File.AppendText(depoDosyaYolu))
                {
                    string urunBilgisi = $"{yiyecek.yiyecekAdi},{yiyecek.yiyecekCins},{yiyecek.yiyecekFiyat},{yiyecek.yiyecekKDV}";
                    writer.WriteLine(urunBilgisi);
                }
                YemekMalzemeEkle(yiyecek.yiyecekMalzemeler, "Malzeme.txt",yiyecek.yiyecekAdi);
                return "Ürün başarıyla eklendi.";
                //Console.WriteLine("Ürün başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return "Ürün eklenirken bir hata oluştu";
                //Console.WriteLine("Ürün eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        public void YemekMalzemeEkle(List<Malzemeler> malzemeler,string depoDosyaYoluMalzeme,string yemekAdi)
        {
           
            try
            {
                string sonYazilcak = "";
                sonYazilcak += yemekAdi + ",";
                for (int i = 0; i < malzemeler.Count; i++) 
                {
                    //sondasın demek
                    if (i == malzemeler.Count -1) 
                    {
                        string urunBilgisi = $"{malzemeler[i].malzemeAdi}-{malzemeler[i].malzemeAdet}";
                        sonYazilcak += urunBilgisi;
                    }
                    else 
                    {
                        string urunBilgisi = $"{malzemeler[i].malzemeAdi}-{malzemeler[i].malzemeAdet},";
                        sonYazilcak += urunBilgisi;
                    }

                    

                   
                }

               

                using (StreamWriter writer = File.AppendText(depoDosyaYoluMalzeme))
                {
                    //string urunBilgisi = $"{malzeme.yemekAdi},{malzeme.malzemeAdi},{malzeme.malzemeAdet}";
                    writer.WriteLine(sonYazilcak);
                }



                //Console.WriteLine("Ürün başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                
                //Console.WriteLine("Ürün eklenirken bir hata oluştu: " + ex.Message);
            }
        }


        public string YemekCesitSil(string yemekAdi)
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
                        if (urunBilgisi[0] == yemekAdi)
                        {
                            urunSilindi = true;
                            continue; // Ürünü yazmaz, yani siler.
                        }
                        writer.WriteLine(line);
                    }
                }

                if (urunSilindi)
                {
                    YemekMalzemeSil(yemekAdi);
                    return "Ürün başarıyla silindi.";
                    //Console.WriteLine("Ürün başarıyla silindi.");
                }


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

        public void YemekMalzemeSil(string malzemeAdi)
        {
            try
            {
                List<string> lines = new List<string>(File.ReadAllLines("Malzeme.txt"));
                bool urunSilindi = false;

                using (StreamWriter writer = new StreamWriter("Malzeme.txt"))
                {
                    foreach (string line in lines)
                    {
                        string[] urunBilgisi = line.Split(',');
                        if (urunBilgisi[0] == malzemeAdi)
                        {
                            urunSilindi = true;
                            continue; // Ürünü yazmaz, yani siler.
                        }
                        writer.WriteLine(line);
                    }
                }

                if (urunSilindi)
                    Console.WriteLine("Ürün başarıyla silindi.");
                    //return "Ürün başarıyla silindi.";


                else
                    //return "Ürün bulunamadı.";
                    Console.WriteLine("Ürün bulunamadı.");
            }
            catch (Exception ex)
            {
                //return "Ürün silinirken bir hata oluştu";
                Console.WriteLine("Ürün silinirken bir hata oluştu: " + ex.Message);
            }
        }


        public string YemekCesitGuncelle(string urunAdi, Yiyecek yeniUrunBilgisi, List<Malzemeler> malzemeler)
        {
            try
            {
                List<string> lines = new List<string>(File.ReadAllLines(depoDosyaYolu));
                bool urunGuncellendi = false;

                for (int i = 0; i < lines.Count; i++)
                {
                    string[] urunBilgisi = lines[i].Split(',');
                    if (urunBilgisi[0] == urunAdi)
                    {
                        urunGuncellendi = true;
                        string urunBilgisiStr = $"{yeniUrunBilgisi.yiyecekAdi},{yeniUrunBilgisi.yiyecekCins},{yeniUrunBilgisi.yiyecekFiyat},{yeniUrunBilgisi.yiyecekKackisi},{yeniUrunBilgisi.yiyecekKDV}";
                        lines[i] = urunBilgisiStr;
                    }
                }

                if (urunGuncellendi)
                {
                    File.WriteAllLines(depoDosyaYolu, lines);
                    //Console.WriteLine("Ürün başarıyla güncellendi.");
                    YemekMalzemeGuncelle(yeniUrunBilgisi.yiyecekAdi,urunAdi, malzemeler);
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

        public string YemekMalzemeGuncelle(string yeniUrunAdi, string eskiUrunAdi, List<Malzemeler> malzemeler)
        {
            try
            {
                List<string> lines = new List<string>(File.ReadAllLines("Malzeme.txt"));
                bool urunGuncellendi = false;

                for (int i = 0; i < lines.Count; i++)
                {
                    string[] urunBilgisi = lines[i].Split(',');
                    if (urunBilgisi[0] == eskiUrunAdi)
                    {

                        urunGuncellendi = true;

                        string sonYazilcak = "";
                        sonYazilcak += yeniUrunAdi + ",";
                        for (int m = 0; m < malzemeler.Count; m++)
                        {
                            //sondasın demek
                            if (m == malzemeler.Count - 1)
                            {
                                string urunBilgisiSon = $"{malzemeler[m].malzemeAdi}-{malzemeler[m].malzemeAdet}";
                                sonYazilcak += urunBilgisiSon;
                            }
                            else
                            {
                                string urunBilgisiSon = $"{malzemeler[m].malzemeAdi}-{malzemeler[m].malzemeAdet},";
                                sonYazilcak += urunBilgisiSon;
                            }




                        }

                        string urunBilgisiStr = sonYazilcak;



                        lines[i] = urunBilgisiStr;


                    }
                }

                if (urunGuncellendi)
                {
                    File.WriteAllLines("Malzeme.txt", lines);
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

        //coklu listeler
        public List<Yiyecek> YemekCesitListele()
        {
            List<Yiyecek> urunListesi = new List<Yiyecek>();
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
                    
                    foreach (string urunBilgisi in urunler)
                    {
                        string[] urunDetaylari = urunBilgisi.Split(',');
                       
                        Yiyecek yiyecek = new Yiyecek(urunDetaylari[0], urunDetaylari[1],
                            float.Parse(urunDetaylari[2]),Convert.ToInt32(urunDetaylari[3]) ,float.Parse(urunDetaylari[4]), null);

                        urunListesi.Add(yiyecek);
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

        //tekli listeler
        public Yiyecek YemekCesitListeleTekli(string gelenYemekCesitAdi)
        {

            Yiyecek yiyecekGonderilecek;
            try
            {
                yiyecekGonderilecek = null;

                string[] urunler = File.ReadAllLines(depoDosyaYolu);

                if (urunler.Length == 0)
                {
                    //Console.WriteLine("Depoda hiç ürün bulunmamaktadır.");
                    return new Yiyecek("Yiyecek bulunmamaktadır.", "Yok", 0,0, 0, null);
                }
                else
                {

                    foreach (string urunBilgisi in urunler)
                    {
                        string[] urunDetaylari = urunBilgisi.Split(',');

                        if(urunDetaylari[0] == gelenYemekCesitAdi) 
                        {
                            Yiyecek yiyecek = new Yiyecek(urunDetaylari[0], urunDetaylari[1],
                            float.Parse(urunDetaylari[2]),Convert.ToInt32(urunDetaylari[3]), float.Parse(urunDetaylari[4]), null);
                            yiyecekGonderilecek = yiyecek;

                            break;
                        }
                        

                       
                    }
                    
                    return yiyecekGonderilecek;
                }
            }
            catch (Exception ex)
            {
                return new Yiyecek("Bir Hata Oldu", "Yok", 0,0, 0, null);
                //Console.WriteLine("Ürünler listelenirken bir hata oluştu: " + ex.Message);
            }
        }


        //tekli listeler
        public string YemekCesitMalzemeListeleTekli(string gelenYemekCesitAdi)
        {

            
            try
            {
                string malzemeListesiSonGidecek = "";

                string[] urunler = File.ReadAllLines("Malzeme.txt");

                if (urunler.Length == 0)
                {
                    //Console.WriteLine("Depoda hiç ürün bulunmamaktadır.");
                    return "Malzeme Bulunamadı";
                }
                else
                {
                    string tekVeri = "";
                    foreach (string urunBilgisi in urunler)
                    {
                        string[] urunDetaylari = urunBilgisi.Split(',');

                        if (urunDetaylari[0] == gelenYemekCesitAdi)
                        {
                            for(int i = 1; i<urunDetaylari.Length; i++) 
                            {
                                tekVeri+=  i + ")" + urunDetaylari[i] + "\n";
                            }
                           
                            malzemeListesiSonGidecek += tekVeri;
                            break;
                        }



                    }

                    return malzemeListesiSonGidecek;
                }
            }
            catch (Exception ex)
            {
                return "Bir hat oldu";
                //Console.WriteLine("Ürünler listelenirken bir hata oluştu: " + ex.Message);
            }
        }


    }
}
