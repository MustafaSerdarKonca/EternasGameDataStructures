using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternelGameStack
{
    public class MyBead
    {
        public object Color { get; set; }

        public int selectRandomStick()
        {
            System.Threading.Thread.Sleep(10);
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int random = rnd.Next(0, 8);

            for (int i = 0; i < 8; i++)
            {
                while (StackSpecifictoEternas.fullSticks[i] == random.ToString()) //Chose the full bar, it select the new bar and controls it as well.
                {
                    random = rnd.Next(0, 8);
                    i = 0;
                }
            }

            return random;
        }
    }
}
