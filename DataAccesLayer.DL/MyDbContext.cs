using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using DataAccessLayer.DL.Entity;
using DataAccessLayer.Auxiliary.Helpers;

namespace Migrations.Test
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
            _connectionString = Configuration.GetItem(SectionName, ItemName);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
