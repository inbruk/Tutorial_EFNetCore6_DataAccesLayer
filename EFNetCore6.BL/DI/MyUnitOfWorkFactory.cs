using Microsoft.EntityFrameworkCore;

using EFNetCore6.Auxiliary.DAL;
using EFNetCore6.Auxiliary.DI;
using EFNetCore6.DAL;

namespace EFNetCore6.BL.DI
{
    public class MyUnitOfWorkFactory : SimpleFactory<IUnitOfWork, MyUnitOfWork>, ISimpleFactory<IUnitOfWork>
    {
    }
}
