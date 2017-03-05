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
                        email = c.String(),
                        senha = c.String(),
                        nascimento = c.DateTime(nullable: false),
                        profissao = c.String(),
                        rg = c.String(),
                        rg_uf = c.String(),
                        cpf = c.String(),
                        cnpj = c.String(),
                        data_cadastro = c.DateTime(nullable: false),
                        bloqueado = c.Boolean(nullable: false),
                        telefone1_id = c.Int(),
                        telefone2_id = c.Int(),
                        tipo_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Telefone", t => t.telefone1_id)
                .ForeignKey("dbo.Telefone", t => t.telefone2_id)
                .ForeignKey("dbo.TipoPessoa", t => t.tipo_id)
                .Index(t => t.telefone1_id)
                .Index(t => t.telefone2_id)
                .Index(t => t.tipo_id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comprador_id = c.Int(nullable: false),
                        cep = c.String(),
                        endereco = c.String(),
                        numero = c.String(),
                        complemento = c.String(),
                        bairro = c.String(),
                        cidade = c.String(),
                        estado = c.String(),
                        referencia = c.String(),
                        principal = c.Boolean(nullable: false),
                        //Comprador_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Comprador", t => t.comprador_id)
                .Index(t => t.comprador_id);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ddd = c.Int(nullable: false),
                        numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TipoPessoa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fisica = c.Boolean(nullable: false),
                        juridica = c.Boolean(nullable: false),
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
                        comprador_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Comprador", t => t.comprador_id, cascadeDelete: true)
                .Index(t => t.comprador_id);
            
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
            DropForeignKey("dbo.Pedido", "comprador_id", "dbo.Comprador");
            DropForeignKey("dbo.Comprador", "tipo_id", "dbo.TipoPessoa");
            DropForeignKey("dbo.Comprador", "telefone2_id", "dbo.Telefone");
            DropForeignKey("dbo.Comprador", "telefone1_id", "dbo.Telefone");
            DropForeignKey("dbo.Endereco", "comprador_id", "dbo.Comprador");
            DropIndex("dbo.Produto", new[] { "Categoria_id" });
            DropIndex("dbo.Pedido", new[] { "comprador_id" });
            DropIndex("dbo.Endereco", new[] { "comprador_id" });
            DropIndex("dbo.Comprador", new[] { "tipo_id" });
            DropIndex("dbo.Comprador", new[] { "telefone2_id" });
            DropIndex("dbo.Comprador", new[] { "telefone1_id" });
            DropTable("dbo.Produto");
            DropTable("dbo.Pedido");
            DropTable("dbo.Lojista");
            DropTable("dbo.Frete");
            DropTable("dbo.TipoPessoa");
            DropTable("dbo.Telefone");
            DropTable("dbo.Endereco");
            DropTable("dbo.Comprador");
            DropTable("dbo.Categoria");
        }
    }
}
