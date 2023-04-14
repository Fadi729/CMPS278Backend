using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMPS278Backend.Migrations.CMPS278Data
{
    /// <inheritdoc />
    public partial class AddGameData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameData",
                columns: table => new
                {
                    AppId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<double>(type: "float", nullable: true),
                    ScoreText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Free = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionHTML = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Installs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinInstalls = table.Column<long>(type: "bigint", nullable: true),
                    MaxInstalls = table.Column<long>(type: "bigint", nullable: true),
                    Ratings = table.Column<long>(type: "bigint", nullable: true),
                    ReviewsCount = table.Column<long>(type: "bigint", nullable: true),
                    Histogram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: true),
                    OffersIAP = table.Column<bool>(type: "bit", nullable: true),
                    IAPRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AndroidVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AndroidVersionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperInternalID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyGenre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyGenreId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Screenshots = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentRatingDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdSupported = table.Column<bool>(type: "bit", nullable: true),
                    Released = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<long>(type: "bigint", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecentChanges = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameData", x => x.AppId);
                });

            migrationBuilder.CreateTable(
                name: "GameReviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameAppId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<double>(type: "float", nullable: true),
                    ScoreText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplyDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplyText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbsUp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameReviews_GameData_GameAppId",
                        column: x => x.GameAppId,
                        principalTable: "GameData",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameReviews_GameAppId",
                table: "GameReviews",
                column: "GameAppId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameReviews");

            migrationBuilder.DropTable(
                name: "GameData");
        }
    }
}
