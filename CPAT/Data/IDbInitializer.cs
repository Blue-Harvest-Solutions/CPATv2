using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAT.Data
{
    public interface IDbInitializer
    {
        Task Initialize();
    }
}
