namespace KutuphaneOtomasyon.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneNumberProblem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Akinsoft.OgrenciTelefonlar", "Telefon", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("Akinsoft.OgrenciTelefonlar", "Telefon", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
