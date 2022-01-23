using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFNetCore6.DL.Migrations
{
    public partial class AddDic2Person3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE dbo.Cars;
                DELETE dbo.LivingAddresses;
                DELETE dbo.Persons;
                GO
            ");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PositionId",
                table: "Persons",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_DictionaryValues_PositionId",
                table: "Persons",
                column: "PositionId",
                principalTable: "DictionaryValues",
                principalColumn: "Id");

            migrationBuilder.Sql(@"
                DECLARE @Id1 uniqueidentifier;
                SET @Id1 = ( SELECT TOP(1) Id FROM dbo.DictionaryValues WHERE Name = N'Комдив' )

                DECLARE @Id2 uniqueidentifier;
                SET @Id2 = ( SELECT TOP(1) Id FROM dbo.DictionaryValues WHERE Name = N'Солдат' )

                DECLARE @Id3 uniqueidentifier;
                SET @Id3 = ( SELECT TOP(1) Id FROM dbo.DictionaryValues WHERE Name = N'Пулеметчик' )

                DECLARE @Id4 uniqueidentifier;
                SET @Id4 = ( SELECT TOP(1) Id FROM dbo.DictionaryValues WHERE Name = N'Коммисар' )

                INSERT INTO dbo.Persons
                (
                  FirstName
                 , LastName
                 , BirthDate
                 , PositionId
                )
                VALUES
                (
                  N'Василий'
                 , N'Чапаев'
                 , CONVERT(DATETIME2, '1890-04-11')
                 , @Id1
                )                

                INSERT INTO dbo.Persons
                (
                  FirstName
                 , LastName
                 , BirthDate
                 , PositionId
                )
                VALUES
                (
                  N'Петр'
                 , N'Исаев'
                 , CONVERT(DATETIME2, '1900-08-09')
                 , @Id2
                )                

                INSERT INTO dbo.Persons
                (
                  FirstName
                 , LastName
                 , BirthDate
                 , PositionId
                )
                VALUES
                (
                  N'Дмитрий'
                 , N'Фурманов'
                 , CONVERT(DATETIME2, '1893-05-22')
                 , @Id4
                )                

                INSERT INTO dbo.Persons
                (
                  FirstName
                 , LastName
                 , BirthDate
                 , PositionId
                )
                VALUES
                (
                  N'Анна'
                 , N'Стешенко'
                 , CONVERT(DATETIME2, '1898-03-12')
                 , @Id3
                )
                GO

                DECLARE @Id1 uniqueidentifier;
                SET @Id1 = ( SELECT TOP(1) Id FROM dbo.Persons WHERE FirstName = N'Василий' )

                DECLARE @Id2 uniqueidentifier;
                SET @Id2 = ( SELECT TOP(1) Id FROM dbo.Persons WHERE FirstName = N'Петр' )

                DECLARE @Id3 uniqueidentifier;
                SET @Id3 = ( SELECT TOP(1) Id FROM dbo.Persons WHERE FirstName = N'Дмитрий' )

                DECLARE @Id4 uniqueidentifier;
                SET @Id4 = ( SELECT TOP(1) Id FROM dbo.Persons WHERE FirstName = N'Анна' )

                INSERT INTO dbo.Cars
                (
                  Brand
                 ,Model
                 ,Body
                 ,DoorsCount
                 ,Power
                 ,PersonId
                )
                VALUES
                (
                  N'Руссо-Балт'
                 , N'C'
                 , N'Седан'
                 , 4
                 , 40
                 , @Id1
                )

                INSERT INTO dbo.Cars
                (
                  Brand
                 ,Model
                 ,Body
                 ,DoorsCount
                 ,Power
                 ,PersonId
                )
                VALUES
                (
                   N'Константинов и К'
                 , N'11/33'
                 , N'Пролетка'
                 , 2
                 , 1
                 , @Id4
                )

                INSERT INTO dbo.LivingAddresses
                (
                  Country
                 ,Region
                 ,Locality
                 ,Street
                 ,House
                 ,Apartment
                 ,PersonId
                )
                VALUES
                (
                  N'РСФСР'
                 ,N'Ленинградсая область'
                 ,N'Петроград'
                 ,N'Мойка' 
                 ,52 
                 ,34 
                 ,@Id1
                );

                INSERT INTO dbo.LivingAddresses
                (
                  Country
                 ,Region
                 ,Locality
                 ,Street
                 ,House
                 ,Apartment
                 ,PersonId
                )
                VALUES
                (
                  N'РСФСР'
                 ,N'Ленинградсая область'
                 ,N'Петроград'
                 ,N'Мойка' 
                 ,70 
                 ,9 
                 ,@Id2
                );

                INSERT INTO dbo.LivingAddresses
                (
                  Country
                 ,Region
                 ,Locality
                 ,Street
                 ,House
                 ,Apartment
                 ,PersonId
                )
                VALUES
                (
                  N'РСФСР'
                 ,N'Ивановская область'
                 ,N'Иваново'
                 ,N'Ленина' 
                 ,30 
                 ,15 
                 ,@Id3
                );

                INSERT INTO dbo.LivingAddresses
                (
                  Country
                 ,Region
                 ,Locality
                 ,Street
                 ,House
                 ,Apartment
                 ,PersonId
                )
                VALUES
                (
                  N'РСФСР'
                 ,N'Ивановская область'
                 ,N'Иваново'
                 ,N'Ленина' 
                 ,50 
                 ,8 
                 ,@Id4
                );
                GO
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_DictionaryValues_PositionId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PositionId",
                table: "Persons");
        }
    }
}
