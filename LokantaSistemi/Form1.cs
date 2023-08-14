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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //depo islemleri tiklaninca olacaklar
        private void button1_Click(object sender, EventArgs e)
        {
            DepoislemleriForm depoislemleriform = new DepoislemleriForm();
            depoislemleriform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //yemek islemleri git
            YemekCesitForm yemekCesitForm = new YemekCesitForm();
            yemekCesitForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SiparisIslemleriForm siparisIslemleriForm = new SiparisIslemleriForm();
            siparisIslemleriForm.ShowDialog();

        }
    }
}
