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
        public MyDbContext()
        {
            _connectionString = new ConfigurationHelperFactory().Create().GetItem(SectionName, ItemName);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }

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


}
