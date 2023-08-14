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
    public class Urun
    {
        public string UrunID { get; private set; }
        public string UrunAdi { get; set; }
        public string UretimTarihi { get; set; }
        public string SonKullanmaTarihi { get; set; }
        public float KaloriGram { get; set; }
        public float StokAdet { get; set; }
        public float Fiyat { get; set; }

        public Urun(string urunAdi, string uretimTarihi, string sonKullanmaTarihi, float kaloriGram, float stokAdet, float fiyat)
        {
            UrunID = Guid.NewGuid().ToString(); // Rastgele bir ID oluşturur.
            UrunAdi = urunAdi;
            UretimTarihi = uretimTarihi;
            SonKullanmaTarihi = sonKullanmaTarihi;
            KaloriGram = kaloriGram;
            StokAdet = stokAdet;
            Fiyat = fiyat;
        }
    }
}
