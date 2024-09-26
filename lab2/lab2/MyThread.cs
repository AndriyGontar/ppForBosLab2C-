
using System;
using System.Threading;
using System.Threading.Tasks;

namespace lab2
{
    internal class MyThread
    {
        private ThreadSum threadSum;
        private int id;
        public Task task;
        public int i;
        public bool isToDo;
        public bool isStopThread;
        public MyThread(ThreadSum threadSum, int id)
        {
            this.threadSum = threadSum;
            this.id = id;
            isToDo = false;
            task = new Task(run);
            task.Start();
        }


        public void run()
        {
            while (!isStopThread)
            {
                if (isToDo)
                {
                    threadSum.add(i);
                    isToDo = false;

                }
            }
        }
    }
}
