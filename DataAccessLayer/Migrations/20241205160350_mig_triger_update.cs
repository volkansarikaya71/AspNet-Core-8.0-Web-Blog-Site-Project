using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_triger_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

CREATE TRIGGER UpdateBlogTotalScore
AFTER UPDATE ON Comments
FOR EACH ROW
BEGIN

    DECLARE totalScore INT;

            SELECT SUM(BlogScore)
    INTO totalScore
    FROM Comments
    WHERE BlogId = NEW.BlogId;

    UPDATE BlogRaytings
    SET BlogTotalScore = totalScore
    WHERE BlogId = NEW.BlogId;
            END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS UpdateBlogTotalScore;");
        }
    }
}
