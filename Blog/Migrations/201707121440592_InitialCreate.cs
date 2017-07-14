namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Texto = c.String(),
                        Imagen = c.String(),
                        Destacado = c.Boolean(nullable: false),
                        Autor_Mail = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.Autor_Mail)
                .Index(t => t.Autor_Mail);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Mail = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Nombre = c.String(),
                        Imagen = c.String(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.Mail);
            
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mail = c.String(),
                        Texto = c.String(),
                        Articulo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Articulos", t => t.Articulo_ID)
                .Index(t => t.Articulo_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "Articulo_ID", "dbo.Articulos");
            DropForeignKey("dbo.Articulos", "Autor_Mail", "dbo.Usuarios");
            DropIndex("dbo.Comentarios", new[] { "Articulo_ID" });
            DropIndex("dbo.Articulos", new[] { "Autor_Mail" });
            DropTable("dbo.Comentarios");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Articulos");
        }
    }
}
