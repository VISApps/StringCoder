using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCoder
{
    class ShannonFanoNode
    {
        public Char Symbol { get; set; }
        public int Frequency { get; set; }
        public List<Char> Code { get; set; }

    }
}
