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
    public partial class DepoRaporForm : Form
    {
        public DepoRaporForm()
        {
            InitializeComponent();
        }

        private void DepoRaporForm_Load(object sender, EventArgs e)
        {
            string depoDosyaYolu = "Depo.txt";
            DepoYonetim depoYonetim = new DepoYonetim(depoDosyaYolu);

            var liste = depoYonetim.UrunListele();

            foreach (Urun urun in liste)
            {
                listBox1.Items.Add($"Ürün Adı: {urun.UrunAdi} - Üretim Tarihi {urun.UretimTarihi} - Son Kullanma Tarihi {urun.SonKullanmaTarihi} - " +
                    $" Kalori (gram): {urun.KaloriGram} - Stok Adeti: {urun.StokAdet} - Fiyat: {urun.Fiyat}");
            }


        }
    }
}
