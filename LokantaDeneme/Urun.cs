using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LokantaDeneme
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

