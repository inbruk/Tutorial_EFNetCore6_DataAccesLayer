using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFNetCore6.DL.Migrations
{
    public partial class AddView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW vwPersonCarLivingAddress AS
                SELECT 
                  TP.Id AS PersonId
                 ,TP.FirstName
                 ,TP.LastName
                 ,TP.BirthDate 
                 ,TC.Id AS CarId
                 ,TC.Brand
                 ,TC.Model
                 ,TC.Body
                 ,TC.DoorsCount
                 ,TC.Power
                 ,TA.Id AS LivingAddressId
                 ,TA.Country
                 ,TA.Region
                 ,TA.Locality
                 ,TA.Street
                 ,TA.House
                 ,TA.Apartment
                FROM dbo.Persons AS TP
                LEFT JOIN Cars AS TC ON TP.Id = TC.PersonId
                LEFT JOIN LivingAddress AS TA ON TP.Id = TA.PersonId
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                drop view vwPersonCarLivingAddress;
            ");
        }
    }
}
