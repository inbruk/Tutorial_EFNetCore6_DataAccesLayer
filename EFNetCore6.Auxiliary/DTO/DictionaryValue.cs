namespace EFNetCore6.Auxiliary.DTO
{
    public class DictionaryValue : DTOBase
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public Guid DictionaryId { get; set; }
        public string Description { get; set; }
    }
}
