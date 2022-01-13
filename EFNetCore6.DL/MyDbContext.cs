using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using EFNetCore6.DL.Entity;
using EFNetCore6.Auxiliary.Helpers;
using EFNetCore6.DL.DI;

namespace EFNetCore6.DL
{
    // Внимание !!! Для миграции через nuget менеджер пакетов ( Add-Migration InitialCreate ), обязательно выставлять Default Project.
    // Или миграцию делать с консоли через dotnet ef migration InitialCreate. После миграции делать Update-Database, или dotnet ef database update 
    public class MyDbContext : DbContext
    {
        const string SectionName = "ConnectionStrings";
        const string ItemName = "MigrationsDbConnection";
        private string _connectionString;

        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<LivingAddress> LivingAddresses { get; set; }
        public DbSet<VwPersonCarLivingAddress> VwPersonCarLivingAddress { get; set; }
        public MyDbContext()
        {
            _connectionString = new ConfigurationHelperFactory().Create().GetItem(SectionName, ItemName);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
               .Property(p => p.Id)
               .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Car>()
               .Property(p => p.Id)
               .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<LivingAddress>()
               .Property(p => p.Id)
               .HasDefaultValueSql("NEWID()");

            modelBuilder
                .Entity<VwPersonCarLivingAddress>()
                .ToView(nameof(VwPersonCarLivingAddress))
                .HasKey(x => x.PersonId);
        }
    }

