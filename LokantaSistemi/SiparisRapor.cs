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
    public class SiparisRapor
    {
        public string yemekListesi, maliyet, kar, toplananKDV, kacKisiYedi, alinanOdeme;

        public SiparisRapor(string yemekListesi, string maliyet, string kar, string toplananKDV, string kacKisiYedi, string alinanOdeme) 
        {
            this.yemekListesi = yemekListesi;
            this.maliyet = maliyet;
            this.kar = kar;
            this.toplananKDV = toplananKDV;
            this.kacKisiYedi = kacKisiYedi;
            this.alinanOdeme = alinanOdeme;
        }
    }
}
