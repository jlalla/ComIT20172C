namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FechasEntidades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articulos", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Usuarios", "FechaNacimiento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comentarios", "Fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comentarios", "Fecha");
            DropColumn("dbo.Usuarios", "FechaNacimiento");
            DropColumn("dbo.Articulos", "FechaCreacion");
        }
    }
}
