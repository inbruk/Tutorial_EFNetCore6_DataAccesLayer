using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using EFNetCore6.Auxiliary.EFData;
using EFNetCore6.DTO;
using EFNetCore6.DL;

namespace EFNetCore6.DAL
{
    public class MyUnitOfWork: UnitOfWork
    {
        public MyUnitOfWork()
            : base(new MyDbContext()) 
        {
        }
    }
}
