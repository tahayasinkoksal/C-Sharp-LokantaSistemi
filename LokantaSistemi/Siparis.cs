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
    public class Siparis
    {
        public string siparisID;
        public string siparisYemekAd;
        public string siparisTarih;
        public int siparisKacKisilik;
        public double siparisMaliyet;
        public double siparisKar;
        public double siparisKDValinan;
        public double siparisSONfiyati;

        public Siparis(string siparisYemekAd, string siparisTarih,int siparisKacKisilik,double siparisMaliyet,
        double siparisKar,double siparisKDValinan,double siparisSONfiyati) 
        {
            siparisID = Guid.NewGuid().ToString(); // Rastgele bir ID oluşturur.
            this.siparisYemekAd = siparisYemekAd;
            this.siparisTarih = siparisTarih;
            this.siparisKacKisilik = siparisKacKisilik;
            this.siparisMaliyet = siparisMaliyet;
            this.siparisKar = siparisKar;
            this.siparisKDValinan = siparisKDValinan;
            this.siparisSONfiyati = siparisSONfiyati;
        }

    }
}
