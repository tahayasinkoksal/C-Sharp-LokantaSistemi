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
using System.Windows.Forms;

namespace LokantaSistemi
{
    public class YemekSiparisYonetimi
    {
        private string depoDosyaYolu;

        public YemekSiparisYonetimi() 
        {
            this.depoDosyaYolu = "Siparis.txt";
        }

        public string SiparisEkle(Siparis siparis)
        {

            try
            {
                using (StreamWriter writer = File.AppendText(depoDosyaYolu))
                {
                    string siparisBilgisi = $"{siparis.siparisID}*{siparis.siparisYemekAd}*{siparis.siparisTarih}*{siparis.siparisKacKisilik}*{siparis.siparisMaliyet}*" +
                        $"{siparis.siparisKar}*{siparis.siparisKDValinan}*{siparis.siparisSONfiyati}";
                    writer.WriteLine(siparisBilgisi);
                }
               
                return "Siparis başarıyla eklendi.\nSipariş No: "+siparis.siparisID;
                //Console.WriteLine("Ürün başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return "Siparis eklenirken bir hata oluştu" + ex.Message;
                //Console.WriteLine("Ürün eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        //coklu listeler
        public List<Siparis> SiparisListele()
        {
            List<Siparis> siparisListesi = new List<Siparis>();
            try
            {


                string[] urunler = File.ReadAllLines(depoDosyaYolu);

                if (urunler.Length == 0)
                {
                    Console.WriteLine("Hiç siparis bulunmamaktadır.");
                    return siparisListesi;
                }
                else
                {

                    foreach (string urunBilgisi in urunler)
                    {
                        string[] urunDetaylari = urunBilgisi.Split('*');

                        Siparis siparis = new Siparis(urunDetaylari[1], urunDetaylari[0], Convert.ToInt32(urunDetaylari[3]), Convert.ToDouble(urunDetaylari[4]),
                             Convert.ToDouble(urunDetaylari[5]), Convert.ToDouble(urunDetaylari[6]), Convert.ToDouble(urunDetaylari[7]));

                        siparisListesi.Add(siparis);
                    }
                    return siparisListesi;
                }
            }
            catch (Exception ex)
            {
                return siparisListesi;
                //Console.WriteLine("Ürünler listelenirken bir hata oluştu: " + ex.Message);
            }
        }


        public string SiparisSil(string siparisID)
        {
           
            try
            {
                List<string> lines = new List<string>(File.ReadAllLines(depoDosyaYolu));
                bool urunSilindi = false;

                using (StreamWriter writer = new StreamWriter(depoDosyaYolu))
                {
                    foreach (string line in lines)
                    {
                        string[] urunBilgisi = line.Split('*');
                        
                        if (urunBilgisi[0] == siparisID)
                        {
                            urunSilindi = true;
                            continue; // Ürünü yazmaz, yani siler.
                        }
                        writer.WriteLine(line);
                    }
                }

                if (urunSilindi)
                {
                    return "Sipariş başarıyla silindi.";
                    //Console.WriteLine("Ürün başarıyla silindi.");
                }


                else
                    return "Sipariş bulunamadı.";
                //Console.WriteLine("Ürün bulunamadı.");
            }
            catch (Exception ex)
            {
                return "Sipariş silinirken bir hata oluştu";
                Console.WriteLine("Ürün silinirken bir hata oluştu: " + ex.Message);
            }
        }


        //siparisRapor almak için
        public SiparisRapor SiparisRapor()
        {
            //bu günün tarihini alıyorum
            DateTime bugun = DateTime.Now;
            string buGunTarih = bugun.ToString("dd-MM-yyyy");

            //degiskenler
            string topyemekListesi = "";
            double topmaliyet = 0;
            double topKar = 0;
            double topKDV = 0;
            double topKacKisi = 0;
            double topAlinanOdeme = 0;




            try
            {


                string[] urunler = File.ReadAllLines(depoDosyaYolu);

                if (urunler.Length == 0)
                {
                    Console.WriteLine("Hiç siparis bulunmamaktadır.");
                    return new SiparisRapor("Yok","Yok","Yok","Yok","Yok","Yok");
                }
                else
                {
                    //string siparisBilgisi = $"{siparis.siparisID}*{siparis.siparisYemekAd}*{siparis.siparisTarih}*{siparis.siparisKacKisilik}*{siparis.siparisMaliyet}*" +
                    //$"{siparis.siparisKar}*{siparis.siparisKDValinan}*{siparis.siparisSONfiyati}";
                    foreach (string urunBilgisi in urunler)
                    {
                        string[] urunDetaylari = urunBilgisi.Split('*');
                        //sadece bu gun verilen siparisler
                        if (urunDetaylari[2] == buGunTarih) 
                        {
                            topyemekListesi += " " +urunDetaylari[1];
                            topmaliyet += Convert.ToDouble(urunDetaylari[4]);
                            topKar += Convert.ToDouble(urunDetaylari[5]);
                            topKDV += Convert.ToDouble(urunDetaylari[6]);
                            topKacKisi += Convert.ToDouble(urunDetaylari[3]);
                            topAlinanOdeme += Convert.ToDouble(urunDetaylari[7]);
                        }
                        

                        
                    }
                    SiparisRapor siparisRapor = new SiparisRapor(Convert.ToString(topyemekListesi), Convert.ToString(topmaliyet), Convert.ToString(topKar),
                        Convert.ToString(topKDV), Convert.ToString(topKacKisi), Convert.ToString(topAlinanOdeme));
                    return siparisRapor;
                }
            }
            catch (Exception ex)
            {
                return new SiparisRapor("Hata", "Hata", "Hata", "Hata", "Hata", "Hata");
                //Console.WriteLine("Ürünler listelenirken bir hata oluştu: " + ex.Message);
            }
        }


    }
}
