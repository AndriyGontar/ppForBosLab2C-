using System;
using System.Threading;


namespace lab2
{
    internal class ThreadSum
    {
        private int[] array;
        private MyThread[] threads;
        private bool[] isFree;

        public ThreadSum(int lenArray, int colThreads)
        {
            array = new int[lenArray];
            Array.Fill(array, 1);
            isFree = new bool[colThreads];
            Array.Fill(isFree, true);
            threads = new MyThread[colThreads];
            for (int i = 0; i < colThreads; i++)
            {
                threads[i] = new MyThread(this, i);
            }
        }
        public void changeBool(int id)
        {
            isFree[id] = true;
        }

        public void add(int i)
        {
            if (i != array.Length - i - 1)
            {
                array[i] += array[array.Length - i - 1];
            }
        }

        public void wave()
        {
            int stop = array.Length % 2 == 1 ? array.Length / 2 + 1 : array.Length / 2;
            sum(stop);
            int[] newArr = new int[stop];
            Array.Copy(array, newArr, stop);
            array = newArr;
            if (array.Length > 1)
            {
                wave();
            }
            foreach (var i in threads)
            {
                i.isStopThread = true;
            }
        }

        private void sum(int stop)
        {
            int i = 0;
            bool isDoSum = true;
            while (isDoSum)
            {
                for (int j = 0; j < threads.Length; j++)
                {
                    if (!threads[j].isToDo)
                    {
                        threads[j].i = i;
                        threads[j].isToDo = true;
                        i++;
                        if (i == stop)
                        {
                            isDoSum = false;
                            break;
                        }
                    }
                }
            }
            bool isAllStoped = true;
            while (isAllStoped)
            {
                isAllStoped = threads[0].isToDo;
                for (int j = 0; j < threads.Length; j++)
                {
                    isAllStoped = isAllStoped || threads[j].isToDo;
                }
            }

        }

        public int[] getArray()
        {
            return array;
        }
    }
}
