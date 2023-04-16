using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMPS278Backend.Migrations.CMPS278Data
{
    /// <inheritdoc />
    public partial class AddMoviesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trailer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    credits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sales = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reviews = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
