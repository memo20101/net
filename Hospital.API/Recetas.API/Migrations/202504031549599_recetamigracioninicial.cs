namespace Recetas.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recetamigracioninicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CitaId = c.Int(nullable: false),
                        PacienteId = c.Int(nullable: false),
                        MedicoId = c.Int(nullable: false),
                        FechaEmision = c.DateTime(nullable: false),
                        FechaVencimiento = c.DateTime(),
                        Estado = c.Int(nullable: false),
                        Medicamentos = c.String(nullable: false),
                        Instrucciones = c.String(maxLength: 1000),
                        Observaciones = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Recetas");
        }
    }
}
