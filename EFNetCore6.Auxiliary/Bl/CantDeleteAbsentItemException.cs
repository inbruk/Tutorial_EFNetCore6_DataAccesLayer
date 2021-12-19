namespace EFNetCore6.Auxiliary.BL
{
    [Serializable]
    public class CantDeleteAbsentItemException : Exception
    {
        public CantDeleteAbsentItemException(Guid id)
            : base(@"Невозможно удалить отсутствующую запись с Id={id}!")
        {
        }
    }
}
