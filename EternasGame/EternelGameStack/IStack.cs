using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternelGameStack
{
    public interface IStack
    {
        void Push(MyBead mybead);

        object Pop();

        object Peek();

        Boolean IsEmpty();

        (int, int) Counter(MyBead bead, int rnd, int top, object[,] Stacks); //Function that returns more than one value

    }
}
