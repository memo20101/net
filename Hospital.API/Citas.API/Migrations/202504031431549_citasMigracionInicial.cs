namespace Citas.API.Migrations
{
  
    using System.Data.Entity.Migrations;
    
    public partial class citasMigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PacienteId = c.Int(nullable: false),
                        MedicoId = c.Int(nullable: false),
                        FechaHora = c.DateTime(nullable: false),
                        Motivo = c.String(),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO dbo.Citas (PacienteId, MedicoId, FechaHora, Motivo, Estado) VALUES (1, 101, '2025-04-10 10:00:00', 'Consulta general', 0)");
            Sql("INSERT INTO dbo.Citas (PacienteId, MedicoId, FechaHora, Motivo, Estado) VALUES (2, 102, '2025-04-11 11:30:00', 'Revisión anual', 1)");
            Sql("INSERT INTO dbo.Citas (PacienteId, MedicoId, FechaHora, Motivo, Estado) VALUES (3, 103, '2025-04-12 14:00:00', 'Chequeo pediátrico', 2)");

        }
        
        public override void Down()
        {
            DropTable("dbo.Citas");
        }
    }
}
