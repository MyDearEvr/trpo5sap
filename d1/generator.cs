using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d1
{
    class generator
    {
        public int[,] field;

        public void set(int n)
        {
            field = new int[n, n];
        }

        public bool slomali(int i, int j)
        {
            bool res = true;


            if (field[i, j] == -1)
            {

                int minx = i - 1;
                int miny = j - 1;
                if (minx < 0) minx = 0;
                if (miny < 0) miny = 0;


                int maxx = i + 1;
                int maxy = j + 1;
                if (maxx > field.GetLength(0)-1) maxx = field.GetLength(0)-1;
                if (maxy > field.GetLength(1)-1) maxy = field.GetLength(1)-1;


                for (int i1 = minx; i1 <= maxx; i1++)
                    for (int j1 = miny; j1 <= maxy; j1++)
                    {
                        if (field[i1, j1] == 0)
                        {
                            res = false;
                            break;

                        }
                        if (res == false) break;
                    }

            }
            return res;
        }

        public void plant(int n)
        {
            Random rng = new Random();

            for (int i = 0; i < n; i++)
            {
                int x = rng.Next(field.GetLength(0));
                int y = rng.Next(field.GetLength(1));

                if (field[x, y] != 0)
                {
                    i--;
                    continue;
                }
                else
                    field[x, y] = -1;

                for (int i1 = 0; i1 < field.GetLength(0); i1++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        if (field[i1, j] == -1)
                        {
                            if (slomali(i1, j) == true)
                            {
                                field[x, y] = 0;
                                i--;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void ciferki()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 0)
                    {
                        int minx = i - 1;
                        int miny = j - 1;
                        if (minx < 0) minx = 0;
                        if (miny < 0) miny = 0;


                        int maxx = i + 1;
                        int maxy = j + 1;
                        if (maxx > field.GetLength(0) - 1) maxx = field.GetLength(0) - 1;
                        if (maxy > field.GetLength(1) - 1) maxy = field.GetLength(1) - 1;

                        int sum = 0;

                        for (int i1 = minx; i1 <= maxx; i1++)
                            for (int j1 = miny; j1 <= maxy; j1++)
                            {

                                if (field[i1, j1] == -1)
                                {
                                    sum++;

                                }
                            }
                        field[i, j] = sum;
                    }
                }
            }
        }

        public int getCell(int i, int j)
        {
            return field[i, j];
        }
    }
}
