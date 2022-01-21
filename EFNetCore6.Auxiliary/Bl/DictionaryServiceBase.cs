using EFNetCore6.Auxiliary.DTO;
using EFNetCore6.Auxiliary.DAL;
using EFNetCore6.Auxiliary.Helpers;

namespace EFNetCore6.Auxiliary.BL
{
    public class DictionaryService<DE, DVE> : IDictionaryServiceBase<DE, DVE>
        where DE : Dictionary
        where DVE : DictionaryValue
    {
        public int MaximumAcceptablePerformedRowsCount { get; protected set; }
        protected IMappingHelper? _mappingHelper = null;
        protected IUnitOfWork? _unitOfWork = null;
        public virtual void Configure(IMappingHelper mh, IUnitOfWork uw, int maxRows)
        {
            _mappingHelper = mh;
            _mappingHelper.AddMaps(new List<(Type, Type)> { (typeof(DE), typeof(Dictionary)), (typeof(DVE), typeof(DictionaryValue)) });
            _unitOfWork = uw;
            MaximumAcceptablePerformedRowsCount = maxRows;
        }
        protected virtual void CheckPreset()
        {
            if (_mappingHelper == null)
                throw new NullReferenceException("_mappingHelper");

            if (_unitOfWork == null)
                throw new NullReferenceException("_unitOfWork");
        }
        public DTO.Dictionary? ReadDicById(Guid dicId)
        {
            CheckPreset();
            var ent = _unitOfWork.GetRepository<DE>().FirstOrDefault(x => x.Id == dicId);
            if (ent == null) return null;
            DTO.Dictionary res = _mappingHelper.Map<DE, DTO.Dictionary>(ent);
            return res;
        }
        public DTO.Dictionary? ReadDicById(int enumId)
        {
            CheckPreset();
            var ent = _unitOfWork.GetRepository<DE>().FirstOrDefault(x => x.EnumId == enumId);
            if (ent == null) return null;
            DTO.Dictionary res = _mappingHelper.Map<DE, DTO.Dictionary>(ent);
            return res;
        }
        public List<DTO.DictionaryValue> ReadValuesByDicId(Guid dicId)
        {
            CheckPreset();
            var ents = _unitOfWork.GetRepository<DVE>().FindBy(x => x.DictionaryId == dicId).ToList();
            List<DTO.DictionaryValue> result = _mappingHelper.Map<DVE, DTO.DictionaryValue>(ents);
            return result;
        }
        public List<DTO.DictionaryValue>? ReadValuesByDicEnumId(int enumId)
        {
            DTO.Dictionary? currDic = ReadDicById(enumId);
            if (currDic == null) return null;
            List<DTO.DictionaryValue> result = ReadValuesByDicId(currDic.Id);
            return result;
        }
        public DTO.DictionaryValue? ReadValueByDicIdAndEnumId(Guid dicId, Guid dicValId)
        {
            CheckPreset();
            var result = _unitOfWork.GetRepository<DVE>().FirstOrDefault(x => x.Id == dicId && x.DictionaryId == dicValId);
            return result;
        }
        public DTO.DictionaryValue ReadValueByDicIdAndEnumId(int dicId, int enumId)
        {
            DTO.Dictionary? currDic = ReadDicById(dicId);
            var result = _unitOfWork.GetRepository<DVE>().FirstOrDefault(x => x.Id == currDic.Id && x.EnumId == enumId);
            return result;
        }
    }
}
