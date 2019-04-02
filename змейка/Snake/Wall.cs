using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec6G2
{
    public class Wall:GameObject
    {
        public Wall()
        {
            sign = '#';
            GenerateLevel(1);
        }

        void GenerateLevel(int level)
        {
            string path = string.Format("Level{0}.txt", level);
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    for (int i = 0; i < 44; ++i)
                    {
                        string line = sr.ReadLine();
                        for (int j = 0; j < 44; ++j)
                        {
                            if (line[j] == '#')
                            {
                                body.Add(new Point { X = j, Y = i });
                            }
                        }
                    }
                }
            }
        }
    }
}
