namespace TrabalhoPraticoPWeb1718.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Criancas",
                c => new
                    {
                        CriancaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Genero = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Avaliacao = c.Int(),
                        DataContrato = c.DateTime(nullable: false),
                        Ensino_EnsinoId = c.Int(nullable: false),
                        Instituicao_InstituicaoId = c.Int(nullable: false),
                        Pai_PaiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CriancaId)
                .ForeignKey("dbo.Ensinos", t => t.Ensino_EnsinoId, cascadeDelete: true)
                .ForeignKey("dbo.Instituicoes", t => t.Instituicao_InstituicaoId, cascadeDelete: true)
                .ForeignKey("dbo.Pais", t => t.Pai_PaiId, cascadeDelete: true)
                .Index(t => t.Ensino_EnsinoId)
                .Index(t => t.Instituicao_InstituicaoId)
                .Index(t => t.Pai_PaiId);
            
            CreateTable(
                "dbo.Ensinos",
                c => new
                    {
                        EnsinoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.EnsinoId);
            
            CreateTable(
                "dbo.Disciplinas",
                c => new
                    {
                        DisciplinaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Curso = c.Int(nullable: false),
                        Ensino_EnsinoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DisciplinaId)
                .ForeignKey("dbo.Ensinos", t => t.Ensino_EnsinoId, cascadeDelete: true)
                .Index(t => t.Ensino_EnsinoId);
            
            CreateTable(
                "dbo.Instituicoes",
                c => new
                    {
                        InstituicaoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        NumeroProfessores = c.Int(nullable: false),
                        Cidade = c.String(),
                        Contacto = c.String(),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.InstituicaoId);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        PaiId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cidade = c.String(),
                        Contacto = c.String(),
                        Nacionalidade = c.String(),
                    })
                .PrimaryKey(t => t.PaiId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MyProperty = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EnsinoInstituicoes",
                c => new
                    {
                        Ensino_EnsinoId = c.Int(nullable: false),
                        Instituicao_InstituicaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ensino_EnsinoId, t.Instituicao_InstituicaoId })
                .ForeignKey("dbo.Ensinos", t => t.Ensino_EnsinoId, cascadeDelete: true)
                .ForeignKey("dbo.Instituicoes", t => t.Instituicao_InstituicaoId, cascadeDelete: true)
                .Index(t => t.Ensino_EnsinoId)
                .Index(t => t.Instituicao_InstituicaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Criancas", "Pai_PaiId", "dbo.Pais");
            DropForeignKey("dbo.Criancas", "Instituicao_InstituicaoId", "dbo.Instituicoes");
            DropForeignKey("dbo.Criancas", "Ensino_EnsinoId", "dbo.Ensinos");
            DropForeignKey("dbo.EnsinoInstituicoes", "Instituicao_InstituicaoId", "dbo.Instituicoes");
            DropForeignKey("dbo.EnsinoInstituicoes", "Ensino_EnsinoId", "dbo.Ensinos");
            DropForeignKey("dbo.Disciplinas", "Ensino_EnsinoId", "dbo.Ensinos");
            DropIndex("dbo.EnsinoInstituicoes", new[] { "Instituicao_InstituicaoId" });
            DropIndex("dbo.EnsinoInstituicoes", new[] { "Ensino_EnsinoId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Disciplinas", new[] { "Ensino_EnsinoId" });
            DropIndex("dbo.Criancas", new[] { "Pai_PaiId" });
            DropIndex("dbo.Criancas", new[] { "Instituicao_InstituicaoId" });
            DropIndex("dbo.Criancas", new[] { "Ensino_EnsinoId" });
            DropTable("dbo.EnsinoInstituicoes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pais");
            DropTable("dbo.Instituicoes");
            DropTable("dbo.Disciplinas");
            DropTable("dbo.Ensinos");
            DropTable("dbo.Criancas");
        }
    }
}
