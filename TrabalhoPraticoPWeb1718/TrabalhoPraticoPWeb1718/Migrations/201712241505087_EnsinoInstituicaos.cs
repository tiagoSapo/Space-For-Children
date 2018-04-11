namespace TrabalhoPraticoPWeb1718.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnsinoInstituicaos : DbMigration
    {
        public override void Up()
        {
            RenameTable("EnsinoInstituicoes", "EnsinoInstituicaos");
        }
        
        public override void Down()
        {
            RenameTable("EnsinoInstituicaos", "EnsinoInstituicoes");
        }
    }
}
