using System;
using System.Threading;

namespace AntFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Farm farm = new Farm(new Coordinates());


            //Set the frame rate
            var fps = 90;
            //Get the start time
            var start = DateTime.Now;
            //Set the frame duration in milliseconds
            var frameDuration = 1000 / fps;
            //Initialize the lag offset
            var lag = 0;


            farm.GrowWorker();
            farm.GrowWorker();
            farm.GrowWorker();
            farm.GrowWorker();
            farm.GrowWorker();
            farm.GrowWorker();
            farm.GrowWorker();


            while (true)
            {
                var current = DateTime.Now;
                var elapsed = current - start;
                start = current;
                lag += elapsed.Milliseconds;

                while (lag >= frameDuration)
                {
                    farm.MoveAll();
                    lag -= frameDuration;
                }

                var lagOffset = lag / frameDuration;
                farm.DrowFarm();
                farm.DrowAnts();
                //Thread.Sleep(200);
                Console.Clear();
            }
        }
    }
}
