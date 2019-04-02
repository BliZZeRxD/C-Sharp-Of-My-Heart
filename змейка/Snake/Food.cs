using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec6G2
{
    public class Food : GameObject
    {
        public bool res = true;
        Wall wall = new Wall();
        Point p = new Point();

        bool isOK = false;
        public Food()
        {
            sign = '@';
            body.Clear();
            while (!isOK)
            {
                res = true;
                Random rnd = new Random();
                Point x = new Point { X = rnd.Next(0, 49), Y = rnd.Next(0, 49) };
                foreach (Point p in wall.body)
                {
                    if (p.Equals(x))
                    {
                        res = false;
                        break;
                    }
                }

                if (res == true)
                {
                    body.Add(x);
                    isOK = true;
                }
            }
        }
    }
}
