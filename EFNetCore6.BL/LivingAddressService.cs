﻿using EFNetCore6.Auxiliary.DI;
using EFNetCore6.Auxiliary.BL;
using EFNetCore6.Auxiliary.Helpers;
using EFNetCore6.Auxiliary.DAL;

using EFNetCore6.DAL;
using EFNetCore6.BL.DI;

using ABL = EFNetCore6.Auxiliary.BL;
using ENT = EFNetCore6.DL.Entity;

namespace EFNetCore6.BL
{
    public class LivingAddressService : CRUDRepositoryBase<DTO.LivingAddress, ENT.LivingAddress>, ICRUDRepository<DTO.LivingAddress>
    {
        protected const int maxFetchedRows = 1000;
        public LivingAddressService()
        {
            IMappingHelper mappingHelper = LazyBuilderAndHolder<IMappingHelper, MappingHelper, MappingHelperFactory>.getInstance();
            IUnitOfWork unitOfWork = LazyBuilderAndHolder<IUnitOfWork, MyUnitOfWork, MyUnitOfWorkFactory>.getInstance();
            Configure(mappingHelper, unitOfWork, maxFetchedRows);
        }
    }
}
