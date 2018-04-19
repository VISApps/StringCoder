using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCoder
{
    class Shannon_Fano_Encoder
    {
        public String message { get; set; }
        public List<Code> codes { get; set; }

        public Shannon_Fano_Encoder(String toencode) {
            Console.WriteLine("Кодировка:");
            Dictionary<char, int> values = new Dictionary<char, int>();
            foreach (char ch in toencode)
            {
                if (!values.ContainsKey(ch))
                {
                    values.Add(ch, 0);
                }
                values[ch]++;
            }
            codes = new List<Code>();
            foreach (KeyValuePair<char, int> symbol in values)
            {
                Console.WriteLine();
                Console.Write(symbol.Key + " -> ");
                List<Char> encoded = Encode(values, symbol.Key);
                String cod = "";
                foreach (Char enc in encoded)
                {
                    Console.Write(enc);
                    cod = cod + enc;
                }
                Code code = new Code() { Symbol = symbol.Key, code = cod };
                codes.Add(code);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сообщение:");
            Console.WriteLine();
            message = "";
            foreach (char ch in toencode)
            {
                List<Char> encoded = Encode(values, ch);
                foreach (Char enc in encoded)
                {
                    Console.Write(enc);
                    message = message + enc;
                }
                //Console.Write(" ");
            }
            Console.WriteLine();
        }



        private List<Char> Encode(Dictionary<char, int> values, char Symbol)
        {
            List<ShannonFanoNode> nodes = new List<ShannonFanoNode>();
            foreach (KeyValuePair<char, int> symbol in values)
            {
                nodes.Add(new ShannonFanoNode() { Symbol = symbol.Key, Frequency = symbol.Value, Code = new List<Char>() });
            }
            // Цикл выполняется пока не останется один узел
            while (nodes.Count > 1)
            {
                // Сортируем узлы по весу
                nodes = nodes.OrderByDescending(node => node.Frequency).ToList<ShannonFanoNode>();
                List<ShannonFanoNode> firstpart = new List<ShannonFanoNode>();
                List<ShannonFanoNode> secondpart = new List<ShannonFanoNode>();
                // Вычисляем середину списка узлов
                int halffrequency = (int)calculatefrequency(nodes) / 2;
                // Делим список узлов на 2 части
                int position = 0;
                while (calculatefrequency(firstpart) < halffrequency)
                {
                    firstpart.Add(nodes[position]);
                    position++;
                }
                for (int i = position; i < nodes.Count; i++)
                {
                    secondpart.Add(nodes[i]);
                }
                // Добавляем для верхней части в код 0
                foreach (ShannonFanoNode node in firstpart)
                {
                    node.Code.Add('0');
                }
                // Добавляем для верхней части в код 1
                foreach (ShannonFanoNode node in secondpart)
                {
                    node.Code.Add('1');
                }
                if (containssymbol(firstpart, Symbol))
                {
                    // Если нужный сисмвол в верхней части, заменяем список узлов на верхнюю часть
                    nodes = firstpart;
                }
                else
                {
                    // Если нужный сисмвол в нижней части, заменяем список узлов на нижнюю часть
                    nodes = secondpart;
                }
            }
            return nodes[0].Code;
        }


        private int calculatefrequency(List<ShannonFanoNode> nodes) {
            int result = 0;
            foreach (ShannonFanoNode node in nodes) {
                result = result + node.Frequency;
            }
            return result;
        }

        private bool containssymbol(List<ShannonFanoNode> nodes, char Symbol) {
            foreach (ShannonFanoNode node in nodes)
            {
                if (node.Symbol == Symbol) {
                    return true;
                }
            }
            return false;
        }
    }
}
