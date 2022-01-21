using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFNetCore6.DL.Migrations
{
    public partial class FillDictionaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO dbo.Dictionaries
                (
                  EnumId
                 ,Name
                 ,Description
                )
                VALUES
                ( 
                  1 -- EnumId - int NOT NULL
                 ,N'Должность' -- Name - nvarchar(max) NOT NULL
                 ,N'Должность, занимаемая человеком. Не звание!' -- Description - nvarchar(max) NOT NULL
                );
                GO
                DECLARE @Id1 uniqueidentifier;
                SET @Id1 = ( SELECT TOP(1) Id FROM dbo.Dictionaries WHERE Name LIKE N'%Должность%' );
                INSERT INTO dbo.DictionaryValues( EnumId,Name,DictionaryId,Description) VALUES( 1, N'Солдат',@Id1 ,N'Солдат красной армии' );
                INSERT INTO dbo.DictionaryValues( EnumId,Name,DictionaryId,Description) VALUES( 2, N'Пулеметчик',@Id1 ,N'Оператор пулемета' );
                INSERT INTO dbo.DictionaryValues( EnumId,Name,DictionaryId,Description) VALUES( 3, N'Комдив',@Id1 ,N'Командир дивизии' );
                INSERT INTO dbo.DictionaryValues( EnumId,Name,DictionaryId,Description) VALUES( 4, N'Коммисар',@Id1 ,N'Представитель Коммунистической партии в военных частях, наделённый командными полномочиями' );
                GO
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE DictionaryValues
                GO
                DELETE Dictionaries
                GO
            ");
        }
    }
}
