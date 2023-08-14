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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokantaSistemi
{
    public class Yiyecek
    {
        //adi, cins, fiyat, kdvoranı vs.
        public string yiyecekAdi;
        public string yiyecekCins;
        public double yiyecekFiyat;
        public int yiyecekKackisi;
        public double yiyecekKDV;
        public List<Malzemeler> yiyecekMalzemeler;

        public Yiyecek(string yiyecekAdi, string yiyecekCins, double yiyecekFiyat, int yiyecekKackisi,  double yiyecekKDV, List<Malzemeler> yiyecekMalzemeler)
        {
            this.yiyecekAdi = yiyecekAdi;
            this.yiyecekCins = yiyecekCins;
            this.yiyecekFiyat = yiyecekFiyat;
            this.yiyecekKackisi = yiyecekKackisi;
            this.yiyecekKDV = yiyecekKDV;
            this.yiyecekMalzemeler = yiyecekMalzemeler;
        }

    }
}
