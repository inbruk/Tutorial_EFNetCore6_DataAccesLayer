using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Auxiliary.Helpers
{
    [Serializable]
    public class NotExistedConfigurationItemException : Exception
    {
        public NotExistedConfigurationItemException() { }

        public NotExistedConfigurationItemException(string section, string item)
            : base(String.Format("Configuration item {0}:{1} not existed", section, item))
        {
        }
    }
}
