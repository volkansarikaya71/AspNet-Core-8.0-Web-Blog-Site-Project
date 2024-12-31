using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_triger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE TRIGGER AddBlogInRatingTable
        AFTER INSERT ON Blogs
        FOR EACH ROW
        BEGIN
            INSERT INTO BlogRaytings (BlogId, BlogTotalScore, BlogRaytingsCount)
            VALUES (NEW.BlogId, 0, 0);
        END;
    ");

            migrationBuilder.Sql(@"
        CREATE TRIGGER AddScoreInComment
        AFTER INSERT ON Comments
        FOR EACH ROW
        BEGIN
            UPDATE BlogRaytings
            SET 
                BlogTotalScore = BlogTotalScore + NEW.BlogScore,
                BlogRaytingsCount = BlogRaytingsCount + 1
            WHERE BlogId = NEW.BlogId;
        END;
    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS AddBlogInRatingTable;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS AddScoreInComment;");
        }

    }
}
