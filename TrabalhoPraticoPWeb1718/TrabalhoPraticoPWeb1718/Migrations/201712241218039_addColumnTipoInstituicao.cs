namespace TrabalhoPraticoPWeb1718.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnTipoInstituicao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instituicoes", "TipoInstituicao", c => c.String());
            AddColumn("dbo.InstituicaoAutorizacaos", "TipoInstituicao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InstituicaoAutorizacaos", "TipoInstituicao");
            DropColumn("dbo.Instituicoes", "TipoInstituicao");
        }
    }
}
