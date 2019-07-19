using System;
using System.Collections.Generic;
using System.Text;

namespace JmeterResultsCsvParser.Guards
{
    public interface IGuard
    {
        bool Check();
    }
}
