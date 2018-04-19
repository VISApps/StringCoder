using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.WriteLine();
                Console.WriteLine("Введите строку");
                String encode = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("1 - кодировать с помощью алгоритма Хаффмана, 2 -  кодировать с помощью алгоритма Шеннона-Фано");
                    Console.WriteLine();
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.D1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Кодируем строку с помощью алгоритма Хаффмана");
                        Console.WriteLine();
                        Encoder encoder = new Encoder(encode);
                        Decoder decoder = new Decoder(encoder.codes, encoder.message);
                        break;
                    }
                    else if (keyInfo.Key == ConsoleKey.D2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Кодируем строку с помощью алгоритма Шеннона-Фано");
                        Console.WriteLine();
                        Shannon_Fano_Encoder encoder = new Shannon_Fano_Encoder(encode);
                        Decoder decoder = new Decoder(encoder.codes, encoder.message);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Выбрите один из вариантов!");
                    }
                } 
            }
        }
    }
}
