using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCoder
{
    class Node //Класс, описывающий узел дерева
    {
        public char Symbol { get; set; } //Символ
        public int Frequency { get; set; }  //Количество вхождений символа
        public Node Top { get; set; } //Дочерний узел сверху
        public Node Bottom { get; set; } //Дочерний узел снизу

        public List<Char> FindPath(char symbol,List<Char> data) //Построение пути до узла с требуемым символом
        {
            if (Bottom == null && Top == null)
            {
                if (symbol.Equals(this.Symbol))
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<Char> bottom = null;
                List<Char> top = null;
 
                if (Bottom != null)
                {
                    List<Char> bottomPath = new List<Char>();
                    bottomPath.AddRange(data);
                    bottomPath.Add('1');
 
                    bottom = Bottom.FindPath(symbol, bottomPath);
                }
 
                if (Top != null)
                {
                    List<Char> rightPath = new List<Char>();
                    rightPath.AddRange(data);
                    rightPath.Add('0');
                    top = Top.FindPath(symbol, rightPath);
                }
 
                if (bottom != null)
                {
                    return bottom;
                }
                else
                {
                    return top;
                }
            }
        }
    }
}
