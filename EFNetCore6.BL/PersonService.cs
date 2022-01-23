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
        public PersonService()
        {
            IMappingHelper mappingHelper = LazyBuilderAndHolder<IMappingHelper, MappingHelper, MappingHelperFactory>.getInstance();
            IUnitOfWork unitOfWork = LazyBuilderAndHolder<IUnitOfWork, MyUnitOfWork, MyUnitOfWorkFactory>.getInstance();
            Configure(mappingHelper, unitOfWork, maxFetchedRows);
        }
    }
}
