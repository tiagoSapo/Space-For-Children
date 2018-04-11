namespace TrabalhoPraticoPWeb1718.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNomeDaContaASPNETUSERS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NomeDaConta", c => c.String());
            DropColumn("dbo.AspNetUsers", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "NomeDaConta");
        }
    }
}
