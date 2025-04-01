namespace Personas.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        NumeroIdentificacion = c.String(),
                        Tipo = c.Int(nullable: false),
                        Email = c.String(),
                        Telefono = c.String(),
                        Especialidad = c.String(),
                        NumeroLicencia = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personas");
        }
    }
}
