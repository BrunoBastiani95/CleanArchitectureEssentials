using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Products(Name, Description,
                Price, Stock, Image, CategoryId) VALUES ('Caderno Espiral',
                'Caderno espiral 100 folhas', 7.45, 50, 'caderno1.jpg' ,1);");

            migrationBuilder.Sql(@"INSERT INTO Products(Name, Description,
                Price, Stock, Image, CategoryId) VALUES ('Estojo',
                'Estojo escolar', 7.45, 50, 'estojo1.jpg' ,1);");

            migrationBuilder.Sql(@"INSERT INTO Products(Name, Description,
                Price, Stock, Image, CategoryId) VALUES ('Borracha',
                'Borracha escolar', 7.45, 50, 'borracha1.jpg' ,1);");

            migrationBuilder.Sql(@"INSERT INTO Products(Name, Description,
                Price, Stock, Image, CategoryId) VALUES ('Calculadora',
                'Calculadora escolar', 7.45, 50, 'calculadora1.jpg' ,2);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
