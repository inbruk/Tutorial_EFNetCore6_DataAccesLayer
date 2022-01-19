using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EFNetCore6.Auxiliary.DTO;
using EFNetCore6.Auxiliary.DAL;
using EFNetCore6.Auxiliary.Helpers;

namespace EFNetCore6.Auxiliary.BL
{
    public interface IReadOnlyRepository<DTO>
        where DTO : DTOBase
    {
        void Configure(IMappingHelper mh, IUnitOfWork uw, int rowsCount);
        int GetAllCount();
        DTO? Read(Guid id);
        List<DTO> ReadAll();
        List<DTO> Read(List<Guid> idList);
    }
}
