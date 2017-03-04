namespace eStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        nome = c.String(),
                        descricao = c.String(),
                        bloqueado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Comprador",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Frete",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 300),
                        tipo = c.String(nullable: false),
                        ordem = c.String(nullable: false),
                        status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Lojista",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        data_pedido = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                        data_alteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(nullable: false),
                        nome = c.String(nullable: false, maxLength: 300),
                        preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ordem = c.Int(nullable: false),
                        bloqueado = c.Boolean(nullable: false),
                        Categoria_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_id)
                .Index(t => t.Categoria_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "Categoria_id", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "Categoria_id" });
            DropTable("dbo.Produto");
            DropTable("dbo.Pedido");
            DropTable("dbo.Lojista");
            DropTable("dbo.Frete");
            DropTable("dbo.Comprador");
            DropTable("dbo.Categoria");
        }
    }
}
