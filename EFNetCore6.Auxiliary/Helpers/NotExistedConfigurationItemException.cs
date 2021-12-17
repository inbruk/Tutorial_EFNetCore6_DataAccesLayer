namespace EFNetCore6.Auxiliary.Helpers
{
    [Serializable]
    public class NotExistedConfigurationItemException : Exception
    {
        public NotExistedConfigurationItemException(string section, string item)
            : base(String.Format("Configuration item {0}:{1} not existed", section, item))
        {
        }
    }
}
