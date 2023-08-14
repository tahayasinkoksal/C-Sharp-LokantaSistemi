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
    public class Meyve : Yiyecek
    {
        public Meyve(string yiyecekAdi, string yiyecekCins, double yiyecekFiyat, int yiyecekKackisi, double yiyecekKDV, List<Malzemeler> yiyecekMalzemeler) : base(yiyecekAdi, yiyecekCins, yiyecekFiyat, yiyecekKackisi, yiyecekKDV, yiyecekMalzemeler)
        {
        }
    }
}
