using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class SourceNotFoundException : Exception     // пользовательский класс эксепшенов, используется только для текстового месседжа
    {
        public SourceNotFoundException(string message)
            : base(message)
        { }
    }

}
