using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using EFNetCore6.Auxiliary.DI;
using EFNetCore6.Auxiliary.DAL;
using EFNetCore6.DAL.DI;
using EFNetCore6.DL;

namespace EFNetCore6.DAL
{
    public class MyUnitOfWork: UnitOfWork
    {
        public MyUnitOfWork()
            : base( LazyBuilderAndHolder<DbContext, MyDbContext, MyDbContextFactory>.getInstance())       // common dbContext for all UnitOfWorks
            // : base( new MyDbContextFactory().Create() )                                                  // one DbContext per one UnitOfWork 
        {
        }
    }
}
