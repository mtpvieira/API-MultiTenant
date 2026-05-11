using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MultiTenantSolution.Migrations
{
    /// <inheritdoc />
    public partial class Tenant01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "tenantId" },
                values: new object[,]
                {
                    { 1, "Alice Santos", "tenant-1" },
                    { 2, "Bob Silva", "tenant-1" },
                    { 3, "Carlos Oliveira", "tenant-2" },
                    { 4, "José Carvalho", "tenant-2" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "tenantId" },
                values: new object[,]
                {
                    { 1, "High-performance laptop", "Laptop Dell XPS 15", "tenant-1" },
                    { 2, "Ergonomic wireless mouse", "Mouse Logitech MX Master", "tenant-1" },
                    { 3, "Premium quality polo shirt", "Camiseta Polo Premium", "tenant-2" },
                    { 4, "Comfortable sports shoes", "Tênis Esportivo Nike", "tenant-2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
