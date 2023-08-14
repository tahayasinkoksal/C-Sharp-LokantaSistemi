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
    public partial class YemekCesitSilForm : Form
    {
        public YemekCesitSilForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sil tıklanınca olacaklar
            YemekCesitYonetimi yemekCesitYonetimi = new YemekCesitYonetimi();
            string yemekAd = textBox1.Text;
            string durum = yemekCesitYonetimi.YemekCesitSil(yemekAd);
            MessageBox.Show(durum, "Durum");

            this.Close();
        }
    }
}
