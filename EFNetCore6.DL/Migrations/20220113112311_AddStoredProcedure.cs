using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFNetCore6.DL.Migrations
{
    public partial class AddStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE prcPersonCarAddressBy
                    @locality nvarchar,   
                    @startBirthDate DATETIME2  
                AS
                  DECLARE @temp_loc NVARCHAR(100);
                  SET @temp_loc = '%' + @locality + '%';
                  SELECT
                    FirstName
                   ,LastName
                   ,BirthDate
                   ,Brand
                   ,Model
                   ,Locality
                   ,Street
                   ,House
                   ,Apartment
                  FROM dbo.vwPersonCarLivingAddresses
                  WHERE Locality LIKE @temp_loc  AND BirthDate >= @startBirthDate
                GO
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE prcPersonCarAddressBy
                GO
            ");
        }
    }
}
