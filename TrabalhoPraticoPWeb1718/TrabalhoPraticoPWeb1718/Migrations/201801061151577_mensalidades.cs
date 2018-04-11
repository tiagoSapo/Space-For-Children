namespace TrabalhoPraticoPWeb1718.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mensalidades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instituicoes", "Mensalidade", c => c.Int(nullable: false));
            AddColumn("dbo.InstituicaoAutorizacaos", "Mensalidade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InstituicaoAutorizacaos", "Mensalidade");
            DropColumn("dbo.Instituicoes", "Mensalidade");
        }
    }
}
