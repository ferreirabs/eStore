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
                        nome = c.String(),
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
                "dbo.Produto",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(nullable: false),
                        nome = c.String(nullable: false, maxLength: 300),
                        preco = c.Decimal(nullable: false, precision: 18, scale: 2),
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
            DropTable("dbo.Lojista");
            DropTable("dbo.Categoria");
        }
    }
}
