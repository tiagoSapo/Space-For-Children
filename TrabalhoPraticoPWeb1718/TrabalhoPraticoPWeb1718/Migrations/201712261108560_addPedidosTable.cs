namespace TrabalhoPraticoPWeb1718.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPedidosTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        PedidosId = c.Int(nullable: false, identity: true),
                        PaiId = c.Int(nullable: false),
                        InstituicaoId = c.Int(nullable: false),
                        MsgPai = c.String(),
                        MsgInstituicao = c.String(),
                    })
                .PrimaryKey(t => t.PedidosId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pedidos");
        }
    }
}
