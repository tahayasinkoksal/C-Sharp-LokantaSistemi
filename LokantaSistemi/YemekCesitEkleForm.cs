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
    public partial class YemekCesitEkleForm : Form
    {
        public YemekCesitEkleForm()
        {
            InitializeComponent();
        }

        public void ayarYapMalzeme()
        {
            DepoYonetim depoYonetim = new DepoYonetim("Depo.txt");
            var stringList = depoYonetim.UrunAdListele();

            //var stringList = new List<string> { "Makarna", "Salça", "Tuz" };

            foreach (string item in stringList)
            {
                CheckBox checkBox = new CheckBox();
                TextBox textBox = new TextBox();

                checkBox.Text = item;
                textBox.Name = "txt_" + item; // Farklı öğeleri ayırt etmek için isimlendirme

                flowLayoutPanel1.Controls.Add(checkBox);
                flowLayoutPanel1.Controls.Add(textBox);
            }
        }

        private void YemekCesitEkleForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Salata");
            comboBox1.Items.Add("Tatlı");
            comboBox1.Items.Add("İçecek");
            comboBox1.Items.Add("Yemek");
            comboBox1.Items.Add("Meyve");

            ayarYapMalzeme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YemekCesitYonetimi yemekCesitYonetimi = new YemekCesitYonetimi();
            List<Malzemeler> malzemelers = new List<Malzemeler>();

            string yemekAd = textBox1.Text;
            string yemekTur = comboBox1.SelectedItem.ToString();
            double yemekFiyat = Convert.ToDouble(textBox4.Text);
            int yemekKacKisi = Convert.ToInt32( textBox3.Text);
            double yemekKDV = Convert.ToDouble(textBox2.Text);

            //richText ten gelenleri parcalayip malzeme listesine çevirip parametre olarak gondercez.
            //Malzemeler mal = new Malzemeler("yemek adi", "Malzeme Adi", 2);

            string[] malzemelerArray = secilenMalzemeListesi().Split(',');
            foreach (string malzeme in malzemelerArray)
            {
                string[] malzemeBilgisi = malzeme.Split('-');

                if (malzemeBilgisi.Length == 2)
                {
                    string ad = malzemeBilgisi[0];
                    int miktar;

                    if (int.TryParse(malzemeBilgisi[1], out miktar))
                    {
                        Malzemeler yeniMalzeme = new Malzemeler(yemekAd,ad, miktar);
                        malzemelers.Add(yeniMalzeme);
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz miktar: " + malzemeBilgisi[1]);
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz malzeme bilgisi: " + malzeme);
                }
            }


            Yiyecek yiyecek = new Yiyecek(yemekAd,yemekTur,yemekFiyat, yemekKacKisi,yemekKDV, malzemelers);
            string durum = yemekCesitYonetimi.YemekCesitEkle(yiyecek);
            MessageBox.Show(durum, "Durum");

            this.Close();

        }

         public string secilenMalzemeListesi() 
        {
            // Seçili CheckBox'ların metinlerini ve ilişkili TextBox değerlerini birleştirerek
            // istenen çıktı formatında oluşturur ve bu çıktıyı bir Label kontrolüne yazar.

            List<string> secilenVeriler = new List<string>();

            foreach (Control kontrol in flowLayoutPanel1.Controls)
            {
                if (kontrol is CheckBox checkBox && checkBox.Checked)
                {
                    string elemanAdi = checkBox.Text;
                    TextBox iliskiliTextBox = flowLayoutPanel1.Controls["txt_" + elemanAdi] as TextBox;
                    string textBoxDegeri = iliskiliTextBox.Text;

                    string birlesikDeger = elemanAdi + "-" + textBoxDegeri;
                    secilenVeriler.Add(birlesikDeger);
                }
            }

            string sonucMetni = string.Join(", ", secilenVeriler);
            return sonucMetni;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece sayılar, tire (-) ve kontrol tuşlarına izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}
