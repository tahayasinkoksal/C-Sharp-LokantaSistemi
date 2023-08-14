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
    public partial class DepoislemleriForm : Form
    {
        public DepoislemleriForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DepoEkleForm depoEkleForm = new DepoEkleForm();
            depoEkleForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DepoSilForm depoSilForm = new DepoSilForm();    
            depoSilForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DepoGuncelleForm depoGuncelleForm = new DepoGuncelleForm();
            depoGuncelleForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DepoRaporForm depoRaporForm = new DepoRaporForm();
            depoRaporForm.ShowDialog();
        }
    }
}
