using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFNetCore6.DL.Migrations
{
    public partial class AddFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE FUNCTION fnAverageAge ()
                  RETURNS INT
                AS
                  BEGIN
                    DECLARE @today DATETIME
                    DECLARE @result INT
                    SELECT @today = GETDATE()
                    SELECT @result = FLOOR(AVG(FLOOR(DATEDIFF(day, BirthDate, @today) / 365.2425)))
                      FROM Persons
                      WHERE BirthDate IS NOT NULL
                    RETURN @result
                  END
                GO
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP FUNCTION fnAverageAge
                GO
            ");
        }
    }
}
