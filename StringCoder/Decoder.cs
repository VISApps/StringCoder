using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCoder
{
    class Decoder
    {
        public Decoder(List<Code> codes, String message)
        {
            List<char> chars = new List<char>();
            foreach (char ch in message)
            {
                chars.Add(ch);
            }
            String cod = "";
            Console.WriteLine();
            Console.WriteLine("Декодированная строка:");
            Console.WriteLine();
            while (chars.Count > 0)
            {
                cod = cod + chars[0];
                chars.RemoveAt(0);
                foreach(Code code in codes)
                {
                    if(code.code == cod)
                    {
                        Console.Write(code.Symbol);
                        cod = "";
                        break;
                    }
                }
            }
            Console.WriteLine();
        }   
    }
}