        //----------------------------------------------------------------------------------------------------------
        //protected override void Up(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.Sql(@"
        //        CREATE PROCEDURE prcPersonCarAddressBy
        //            @locality nvarchar,   
        //            @startBirthDate DATETIME2  
        //        AS
        //          DECLARE @temp_loc NVARCHAR(100);
        //          SET @temp_loc = '%' + @locality + '%';
        //          SELECT
        //            FirstName
        //           ,LastName
        //           ,BirthDate
        //           ,Brand
        //           ,Model
        //           ,Locality
        //           ,Street
        //           ,House
        //           ,Apartment
        //          FROM dbo.vwPersonCarLivingAddresses
        //          WHERE Locality LIKE @temp_loc  AND BirthDate >= @startBirthDate
        //        GO
        //    ");
        //}
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.Sql(@"
        //        DROP PROCEDURE prcPersonCarAddressBy
        //        GO
        //    ");
        //}
        //----------------------------------------------------------------------------------------------------------
        //Для создания представления, создать новую миграцию и добавить например:
        //public partial class AddView : Migration
        //{
        //    protected override void Up(MigrationBuilder migrationBuilder)
        //    {
        //        migrationBuilder.Sql(@"
        //            CREATE VIEW vwPersonCarLivingAddress AS
        //            SELECT 
        //              TP.Id AS PersonId
        //             ,TP.FirstName
        //             ,TP.LastName
        //             ,TP.BirthDate 
        //             ,TC.Id AS CarId
        //             ,TC.Brand
        //             ,TC.Model
        //             ,TC.Body
        //             ,TC.DoorsCount
        //             ,TC.Power
        //             ,TA.Id AS LivingAddressId
        //             ,TA.Country
        //             ,TA.Region
        //             ,TA.Locality
        //             ,TA.Street
        //             ,TA.House
        //             ,TA.Apartment
        //            FROM dbo.Persons AS TP
        //            LEFT JOIN Cars AS TC ON TP.Id = TC.PersonId
        //            LEFT JOIN LivingAddress AS TA ON TP.Id = TA.PersonId
        //        ");
        //    }
        //    protected override void Down(MigrationBuilder migrationBuilder)
        //    {
        //        migrationBuilder.Sql(@"
        //                drop view vwPersonCarLivingAddress;
        //            ");
        //    }
        //----------------------------------------------------------------------------------------------------------
        //protected override void Up(MigrationBuilder migrationBuilder)
        //        {
        //            migrationBuilder.Sql(@"
        //                INSERT INTO dbo.Persons
        //                (
        //                  FirstName
        //                 , LastName
        //                 , BirthDate
        //                )
        //                VALUES
        //                (
        //                  N'Василий'
        //                 , N'Чапаев'
        //                 , CONVERT(DATETIME2, '1890-04-11')
        //                )
        //                GO
        //
        //                INSERT INTO dbo.Persons
        //                (
        //                  FirstName
        //                 , LastName
        //                 , BirthDate
        //                )
        //                VALUES
        //                (
        //                  N'Петр'
        //                 , N'Исаев'
        //                 , CONVERT(DATETIME2, '1900-08-09')
        //                )
        //                GO
        //
        //                INSERT INTO dbo.Persons
        //                (
        //                  FirstName
        //                 , LastName
        //                 , BirthDate
        //                )
        //                VALUES
        //                (
        //                  N'Григорий'
        //                 , N'Котовский'
        //                 , CONVERT(DATETIME2, '1893-05-22')
        //                )
        //                GO
        //
        //                INSERT INTO dbo.Persons
        //                (
        //                  FirstName
        //                 , LastName
        //                 , BirthDate
        //                )
        //                VALUES
        //                (
        //                  N'Анна'
        //                 , N'Стешенко'
        //                 , CONVERT(DATETIME2, '1898-03-12')
        //                )
        //                GO
        //
        //                DECLARE @Id1 uniqueidentifier;
        //                SET @Id1 = ( SELECT TOP(1) Id FROM dbo.Persons WHERE FirstName = N'Василий' )
        //
        //                DECLARE @Id2 uniqueidentifier;
        //                SET @Id2 = ( SELECT TOP(1) Id FROM dbo.Persons WHERE FirstName = N'Петр' )
        //
        //                DECLARE @Id3 uniqueidentifier;
        //                SET @Id3 = ( SELECT TOP(1) Id FROM dbo.Persons WHERE FirstName = N'Григорий' )
        //
        //                DECLARE @Id4 uniqueidentifier;
        //                SET @Id4 = ( SELECT TOP(1) Id FROM dbo.Persons WHERE FirstName = N'Анна' )
        //
        //                INSERT INTO dbo.Cars
        //                (
        //                  Brand
        //                 ,Model
        //                 ,Body
        //                 ,DoorsCount
        //                 ,Power
        //                 ,PersonId
        //                )
        //                VALUES
        //                (
        //                  N'Руссо-Балт'
        //                 , N'C'
        //                 , N'Седан'
        //                 , 4
        //                 , 40
        //                 , @Id1
        //                )
        //
        //                INSERT INTO dbo.Cars
        //                (
        //                  Brand
        //                 ,Model
        //                 ,Body
        //                 ,DoorsCount
        //                 ,Power
        //                 ,PersonId
        //                )
        //                VALUES
        //                (
        //                   N'Константинов и К'
        //                 , N'11/33'
        //                 , N'Пролетка'
        //                 , 2
        //                 , 1
        //                 , @Id4
        //                )
        //
        //                INSERT INTO dbo.LivingAddresses
        //                (
        //                  Country
        //                 ,Region
        //                 ,Locality
        //                 ,Street
        //                 ,House
        //                 ,Apartment
        //                 ,PersonId
        //                )
        //                VALUES
        //                (
        //                  N'РСФСР'
        //                 ,N'Ленинградсая область'
        //                 ,N'Петроград'
        //                 ,N'Мойка' 
        //                 ,52 
        //                 ,34 
        //                 ,@Id1
        //                );
        //
        //                INSERT INTO dbo.LivingAddresses
        //                (
        //                  Country
        //                 ,Region
        //                 ,Locality
        //                 ,Street
        //                 ,House
        //                 ,Apartment
        //                 ,PersonId
        //                )
        //                VALUES
        //                (
        //                  N'РСФСР'
        //                 ,N'Ленинградсая область'
        //                 ,N'Петроград'
        //                 ,N'Мойка' 
        //                 ,70 
        //                 ,9 
        //                 ,@Id2
        //                );
        //
        //                INSERT INTO dbo.LivingAddresses
        //                (
        //                  Country
        //                 ,Region
        //                 ,Locality
        //                 ,Street
        //                 ,House
        //                 ,Apartment
        //                 ,PersonId
        //                )
        //                VALUES
        //                (
        //                  N'РСФСР'
        //                 ,N'Ивановская область'
        //                 ,N'Иваново'
        //                 ,N'Ленина' 
        //                 ,30 
        //                 ,15 
        //                 ,@Id3
        //                );
        //
        //                INSERT INTO dbo.LivingAddresses
        //                (
        //                  Country
        //                 ,Region
        //                 ,Locality
        //                 ,Street
        //                 ,House
        //                 ,Apartment
        //                 ,PersonId
        //                )
        //                VALUES
        //                (
        //                  N'РСФСР'
        //                 ,N'Ивановская область'
        //                 ,N'Иваново'
        //                 ,N'Ленина' 
        //                 ,50 
        //                 ,8 
        //                 ,@Id4
        //                );
        //                GO
        //            ");
        //        }
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.Sql(@"
        //                DELETE dbo.Cars;
        //                DELETE dbo.LivingAddresses;
        //                DELETE dbo.Persons;
        //                GO
        //            ");
        //}
    }
