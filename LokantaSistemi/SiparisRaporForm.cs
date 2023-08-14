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
    public partial class SiparisRaporForm : Form
    {
        public SiparisRaporForm()
        {
            InitializeComponent();
        }

        private void SiparisRaporForm_Load(object sender, EventArgs e)
        {
            YemekSiparisYonetimi yemekSiparisYonetimi = new YemekSiparisYonetimi();
            var veri = yemekSiparisYonetimi.SiparisRapor();

            label1.Text = veri.yemekListesi;
            label2.Text = veri.maliyet;
            label3.Text = veri.kar;
            label4.Text = veri.toplananKDV;
            label5.Text = veri.kacKisiYedi;
            label6.Text = veri.alinanOdeme;


        }
    }
}
