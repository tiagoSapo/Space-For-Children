namespace TrabalhoPraticoPWeb1718.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAutorizacaoPais : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaiAutorizacaos",
                c => new
                    {
                        PaiAutorizacaoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cidade = c.String(),
                        Contacto = c.String(),
                        Nacionalidade = c.String(),
                        IdInstituicaoPreencher = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaiAutorizacaoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaiAutorizacaos");
        }
    }
}
