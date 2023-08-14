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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LokantaSistemi
{
    public partial class YemekCesitRaporForm : Form
    {
        public YemekCesitRaporForm()
        {
            InitializeComponent();
        }

        private void YemekCesitRaporForm_Load(object sender, EventArgs e)
        {
            string depoDosyaYolu = "YemekCesit.txt";
            YemekCesitYonetimi yemekCesitYonetim = new YemekCesitYonetimi();

            var liste = yemekCesitYonetim.YemekCesitListele();
            
            foreach (Yiyecek yiyecek in liste)
            {
                listBox1.Items.Add($"Yiyecek Adı: {yiyecek.yiyecekAdi} - Yiyecek Turü: {yiyecek.yiyecekCins} - Yiyecek Fiyat: {yiyecek.yiyecekFiyat} - " +
                    $"Yiyecek Kaç Kişilik: {yiyecek.yiyecekKackisi} - Yiyecek KDV: {yiyecek.yiyecekKDV}");
            }
        }

        //çift tıklandığında olcaklar
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            // Seçilen öğenin metnini alalım
            string selectedText = listBox1.SelectedItem.ToString();

            string[] parcalar = selectedText.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            string yiyecekAdi = "";
            foreach (string parca in parcalar)
            {
                if (parca.Contains("Yiyecek Adı:"))
                {
                    yiyecekAdi = parca.Replace("Yiyecek Adı: ", "");
                    break;
                }
            }

            YemekCesitYonetimi yemekCesitYonetimi = new YemekCesitYonetimi();
            string gelenMalzemeListesi = yemekCesitYonetimi.YemekCesitMalzemeListeleTekli(yiyecekAdi);

            MessageBox.Show(gelenMalzemeListesi, "Malzeme Listesi");
         
        }
    }
}
