using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EFNetCore6.Auxiliary.BL;
using EFNetCore6.Auxiliary.DTO;
using EFNetCore6.Auxiliary.DAL;
using EFNetCore6.Auxiliary.Helpers;

using ENT = EFNetCore6.DL.Entity;

namespace EFNetCore6.BL
{
    public class DictionaryService : DictionaryService<ENT.Dictionary, ENT.DictionaryValue>, IDictionaryServiceBase<ENT.Dictionary, ENT.DictionaryValue>
    {
    }
}
