namespace EFNetCore6.Auxiliary.DTO
{
    public class DictionaryValue : DTOBase
    {
        public int EnumId { get; set; }
        public string Name { get; set; }
        public Guid DictionaryId { get; set; }
        public string Description { get; set; }
    }
}
