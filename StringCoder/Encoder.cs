using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCoder
{
    class Encoder
    {
        public String message { get; set; }
        public List<Code> codes { get; set; }

        public Encoder(String toencode) {
            //Составляем список символов из входной строки и находим количество вхождений каждого символа
            Dictionary<char, int> values = new Dictionary<char, int>();
            foreach (char ch in toencode)
            {
                if(!values.ContainsKey(ch)){
                    values.Add(ch, 0 );
                }
                values[ch]++;
            }
            // Создаем список узлов
            List<Node> nodes = new List<Node>();
            // Добавляем узлы с указанием их "веса"
            foreach (KeyValuePair<char, int> symbol in values)
            {
                nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
            }
            // Цикл выполняется пока не останется один узел - вершина дерева
            while (nodes.Count > 1)
            {
                // Сортируем узлы по весу
                List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();
                if (orderedNodes.Count >= 2)
                {
                    // Если остались два узла, то создаем их родителя, который имеет вес равный сумме дочерних вершин
                    List<Node> taken = orderedNodes.Take(2).ToList<Node>();
                    Node parent = new Node()
                    {
                        Symbol = '*',
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        Bottom = taken[0],
                        Top = taken[1]
                    };
                    // Удаляем дочерние узлы из списка и добавляем вместо них родителя
                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }
               
            }
            Node Root = nodes.FirstOrDefault();
            Console.WriteLine("Кодировка:");
            // Для каждого символа печатаем кодировку
            codes = new List<Code>();
            foreach (KeyValuePair<char, int> symbol in values)
            {
                Console.WriteLine();
                Console.Write(symbol.Key + " -> ");
                List<Char> encoded = Root.FindPath(symbol.Key, new List<Char>());
                String cod = "";
                foreach (Char enc in encoded) {
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
            // Кодируем каждый символ и печатаем полное сообщение
            message = "";
            foreach (char ch in toencode) { 
                List<Char> encoded = Root.FindPath(ch, new List<Char>());
                foreach (Char enc in encoded)
                {
                    Console.Write(enc);
                    message = message + enc;
                }
            }
            Console.WriteLine();
        }
    }
}
