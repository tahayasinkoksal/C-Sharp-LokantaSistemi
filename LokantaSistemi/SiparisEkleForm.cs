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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LokantaSistemi
{
    public partial class SiparisEkleForm : Form
    {
        public SiparisEkleForm()
        {
            InitializeComponent();
        }

        private void SiparisEkleForm_Load(object sender, EventArgs e)
        {
            label3.Text = "-₺";
            label4.Text = "-";
            label6.Text = "-";
            label8.Text = "-";
            label10.Text = "-₺";
            YemekCesitYonetimi yemekCesitYonetimi = new YemekCesitYonetimi();
            var yiyecekCesitListesi = yemekCesitYonetimi.YemekCesitListele();
           
            foreach(Yiyecek yiyecek in yiyecekCesitListesi) 
            {
                comboBox1.Items.Add(yiyecek.yiyecekAdi);
            }
            //bu günün tarihini alıyorum
            DateTime bugun = DateTime.Now;
            string tarihBugun = bugun.ToString("dd-MM-yyyy");
            
        }
        //kdv hesabı ile ürün fiyatını hesapladım
        static double KDVHesaplaFiyat(double urunFiyati, double kdvOrani)
        {
            double kdvOraniYuzde = kdvOrani / 100.0;
            double kdvTutari = urunFiyati * kdvOraniYuzde;
            double toplamFiyat = urunFiyati + kdvTutari;
            return kdvTutari;
        }

        //fiyata %10 kar ekledik
        static double HesaplaKar(double urunFiyati)
        {
            double karOrani = 0.10; // %10 kar oranı
            double kar = urunFiyati * karOrani;
            return kar;
        }

        //son satış fiyatı hesaplama
        static double HesaplaSonSatisFiyati(double urunFiyati, double kdvOrani) 
        {
            var kdv = KDVHesaplaFiyat(urunFiyati, kdvOrani);
            var kar = HesaplaKar(urunFiyati);
            
            var sonFiyat = urunFiyati + kdv + kar;
            return sonFiyat;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seciliSecenek = comboBox1.SelectedItem.ToString();

            YemekCesitYonetimi yemekCesitYonetimi = new YemekCesitYonetimi();
            var yiyecekCesitEleman = yemekCesitYonetimi.YemekCesitListeleTekli(seciliSecenek);

            label3.Text = HesaplaSonSatisFiyati(yiyecekCesitEleman.yiyecekFiyat, yiyecekCesitEleman.yiyecekKDV).ToString() + " ₺";
            label4.Text = yiyecekCesitEleman.yiyecekKackisi.ToString();
            label6.Text = yiyecekCesitEleman.yiyecekCins;
            label8.Text = yiyecekCesitEleman.yiyecekKDV.ToString();

            if (yiyecekCesitEleman.yiyecekKackisi > 1) 
            {
                label10.Text = (HesaplaSonSatisFiyati(yiyecekCesitEleman.yiyecekFiyat,yiyecekCesitEleman.yiyecekKDV) / yiyecekCesitEleman.yiyecekKackisi).ToString("N2") + " ₺";
            }else 
            {
                label10.Text = HesaplaSonSatisFiyati(yiyecekCesitEleman.yiyecekFiyat, yiyecekCesitEleman.yiyecekKDV).ToString() + " ₺";
            }
           
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //siprais ver butonu

            //bu günün tarihini alıyorum
            DateTime bugun = DateTime.Now;
            string tarihBugun = bugun.ToString("dd-MM-yyyy");

            string seciliSecenek = comboBox1.SelectedItem.ToString();
            YemekCesitYonetimi yemekCesitYonetimi = new YemekCesitYonetimi();
            var yiyecekCesitEleman = yemekCesitYonetimi.YemekCesitListeleTekli(seciliSecenek);

            //degiskenler
            string siparisYemekAd = yiyecekCesitEleman.yiyecekAdi;
            string siparisTarih = bugun.ToString("dd-MM-yyyy");
            int siparisKacKisilik = yiyecekCesitEleman.yiyecekKackisi;
            double siparisMaliyet = yiyecekCesitEleman.yiyecekFiyat; //db deki fiyat maliyet demek
            double siparisKAR = HesaplaKar(yiyecekCesitEleman.yiyecekFiyat);
            double siparisKDVAlinan = KDVHesaplaFiyat(yiyecekCesitEleman.yiyecekFiyat, yiyecekCesitEleman.yiyecekKDV);
            double siparisSonFiyat = HesaplaSonSatisFiyati(yiyecekCesitEleman.yiyecekFiyat, yiyecekCesitEleman.yiyecekKDV);

            YemekSiparisYonetimi yemekSiparisYonetimi = new YemekSiparisYonetimi();
            Siparis siparis = new Siparis(siparisYemekAd, siparisTarih, siparisKacKisilik, siparisMaliyet, siparisKAR, siparisKDVAlinan, siparisSonFiyat);

            var durum = yemekSiparisYonetimi.SiparisEkle(siparis);

            MessageBox.Show(durum, "Bilgi");
        }
    }
}
