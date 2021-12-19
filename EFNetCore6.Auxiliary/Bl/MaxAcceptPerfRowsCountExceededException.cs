namespace EFNetCore6.Auxiliary.BL
{
    [Serializable]
    public class MaxAcceptPerfRowsCountExceededException : Exception
    {
        public MaxAcceptPerfRowsCountExceededException(int realCount, int maxCount)
            : base(@"Превышено максимальное количество строк, обрабатываемых за 1 запрос. {realCount}>{maxCount}")
        {
        }
    }
}
