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
            _unitOfWork.GetRepository<ENT>().Add(ent);
            _unitOfWork.SaveChanges();
            DTO resDTO = _mappingHelper.Map<ENT, DTO>(ent);
            return resDTO;
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
                throw new CantDeleteAbsentItemException(id);
            _unitOfWork.GetRepository<ENT>().Delete(ent);
            _unitOfWork.SaveChanges();
        }
        // ------------------------------------------------------------------------------------------------
        protected virtual void CheckPresetAndParams<T>(object? param, string paramFullName, List<T> dtoList)
        {
            CheckPreset();

            if (param == null)
                throw new ArgumentNullException(paramFullName);

            int rowsCount = dtoList.Count;
            if (rowsCount > MaximumAcceptablePerformedRowsCount)
                throw new MaxAcceptPerfRowsCountExceededException((int)rowsCount, MaximumAcceptablePerformedRowsCount);
        }
        public virtual void Create(List<DTO> newDTOList)
        {
            CheckPresetAndParams(newDTOList, @"CRUDRepositoryBase.Create({nameof(newDTOList)}", newDTOList);

            var entList = _mappingHelper.Map<DTO,ENT>(newDTOList);
            _unitOfWork.GetRepository<ENT>().AddRange(entList);
            _unitOfWork.SaveChanges();
        }
        public virtual List<DTO> CreateAndGet(List<DTO> newDTOList)
        {
            CheckPresetAndParams(newDTOList, @"CRUDRepositoryBase.CreateAndGet({nameof(newDTOList)}", newDTOList);

            var entList = _mappingHelper.Map<DTO, ENT>(newDTOList);
            _unitOfWork.GetRepository<ENT>().AddRange(entList);
            _unitOfWork.SaveChanges();

            var resDTOList = _mappingHelper.Map<ENT, DTO>(entList);
            return resDTOList;
        }
        public virtual void Update(List<DTO> dtoList)
        {
            CheckPresetAndParams(dtoList, @"CRUDRepositoryBase.Update({nameof(dtoList)}", dtoList);
            var entList = _mappingHelper.Map<DTO, ENT>(dtoList);
            _unitOfWork.GetRepository<ENT>().UpdateRange(entList);
            _unitOfWork.SaveChanges();
        }
        public virtual void Delete(List<Guid> idList)
        {
            CheckPresetAndParams(idList, @"CRUDRepositoryBase.Create({nameof(newDTOList)}", idList);
            var entList = _unitOfWork.GetRepository<ENT>().FindBy(x => idList.Contains(x.Id)).ToList();
            _unitOfWork.GetRepository<ENT>().DeleteRange(entList);
            _unitOfWork.SaveChanges();
        }
    }
}
