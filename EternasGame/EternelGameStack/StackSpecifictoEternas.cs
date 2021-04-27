using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternelGameStack
{
    public class StackSpecifictoEternas : IStack
    {
        private object[] items;

        private int top = -1;

        public int allCount = 0;

        public object[,] Sticks; // We have eight sticks each rod can take 4 beads

        public static string[] fullSticks; //So that we can understand the bars that are full

        private int pushCounter = 0;
        public StackSpecifictoEternas()
        {

            Sticks = new object[8, 4];
            fullSticks = new string[8];

        }
        
        public object Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Error: Stack is empty ...(Downflow)");
            }
            Object temp = items[top--];
            return temp;
        }

        public object Peek()
        {
            return items[top];
        }

        public void Push(MyBead mybead)
        {
            int random = mybead.selectRandomStick();

            top = Counter(mybead, random, top, Sticks).Item1;    //Return values top and random. Throws one to the Item1 and one to the Item2.
            random = Counter(mybead, random, top, Sticks).Item2;

            if (top != 3)
            {
                if (IsEmpty())
                {
                    Sticks[random, ++top] = "W";
                }
                else
                {
                    Sticks[random, ++top] = mybead.Color;

                    if (top == 3)
                    {
                        fullSticks[pushCounter] = random.ToString();
                        pushCounter++;
                    }
                }

                allCount++;
                top = -1;

            }
        }

        public Boolean IsEmpty()
        {

            return (allCount == 0);

        }

        public (int, int) Counter(MyBead bead, int rnd, int top, object[,] Stacks) //To turn the apple and banana
        {

            while (Stacks[rnd, top + 1] != null)
            {
                top++;

                if (top == 3)
                {
                    top = -1;

                    rnd = bead.selectRandomStick();

                    break;
                }
            }

            return (top, rnd);

        }
    }
}
