namespace Citas.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class citasmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citas",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    PacienteId = c.Int(),
                    MedicoId = c.Int(),
                    FechaHora = c.DateTime(),
                    Motivo = c.Int(nullable: false),
                    Estado = c.String()

                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Citas");
        }

    
}
}
