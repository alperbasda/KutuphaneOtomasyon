namespace KutuphaneOtomasyon.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Akinsoft.Bolumler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false, maxLength: 100),
                        FakulteId = c.Int(nullable: false),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Akinsoft.Fakulteler", t => t.FakulteId, cascadeDelete: true)
                .Index(t => t.Adi)
                .Index(t => t.FakulteId);
            
            CreateTable(
                "Akinsoft.Ogrenciler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 100),
                        Soyad = c.String(nullable: false, maxLength: 100),
                        Numara = c.String(nullable: false, maxLength: 50),
                        KayitTarihi = c.DateTime(),
                        BolumId = c.Int(nullable: false),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Akinsoft.Bolumler", t => t.BolumId, cascadeDelete: true)
                .Index(t => t.Ad)
                .Index(t => t.Soyad)
                .Index(t => t.Numara)
                .Index(t => t.BolumId);
            
            CreateTable(
                "Akinsoft.OgrenciAdresler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adres = c.String(nullable: false, maxLength: 1000),
                        AdresTipi = c.Int(nullable: false),
                        OgrenciId = c.Int(nullable: false),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Akinsoft.Ogrenciler", t => t.OgrenciId, cascadeDelete: true)
                .Index(t => t.OgrenciId);
            
            CreateTable(
                "Akinsoft.KitapHareketler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OgrenciId = c.Int(nullable: false),
                        KitapId = c.Int(nullable: false),
                        AlinmaTarihi = c.DateTime(),
                        TeslimTarihi = c.DateTime(precision: 7, storeType: "datetime2"),
                        EsZamanli = c.Guid(),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Akinsoft.Kitaplar", t => t.KitapId, cascadeDelete: true)
                .ForeignKey("Akinsoft.Ogrenciler", t => t.OgrenciId, cascadeDelete: true)
                .Index(t => t.OgrenciId)
                .Index(t => t.KitapId)
                .Index(t => t.AlinmaTarihi);
            
            CreateTable(
                "Akinsoft.Kitaplar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false, maxLength: 200),
                        Kod = c.String(nullable: false, maxLength: 4000),
                        Yazar = c.String(nullable: false, maxLength: 150),
                        YayinYili = c.Int(nullable: false),
                        ISBN = c.String(nullable: false, maxLength: 13),
                        BostaMi = c.Boolean(nullable: false,defaultValue:true,defaultValueSql:"true"),
                        SayfaSayisi = c.Int(nullable: false),
                        KitapKategoriId = c.Int(nullable: false),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Akinsoft.KitapKategoriler", t => t.KitapKategoriId, cascadeDelete: true)
                .Index(t => t.Adi)
                .Index(t => t.Yazar)
                .Index(t => t.ISBN, unique: true)
                .Index(t => t.KitapKategoriId);
            
            CreateTable(
                "Akinsoft.KitapAnahtarlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Anahtar = c.String(nullable: false, maxLength: 50),
                        KitapId = c.Int(nullable: false),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Akinsoft.Kitaplar", t => t.KitapId, cascadeDelete: true)
                .Index(t => t.Anahtar)
                .Index(t => t.KitapId);
            
            CreateTable(
                "Akinsoft.KitapKategoriler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false, maxLength: 200),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Akinsoft.OgrenciMailler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MailAdresi = c.String(nullable: false, maxLength: 100),
                        OgrenciId = c.Int(nullable: false),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Akinsoft.Ogrenciler", t => t.OgrenciId, cascadeDelete: true)
                .Index(t => t.OgrenciId);
            
            CreateTable(
                "Akinsoft.OgrenciTelefonlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Telefon = c.String(nullable: false, maxLength: 11),
                        OgrenciId = c.Int(nullable: false),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Akinsoft.Ogrenciler", t => t.OgrenciId, cascadeDelete: true)
                .Index(t => t.OgrenciId);
            
            CreateTable(
                "Akinsoft.Fakulteler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false, maxLength: 100),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Adi);
            
            CreateTable(
                "Akinsoft.Kullanicilar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(nullable: false, maxLength: 50),
                        KullaniciSifreId = c.Int(nullable: false),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Akinsoft.KullaniciRoller",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciId = c.Int(nullable: false),
                        RolId = c.Int(nullable: false),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Akinsoft.Kullanicilar", t => t.KullaniciId, cascadeDelete: true)
                .ForeignKey("Akinsoft.Roller", t => t.RolId, cascadeDelete: true)
                .Index(t => t.KullaniciId)
                .Index(t => t.RolId);
            
            CreateTable(
                "Akinsoft.Roller",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RolAdi = c.String(nullable: false, maxLength: 10),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Akinsoft.KullaniciSifre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sifre = c.String(nullable: false, maxLength: 4000),
                        KullaniciId = c.Int(nullable: false),
                        SonGuncelleme = c.DateTime(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Akinsoft.Kullanicilar", t => t.KullaniciId, cascadeDelete: true)
                .Index(t => t.KullaniciId);
            
            CreateTable(
                "AkinsoftAdmin.Loglar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Detail = c.String(),
                        Audit = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Akinsoft.KullaniciSifre", "KullaniciId", "Akinsoft.Kullanicilar");
            DropForeignKey("Akinsoft.KullaniciRoller", "RolId", "Akinsoft.Roller");
            DropForeignKey("Akinsoft.KullaniciRoller", "KullaniciId", "Akinsoft.Kullanicilar");
            DropForeignKey("Akinsoft.Bolumler", "FakulteId", "Akinsoft.Fakulteler");
            DropForeignKey("Akinsoft.OgrenciTelefonlar", "OgrenciId", "Akinsoft.Ogrenciler");
            DropForeignKey("Akinsoft.OgrenciMailler", "OgrenciId", "Akinsoft.Ogrenciler");
            DropForeignKey("Akinsoft.KitapHareketler", "OgrenciId", "Akinsoft.Ogrenciler");
            DropForeignKey("Akinsoft.KitapHareketler", "KitapId", "Akinsoft.Kitaplar");
            DropForeignKey("Akinsoft.Kitaplar", "KitapKategoriId", "Akinsoft.KitapKategoriler");
            DropForeignKey("Akinsoft.KitapAnahtarlar", "KitapId", "Akinsoft.Kitaplar");
            DropForeignKey("Akinsoft.OgrenciAdresler", "OgrenciId", "Akinsoft.Ogrenciler");
            DropForeignKey("Akinsoft.Ogrenciler", "BolumId", "Akinsoft.Bolumler");
            DropIndex("Akinsoft.KullaniciSifre", new[] { "KullaniciId" });
            DropIndex("Akinsoft.KullaniciRoller", new[] { "RolId" });
            DropIndex("Akinsoft.KullaniciRoller", new[] { "KullaniciId" });
            DropIndex("Akinsoft.Fakulteler", new[] { "Adi" });
            DropIndex("Akinsoft.OgrenciTelefonlar", new[] { "OgrenciId" });
            DropIndex("Akinsoft.OgrenciMailler", new[] { "OgrenciId" });
            DropIndex("Akinsoft.KitapAnahtarlar", new[] { "KitapId" });
            DropIndex("Akinsoft.KitapAnahtarlar", new[] { "Anahtar" });
            DropIndex("Akinsoft.Kitaplar", new[] { "KitapKategoriId" });
            DropIndex("Akinsoft.Kitaplar", new[] { "ISBN" });
            DropIndex("Akinsoft.Kitaplar", new[] { "Yazar" });
            DropIndex("Akinsoft.Kitaplar", new[] { "Adi" });
            DropIndex("Akinsoft.KitapHareketler", new[] { "AlinmaTarihi" });
            DropIndex("Akinsoft.KitapHareketler", new[] { "KitapId" });
            DropIndex("Akinsoft.KitapHareketler", new[] { "OgrenciId" });
            DropIndex("Akinsoft.OgrenciAdresler", new[] { "OgrenciId" });
            DropIndex("Akinsoft.Ogrenciler", new[] { "BolumId" });
            DropIndex("Akinsoft.Ogrenciler", new[] { "Numara" });
            DropIndex("Akinsoft.Ogrenciler", new[] { "Soyad" });
            DropIndex("Akinsoft.Ogrenciler", new[] { "Ad" });
            DropIndex("Akinsoft.Bolumler", new[] { "FakulteId" });
            DropIndex("Akinsoft.Bolumler", new[] { "Adi" });
            DropTable("AkinsoftAdmin.Loglar");
            DropTable("Akinsoft.KullaniciSifre");
            DropTable("Akinsoft.Roller");
            DropTable("Akinsoft.KullaniciRoller");
            DropTable("Akinsoft.Kullanicilar");
            DropTable("Akinsoft.Fakulteler");
            DropTable("Akinsoft.OgrenciTelefonlar");
            DropTable("Akinsoft.OgrenciMailler");
            DropTable("Akinsoft.KitapKategoriler");
            DropTable("Akinsoft.KitapAnahtarlar");
            DropTable("Akinsoft.Kitaplar");
            DropTable("Akinsoft.KitapHareketler");
            DropTable("Akinsoft.OgrenciAdresler");
            DropTable("Akinsoft.Ogrenciler");
            DropTable("Akinsoft.Bolumler");
        }
    }
}
