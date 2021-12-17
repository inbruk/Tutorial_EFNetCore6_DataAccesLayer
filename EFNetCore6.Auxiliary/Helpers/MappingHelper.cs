using System;
using System.Collections.Generic;

using AutoMapper;
using AutoMapper.Configuration;

namespace EFNetCore6.Auxiliary.Helpers
{
    public class MappingHelper : IMappingHelper
    {
        protected Mapper? _mapper = null;

        public virtual void SetMaps(List<Tuple<Type, Type>> listOfMaps)
        {
            var mapperCfgExp = new MapperConfigurationExpression();
            foreach(var item in listOfMaps)
                mapperCfgExp.AddMaps(item.Item1, item.Item2);

            var mapperConfig = new MapperConfiguration(mapperCfgExp);
            _mapper = new Mapper(mapperConfig);
        }
        public virtual DSTT Map<SRCT,DSTT>(SRCT src)
        {
            if (_mapper==null)
                throw new NullReferenceException("Mapper has not yet been constructed !");

            if (src==null)
                throw new ArgumentNullException(nameof(src));

            var result = _mapper.Map<SRCT, DSTT>(src);
            return result;
        }
    }
}
