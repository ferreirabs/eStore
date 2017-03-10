namespace eStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrinho",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        codigo_comprador = c.String(),
                        FreteEntrega_id = c.Int(),
                        FretePagamento_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Frete", t => t.FreteEntrega_id)
                .ForeignKey("dbo.Frete", t => t.FretePagamento_id)
                .Index(t => t.FreteEntrega_id)
                .Index(t => t.FretePagamento_id);
            
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
                "dbo.Produto",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(nullable: false),
                        nome = c.String(nullable: false, maxLength: 300),
                        preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        descricao = c.String(),
                        estoque = c.Int(nullable: false),
                        ordem = c.Int(nullable: false),
                        bloqueado = c.Boolean(nullable: false),
                        Categoria_id = c.Int(),
                        Carrinho_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_id)
                .ForeignKey("dbo.Carrinho", t => t.Carrinho_id)
                .Index(t => t.Categoria_id)
                .Index(t => t.Carrinho_id);
            
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
                        id_comprador = c.Int(nullable: false),
                        pagamento_cc_name = c.String(),
                        pagamento_cc_emissor = c.String(),
                        pagamento_cc_mes = c.String(),
                        pagamento_cc_ano = c.String(),
                        pagamento_cc_number = c.String(),
                        pagamento_cc_cvc = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comprador", "tipo_id", "dbo.TipoPessoa");
            DropForeignKey("dbo.Comprador", "telefone2_id", "dbo.Telefone");
            DropForeignKey("dbo.Comprador", "telefone1_id", "dbo.Telefone");
            DropForeignKey("dbo.Endereco", "comprador_id", "dbo.Comprador");
            DropForeignKey("dbo.Produto", "Carrinho_id", "dbo.Carrinho");
            DropForeignKey("dbo.Produto", "Categoria_id", "dbo.Categoria");
            DropForeignKey("dbo.Carrinho", "FretePagamento_id", "dbo.Frete");
            DropForeignKey("dbo.Carrinho", "FreteEntrega_id", "dbo.Frete");
            DropIndex("dbo.Endereco", new[] { "comprador_id" });
            DropIndex("dbo.Comprador", new[] { "tipo_id" });
            DropIndex("dbo.Comprador", new[] { "telefone2_id" });
            DropIndex("dbo.Comprador", new[] { "telefone1_id" });
            DropIndex("dbo.Produto", new[] { "Carrinho_id" });
            DropIndex("dbo.Produto", new[] { "Categoria_id" });
            DropIndex("dbo.Carrinho", new[] { "FretePagamento_id" });
            DropIndex("dbo.Carrinho", new[] { "FreteEntrega_id" });
            DropTable("dbo.Pedido");
            DropTable("dbo.Lojista");
            DropTable("dbo.TipoPessoa");
            DropTable("dbo.Telefone");
            DropTable("dbo.Endereco");
            DropTable("dbo.Comprador");
            DropTable("dbo.Categoria");
            DropTable("dbo.Produto");
            DropTable("dbo.Frete");
            DropTable("dbo.Carrinho");
        }
    }
}
