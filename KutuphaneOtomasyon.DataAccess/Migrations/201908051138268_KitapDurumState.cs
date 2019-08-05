namespace KutuphaneOtomasyon.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KitapDurumState : DbMigration
    {
        public override void Up()
        {
            AddColumn("Akinsoft.Kitaplar", "KitapDurum", c => c.Int(defaultValue:1));
            DropColumn("Akinsoft.Kitaplar", "BostaMi");
        }
        
        public override void Down()
        {
            AddColumn("Akinsoft.Kitaplar", "BostaMi", c => c.Boolean(nullable: false));
            DropColumn("Akinsoft.Kitaplar", "KitapDurum");
        }
    }
}
