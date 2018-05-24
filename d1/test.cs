using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace d1
{
    [TestFixture]
    class test
    {
        [TestCase]
        public void slomali()
        {
            generator gen = new generator();

            gen.field = new int[,] {
                { -1, -1,  0,  0,  0},
                { -1, -1, -1, -1,  0},
                {  0, -1, -1, -1,  0},
                {  0, -1, -1, -1,  0},
                {  0,  0,  0,  0,  0},
            };

            Assert.AreEqual(true, gen.slomali(0, 0));
            Assert.AreEqual(true, gen.slomali(2, 2));
            Assert.AreEqual(false, gen.slomali(0, 1));

            //создание объекта, 
        }

        [TestCase]
        public void plant()
        {
            generator gen = new generator();

            gen.set(5);
            gen.plant(15);

            int sum = 0;

            for(int i = 0; i < 5; i++)
                for(int j = 0; j < 5; j++)
                {
                    if (gen.field[i, j] == -1)
                        sum++;
                }


            Assert.AreEqual(15, sum);

            bool slomano = false;

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (gen.field[i, j] == -1)
                        if (gen.slomali(i, j) == true)
                            slomano = true;
                }

            Assert.AreEqual(false, slomano);


        }

    }
}
