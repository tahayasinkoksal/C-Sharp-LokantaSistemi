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
    public partial class SiparisSilForm : Form
    {
        public SiparisSilForm()
        {
            InitializeComponent();
        }
        

        private void SiparisSilForm_Load(object sender, EventArgs e)
        {
            YemekSiparisYonetimi yemekSiparisYonetimi = new YemekSiparisYonetimi();
            var siparisListesi = yemekSiparisYonetimi.SiparisListele();
            foreach (var siparis in siparisListesi)
            {
                comboBox1.Items.Add(siparis.siparisTarih + "->" +siparis.siparisYemekAd);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null) 
            {
                var silinecekSiparisNO = comboBox1.SelectedItem.ToString();
                string[] parcalar = silinecekSiparisNO.Split(new string[] { "->" }, StringSplitOptions.None);
                silinecekSiparisNO = parcalar[0];

                YemekSiparisYonetimi yemekSiparisYonetimi = new YemekSiparisYonetimi();
                var durum = yemekSiparisYonetimi.SiparisSil(silinecekSiparisNO);

                MessageBox.Show(durum, "Bilgi");
                this.Close();
            }else 
            {
                MessageBox.Show("Görünüşe Göre Sipariş Yok Gibi! \nHadi başka kapıya", "Bilgi");
                this.Close();
            }
            

        }
    }
}
