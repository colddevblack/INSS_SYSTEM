namespace INSSWEBMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0012 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalculoModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NomeEmpregado = c.String(),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        descontoInss = c.Decimal(precision: 18, scale: 2),
                        SalarioLiquido = c.Decimal(precision: 18, scale: 2),
                        dataCriacaoCalculo = c.DateTime(nullable: false),
                        inssid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.InssModels", t => t.inssid, cascadeDelete: true)
                .Index(t => t.inssid);
            
            CreateTable(
                "dbo.InssModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ano = c.String(),
                        LimiteSalario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        porcentagem = c.Decimal(nullable: false, precision: 18, scale: 2),
                        dataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CalculoModels", "inssid", "dbo.InssModels");
            DropIndex("dbo.CalculoModels", new[] { "inssid" });
            DropTable("dbo.InssModels");
            DropTable("dbo.CalculoModels");
        }
    }
}
