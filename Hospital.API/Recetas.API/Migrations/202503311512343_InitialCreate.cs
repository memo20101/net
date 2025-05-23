﻿namespace Recetas.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PacienteId = c.Int(nullable: false),
                        MedicoId = c.Int(nullable: false),
                        FechaEmision = c.DateTime(nullable: false),
                        Detalle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Recetas");
        }
    }
}
