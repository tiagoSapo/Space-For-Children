namespace TrabalhoPraticoPWeb1718.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInstituicaoAutorizacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstituicaoAutorizacaos",
                c => new
                    {
                        InstituicaoAutorizacaoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        NumeroProfessores = c.Int(nullable: false),
                        Cidade = c.String(),
                        Contacto = c.String(),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.InstituicaoAutorizacaoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InstituicaoAutorizacaos");
        }
    }
}
