using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class DataException : Exception     // пользовательский класс эксепшенов, используется только для текстового месседжа
    {
        public DataException(string message)
            : base(message)
        { }
    }
}
