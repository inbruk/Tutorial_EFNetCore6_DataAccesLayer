using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFNetCore6.DL.Migrations
{
    public partial class AddDic2Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.Sql(@"
                    drop view vwPersonCarLivingAddresses;
                ");

            migrationBuilder.Sql(@"
                CREATE VIEW vwPersonCarLivingAddresses AS
                SELECT 
                  TP.Id AS PersonId
                 ,TP.FirstName
                 ,TP.LastName
                 ,TP.BirthDate 
                 ,TP.PositionId
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
                 ,TDV.EnumId
                 ,TDV.Name
                 ,TDV.DictionaryId
                 ,TDV.Description
                FROM dbo.Persons AS TP
                LEFT JOIN Cars AS TC ON TP.Id = TC.PersonId
                LEFT JOIN LivingAddresses AS TA ON TP.Id = TA.PersonId
                LEFT JOIN DictionaryValues AS TDV ON TP.PositionId = TDV.Id
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Persons");

            migrationBuilder.Sql(@"
                    drop view vwPersonCarLivingAddresses;
                ");

            migrationBuilder.Sql(@"
                CREATE VIEW vwPersonCarLivingAddresses AS
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
                LEFT JOIN LivingAddresses AS TA ON TP.Id = TA.PersonId
            ");
        }
    }
}
