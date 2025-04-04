namespace Personas.API.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class personasMigracionInicial : DbMigration
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

            Sql(@"
                INSERT INTO Personas (Nombre, Apellido, NumeroIdentificacion, Tipo, Email, Telefono, Especialidad, NumeroLicencia) VALUES 
                ('Juan', 'Pérez', '123456789', 1, 'juan.perez@email.com', '3001234567', 'Cardiología', 'MED12345'),
                ('María', 'Gómez', '987654321', 2, 'maria.gomez@email.com', '3109876543', NULL, NULL),
                ('Carlos', 'López', '456789123', 1, 'carlos.lopez@email.com', '3156549871', 'Pediatría', 'MED67890'),
                ('Ana', 'Ramírez', '789123456', 2, 'ana.ramirez@email.com', '3207418529', NULL, NULL),
                ('Luis', 'Fernández', '321654987', 1, 'luis.fernandez@email.com', '3129638527', 'Dermatología', 'MED54321');
            ");

        }

        public override void Down()
        {
            DropTable("dbo.Personas");
        }
    }
}
