using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using EFNetCore6.Auxiliary.DI;
using EFNetCore6.DL;

namespace EFNetCore6.DAL.DI
{
    public  class MyDbContextFactory: SimpleFactory<DbContext, MyDbContext>, ISimpleFactory<DbContext>
    {
    }
}
