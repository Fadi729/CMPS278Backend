using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMPS278Backend.Migrations.CMPS278Data
{
    /// <inheritdoc />
    public partial class CreateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksDatas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "varchar(192)", unicode: false, maxLength: 192, nullable: false),
                    description = table.Column<string>(type: "varchar(3970)", unicode: false, maxLength: 3970, nullable: true),
                    authors = table.Column<string>(type: "varchar(270)", unicode: false, maxLength: 270, nullable: true),
                    image = table.Column<string>(type: "varchar(111)", unicode: false, maxLength: 111, nullable: true),
                    previewLink = table.Column<string>(type: "varchar(411)", unicode: false, maxLength: 411, nullable: true),
                    publisher = table.Column<string>(type: "varchar(49)", unicode: false, maxLength: 49, nullable: true),
                    publishedDate = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    infoLink = table.Column<string>(type: "varchar(261)", unicode: false, maxLength: 261, nullable: true),
                    categories = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ratingsCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BooksDat__3214EC07DBA92E56", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BooksReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_ID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "varchar(192)", unicode: false, maxLength: 192, nullable: true),
                    Price = table.Column<decimal>(type: "numeric(6,2)", nullable: true),
                    User_id = table.Column<string>(type: "varchar(21)", unicode: false, maxLength: 21, nullable: true),
                    profileName = table.Column<string>(type: "varchar(49)", unicode: false, maxLength: 49, nullable: true),
                    reviewhelpfulness = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
                    reviewscore = table.Column<decimal>(type: "numeric(3,1)", nullable: false),
                    reviewtime = table.Column<int>(type: "int", nullable: false),
                    reviewsummary = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    reviewtext = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BooksRev__3214EC07C302111E", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksDatas");

            migrationBuilder.DropTable(
                name: "BooksReviews");
        }
    }
}
