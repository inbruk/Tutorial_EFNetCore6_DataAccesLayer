using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EFNetCore6.Auxiliary.DAL;
using EFNetCore6.Auxiliary.Helpers;

namespace EFNetCore6.Auxiliary.BL
{
    /// <summary>
    /// Базовый класс для создания репозиториев бизнес логики
    /// </summary>
    /// <typeparam name="DTO">дто уровня бизнес логики</typeparam>
    /// <typeparam name="ENT">дто уровня доступа к данным = EF entity</typeparam>
    public class CRUDRepositoryBase<DTO, ENT> : ReadOnlyRepositoryBase<DTO, ENT>, ICRUDRepository<DTO>
        where DTO : DTOBase
        where ENT : DTOBase
    {
        public virtual void Create(DTO newDTO)
        {
            CheckPresetAndParams(newDTO, @"CRUDRepositoryBase.Create({nameof(newDTO)}", null);
            var ent = _mappingHelper.Map<DTO, ENT>(newDTO);
            _unitOfWork.GetRepository<ENT>().Add(ent);
            _unitOfWork.SaveChanges();
        }
        public virtual DTO CreateAndGet(DTO newDTO)
        {
            CheckPresetAndParams(newDTO, @"CRUDRepositoryBase.CreateAndGet({nameof(newDTO)}", null);
            var ent = _mappingHelper.Map<DTO, ENT>(newDTO);
            //try
            //{
                _unitOfWork.GetRepository<ENT>().Add(ent);
                _unitOfWork.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    throw ex; // ловим для поиска ошибки при отладке, но прокидываем, чтобы не скрыть
            //}
            newDTO.Id = ent.Id;
            return newDTO;
        }
        public virtual void Update(DTO dtoItem)
        {
            CheckPresetAndParams(dtoItem, @"CRUDRepositoryBase.CreateAndGet({nameof(dtoItem)}", null);
            var ent = _mappingHelper.Map<DTO, ENT>(dtoItem);
            _unitOfWork.GetRepository<ENT>().Add(ent);
            _unitOfWork.SaveChanges();
        }
        public virtual void Delete(Guid id)
        {
            CheckPreset();
            var ent = _unitOfWork.GetRepository<ENT>().FirstOrDefault(x => x.Id == id);
            if (ent == null)
                return null;
            _unitOfWork.GetRepository<ENT>().Delete();
            _unitOfWork.SaveChanges();
        }

        // ------------------------------------------------------------------------------------------------
        public virtual void Create(List<DTO> newDTOList)
        public virtual List<DTO> CreateAndGet(List<DTO> newDTOList)
        public virtual void Update(List<DTO> dtoList)
        public virtual void Delete(List<Guid> idList)

    }
}
