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
    public partial class DepoGuncelleForm : Form
    {
        public DepoGuncelleForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //guncelle butonuna tiklaninca olacaklar

            dateTimePicker1.CustomFormat = "dd-MM-yyyy"; // Tarih formatını ayarla
            string sonTraih1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            dateTimePicker2.CustomFormat = "dd-MM-yyyy"; // Tarih formatını ayarla
            string sonTraih2 = dateTimePicker1.Value.ToString("dd-MM-yyyy");

            string depoDosyaYolu = "Depo.txt";
            DepoYonetim depoYonetim = new DepoYonetim(depoDosyaYolu);


            string guncellenecekUrunAdi = textBox7.Text;


            string yeniUrunAdi = textBox1.Text;

            string yeniUretimTarihi = sonTraih1;

            string yeniSonKullanmaTarihi = sonTraih2;
            
            float yeniKaloriGram = float.Parse(textBox4.Text);
            
            float yeniStokAdet = float.Parse(textBox5.Text);
           
            float yeniFiyat = float.Parse(textBox6.Text);

            Urun yeniUrunBilgisi = new Urun(yeniUrunAdi, yeniUretimTarihi, yeniSonKullanmaTarihi, yeniKaloriGram, yeniStokAdet, yeniFiyat);
            string durum = depoYonetim.UrunGuncelle(guncellenecekUrunAdi, yeniUrunBilgisi);

            MessageBox.Show(durum, "Durum");

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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakamlar ve kontrol tuşlarına izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakamlar ve kontrol tuşlarına izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void DepoGuncelleForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MM-yyyy"; // Tarih formatını ayarla
            string sonTraih = dateTimePicker1.Value.ToString("dd-MM-yyyy");
        }
    }
}
