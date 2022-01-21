using EFNetCore6.Auxiliary.DTO;
using EFNetCore6.Auxiliary.DAL;
using EFNetCore6.Auxiliary.Helpers;

namespace EFNetCore6.Auxiliary.BL
{
    public interface IDictionaryServiceBase<DE, DVE>
        where DE : Dictionary
        where DVE : DictionaryValue
    {
        void Configure(IMappingHelper mh, IUnitOfWork uw, int maxRows);
        DTO.Dictionary? ReadDicById(Guid dicId);
        DTO.Dictionary? ReadDicById(int enumId);
        List<DTO.DictionaryValue> ReadValuesByDicId(Guid dicId);
        List<DTO.DictionaryValue>? ReadValuesByDicEnumId(int enumId);
        DTO.DictionaryValue? ReadValueByDicIdAndEnumId(Guid dicId, Guid dicValId);
        DTO.DictionaryValue ReadValueByDicIdAndEnumId(int dicId, int enumId);
    }
}