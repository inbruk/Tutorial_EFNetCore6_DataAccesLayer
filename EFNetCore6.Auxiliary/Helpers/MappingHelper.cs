using System;
using System.Collections.Generic;

using AutoMapper;
using AutoMapper.Configuration;

namespace EFNetCore6.Auxiliary.Helpers
{
    public class MappingHelper : IMappingHelper
    {
        protected Boolean _IsConfigured = false;
        protected Mapper? _mapper = null;
        protected List<(Type,Type)> _listOfMaps = new List<(Type, Type)>();

        public virtual void AddMaps(List<(Type, Type)> lm)
        {
            if (_IsConfigured==true)
                throw new Exception(@"Can't invoke AddMaps() after Configure() invoking !");

            _listOfMaps.AddRange(lm);
        }

        public virtual void Configure()
        {
            if (_IsConfigured==true)
                throw new Exception(@"Can't invoke Configure() twice !");

            var mapperCfgExp = new MapperConfigurationExpression();
            // mapperCfgExp.AllowNullCollections = true;
            foreach (var item in _listOfMaps)
            {
                mapperCfgExp.AddMaps(item.Item1, item.Item2);
                mapperCfgExp.AddMaps(item.Item2, item.Item1);
            }

            var mapperConfig = new MapperConfiguration(mapperCfgExp);
            _mapper = new Mapper(mapperConfig);
            _IsConfigured = true;
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
