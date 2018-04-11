namespace TrabalhoPraticoPWeb1718.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnServicoEnsino : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InstituicaoAutorizacaos", "Servico", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InstituicaoAutorizacaos", "Servico");
        }
    }
}
