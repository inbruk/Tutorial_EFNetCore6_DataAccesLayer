using EFNetCore6.Auxiliary.DI;
using EFNetCore6.Auxiliary.BL;
using EFNetCore6.Auxiliary.Helpers;
using EFNetCore6.Auxiliary.DAL;

using EFNetCore6.DAL;
using EFNetCore6.BL.DI;

using ABL = EFNetCore6.Auxiliary.BL;
using ENT = EFNetCore6.DL.Entity;

namespace EFNetCore6.BL
{
    public class PersonService : CRUDRepositoryBase<DTO.Person, ENT.Person>, ICRUDRepository<DTO.Person>
    {
        protected const int maxFetchedRows = 1000;
        protected IMappingHelper _mappingHelper;
        protected IUnitOfWork _unitOfWork;
        public PersonService()
        {
            _mappingHelper = LazyBuilderAndHolder<IMappingHelper, MappingHelper, MappingHelperFactory>.getInstance();
            _unitOfWork = LazyBuilderAndHolder<IUnitOfWork, MyUnitOfWork, MyUnitOfWorkFactory>.getInstance();
            Configure(_mappingHelper, _unitOfWork, maxFetchedRows);
        }
        public List<DTO.VwPersonCarLivingAddress> Read(Guid id)
        {
            CheckPreset();
            var entList = _unitOfWork.GetRepository<ENT.VwPersonCarLivingAddress>().FindBy(  ).ToList();
            var dtoList = _mappingHelper.Map<ENT.VwPersonCarLivingAddress, DTO.VwPersonCarLivingAddress>(entList);
            return dtoList;
        }
    }
}
