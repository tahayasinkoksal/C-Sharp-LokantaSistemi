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
    public partial class DepoEkleForm : Form
    {
        public DepoEkleForm()
        {
            InitializeComponent();
        }


        //depoya urun eklemek icin tiklandiginda
        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yyyy"; // Tarih formatını ayarla
            string sonTraih1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            dateTimePicker2.CustomFormat = "dd-MM-yyyy"; // Tarih formatını ayarla
            string sonTraih2 = dateTimePicker1.Value.ToString("dd-MM-yyyy");

            string depoDosyaYolu = "Depo.txt";
            DepoYonetim depoYonetim = new DepoYonetim(depoDosyaYolu);

            string urunAdi = textBox1.Text;

            string uretimTarihi = sonTraih1;

            string sonKullanmaTarihi = sonTraih2;
           
            float kaloriGram = float.Parse(textBox4.Text);
            
            float stokAdet = float.Parse(textBox5.Text);
            
            float fiyat = float.Parse(textBox6.Text);

            Urun yeniUrun = new Urun(urunAdi, uretimTarihi, sonKullanmaTarihi, kaloriGram, stokAdet, fiyat);
            depoYonetim.UrunEkle(yeniUrun);

            MessageBox.Show("Başarıyla Kaydedildi", "Durum");

            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakamlar ve kontrol tuşlarına izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPressDate(object sender, KeyPressEventArgs e)
        {
            // Sadece sayılar, tire (-) ve kontrol tuşlarına izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece sayılar, tire (-) ve kontrol tuşlarına izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void DepoEkleForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yyyy"; // Tarih formatını ayarla
            string sonTraih = dateTimePicker1.Value.ToString("dd-MM-yyyy");

        }
    }
}
