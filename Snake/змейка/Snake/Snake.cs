using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;

namespace Lec6G2
{
    public class Snake:GameObject
    {
        public int Dx { get; set; }
        public int Dy { get; set; }

        private Food food;
        private Wall wall;


        System.Timers.Timer timer = new System.Timers.Timer(100);
        public void tm(System.Timers.Timer timer)
        {
            this.timer = timer;
        }
        public void SetFood(Food food)
        {
            this.food = food;
        }
        
        public void SetWall(Wall wall)
        {
            this.wall = wall;
        }
        public Snake()
        {

        }
        public Snake(Food food, Wall wall)
        {
            this.food = food;
            this.wall = wall;
            body.Add(new Point { X = 12, Y = 12 });
            sign = 'o';
        }

        public void Move(object sender, ElapsedEventArgs e)
        {
            Clear();

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i] = new Point { X = body[i - 1].X, Y = body[i - 1].Y };
            }

            body[0].X += Dx;
            body[0].Y += Dy;
            Draw();
            if (this.CollisionWithWall(wall) || this.Collision())
            {
                timer.Stop();
                Console.Clear();
                Console.SetCursorPosition(17, 16);
                Console.WriteLine("Game Over");
            }

            if (food.body[0].Equals(body[0]))
            {
                body.Add(body[0]);
                food = new Food();
               food.Draw(); 
            }
           
        }
           

        public void Save()
        {
            using (FileStream fs = new FileStream("snake.xml", FileMode.Create, FileAccess.Write))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Snake));
                xs.Serialize(fs, this);
            }
        }

        public Snake Load()
        {
            Snake res;
            using (FileStream fs = new FileStream("snake.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Snake));
                res = xs.Deserialize(fs) as Snake;
            }
            return res;
        }

        public bool CollisionWithWall(Wall w)
        {
            foreach (Point p in w.body)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                    return true;
            }
            return false;
        }

        public bool Collision()
        {
                for (int i = 3; i < body.Count; i++)
                {
                    if (body[0].x == body[i].x && body[0].y == body[i].y)
                        return true;
                }
            return false;
        }
    }
}
