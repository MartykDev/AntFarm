using System;
using System.Collections.Generic;
using System.Text;

namespace AntFarm
{
    public class Farm
    {
        private Coordinates _coordinates;
        private List<Ant> _ants;

        //private State s; //

        public Farm(Coordinates coordinates)
        {
            _coordinates = coordinates;
            _ants = new List<Ant>();
        }

        //public void SetMemento(Memento m)
        //{
        //    s = m.S;

        //    lst = null;
        //    lst = new List<Ant>();

        //    for (int i = 0; i < s.Amount; i++)
        //        lst.Add(new Ant(s.c[i], s.jobs[i]));
        //} //

        //public Memento CreateMemento()
        //{
        //    s.Amount = lst.Count;

        //    for (int i = 0; i < lst.Count; i++)
        //        s.c.Add(lst[i].Cor);

        //    for (int i = 0; i < lst.Count; i++)
        //        s.jobs.Add(lst[i].Job);

        //    return new Memento(s);
        //} // 

        public void GrowWorker()
        {
            _ants.Add(new AntWorker(new Coordinates()));
        }

        public void GrowSoldier()
        {
            _ants.Add(new AntSoldier(new Coordinates()));
        }

        public void MoveAll()
        {
            _ants.ForEach(x => x.Move());
        }

        public void ToBaseAll()
        {
            _ants.ForEach(x => x.Move());
        }

        public void DoWorkAll()
        {
            //for (int i = 0; i < lst.Count; i++)
            //{
            //    if (lst[i].Job == "worker")
            //        lst[i].DoWork();
            //}
        }

        public void DrowFarm()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(_coordinates.X, _coordinates.Y);
            Console.Write(" ");
            Console.ResetColor();
        }

        public void DrowAnts()
        {
            foreach (var ant in _ants)
            {
                //Console.ResetColor();
                //Console.SetCursorPosition(ant.PrewCoordinates.X, ant.PrewCoordinates.Y);
                //Console.Write(" ");

                Console.BackgroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(ant.Coordinates.X, ant.Coordinates.Y);
                Console.Write(" ");
                Console.ResetColor();
            }
        }
    }
}
