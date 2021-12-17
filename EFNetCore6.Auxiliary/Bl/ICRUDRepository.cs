using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNetCore6.Auxiliary.BL
{
    public interface ICRUDRepository<DTO, TID>
    {
        List<DTO> ReadAll();

        void Create(DTO newDTO);
        DTO CreateAndGet(DTO newDTO);
        DTO Read(TID id);
        void Update(DTO dtoItem);
        void Delete(TID id);
                
        void Create(List<DTO> newDTOList);
        List<DTO> CreateAndGet(List<DTO> newDTOList);
        List<DTO> Read(List<TID> idList);
        void Update(List<DTO> dtoList); 
        void Delete(List<TID> idList);
    }
}
