using Microsoft.EntityFrameworkCore;

using EFNetCore6.Auxiliary.DI;
using EFNetCore6.DL;

namespace EFNetCore6.DAL.DI
{
    public  class MyDbContextFactory: SimpleFactory<DbContext, MyDbContext>, ISimpleFactory<DbContext>
    {
    }
}
