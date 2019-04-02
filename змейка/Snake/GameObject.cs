using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec6G2
{
    public class GameObject
    {
        public List<Point> body = new List<Point>();
        public char sign;

        public void Clear()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
             }
        }
        public void Draw()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
                
            }
        }
    }
}
