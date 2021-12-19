using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EFNetCore6.Auxiliary.DAL;
using EFNetCore6.Auxiliary.Helpers;

namespace EFNetCore6.Auxiliary.BL
{
    public interface ICRUDRepository<DTO> : IReadOnlyRepository<DTO>
        where DTO : DTOBase
    {
        void Create(DTO newDTO);
        DTO CreateAndGet(DTO newDTO);
        void Update(DTO dtoItem);
        void Delete(Guid id);
    // ----------------------------------------------              
        void Create(List<DTO> newDTOList);
        List<DTO> CreateAndGet(List<DTO> newDTOList);
        void Update(List<DTO> dtoList);
        void Delete(List<Guid> idList);
    }
}
