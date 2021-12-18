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
            // mapperCfgExp.AllowNullCollections = true;
            foreach (var item in listOfMaps)
            {
                mapperCfgExp.AddMaps(item.Item1, item.Item2);
                mapperCfgExp.AddMaps(item.Item2, item.Item1);
            }

            var mapperConfig = new MapperConfiguration(mapperCfgExp);
            _mapper = new Mapper(mapperConfig);
        }

        protected virtual void CheckPresetAndParams(object? src)
        {
            if (_mapper == null)
                throw new NullReferenceException("Mapper has not yet been constructed !");

            if (src == null)
                throw new ArgumentNullException(nameof(src));
        }

        public virtual DSTT Map<SRCT,DSTT>(SRCT src)
        {
            CheckPresetAndParams(src);
            var result = _mapper.Map<SRCT, DSTT>(src);
            return result;
        }

        public virtual List<DSTT> Map<SRCT, DSTT>(List<SRCT> src)
        {
            CheckPresetAndParams(src);
            var result = _mapper.Map<List<SRCT>, List<DSTT> >(src);
            return result;
        }
    }
}
