﻿using System;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.GetModels.Ogrenci
{
    public class OgrenciTabloModel : ViewModel
    {
        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Numara { get; set; }

        public DateTime KayitTarihi { get; set; }

        public int BolumId { get; set; }

        public string BolumAdi { get; set; }

        public string MemleketAdres { get; set; }

        public string Adres { get; set; }

        public string Telefon { get; set; }

        public string Mail { get; set; }
        
    }
}