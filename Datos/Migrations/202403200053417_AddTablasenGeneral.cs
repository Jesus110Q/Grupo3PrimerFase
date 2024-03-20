namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablasenGeneral : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriaModels",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        DescripcionCM = c.String(nullable: false, maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                        FechadeCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.ClienteModels",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 15),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 50),
                        GrupoDescuentoId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.CategoriaModels", t => t.CategoriaId)
                .ForeignKey("dbo.GrupoDescuento", t => t.GrupoDescuentoId)
                .Index(t => t.GrupoDescuentoId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.GrupoDescuento",
                c => new
                    {
                        GrupoDescuentoId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        DescripcionGD = c.String(nullable: false, maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                        Porcentaje = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoDescuentoId);
            
            CreateTable(
                "dbo.CondicionPago",
                c => new
                    {
                        CondicionPagoId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        DescripcionCP = c.String(nullable: false, maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                        Dias = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CondicionPagoId);
            
            CreateTable(
                "dbo.ProductosModels",
                c => new
                    {
                        ProductosId = c.Int(nullable: false, identity: true),
                        UnidadMedidaId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        PrecioCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductosId)
                .ForeignKey("dbo.CategoriaModels", t => t.CategoriaId)
                .ForeignKey("dbo.UnidadMedida", t => t.UnidadMedidaId)
                .Index(t => t.UnidadMedidaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.UnidadMedida",
                c => new
                    {
                        UnidadMedidaId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        DescripcionUM = c.String(nullable: false, maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UnidadMedidaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductosModels", "UnidadMedidaId", "dbo.UnidadMedida");
            DropForeignKey("dbo.ProductosModels", "CategoriaId", "dbo.CategoriaModels");
            DropForeignKey("dbo.ClienteModels", "GrupoDescuentoId", "dbo.GrupoDescuento");
            DropForeignKey("dbo.ClienteModels", "CategoriaId", "dbo.CategoriaModels");
            DropIndex("dbo.ProductosModels", new[] { "CategoriaId" });
            DropIndex("dbo.ProductosModels", new[] { "UnidadMedidaId" });
            DropIndex("dbo.ClienteModels", new[] { "CategoriaId" });
            DropIndex("dbo.ClienteModels", new[] { "GrupoDescuentoId" });
            DropTable("dbo.UnidadMedida");
            DropTable("dbo.ProductosModels");
            DropTable("dbo.CondicionPago");
            DropTable("dbo.GrupoDescuento");
            DropTable("dbo.ClienteModels");
            DropTable("dbo.CategoriaModels");
        }
    }
}
