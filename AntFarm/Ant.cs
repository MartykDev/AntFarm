using System;

namespace AntFarm
{
    public interface IAnt
    {
        void Move();

        void RunToBase();

        void DoWork();
    }

    public enum AntType
    {
        Worker,
        Soldier
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates()
        {
            var random = new Random();
            X = random.Next(0, Console.WindowWidth - 5);
            Y = random.Next(0, Console.WindowHeight - 5);
        }
    }

    public abstract class Ant : IAnt
    {
        protected Random _random;
        public AntType AntType { get; protected set; }
        public Coordinates Coordinates { get; protected set; }
        public Coordinates PrewCoordinates { get; protected set; }


        public Ant(AntType antType, Coordinates coordinates)
        {
            AntType = antType;
            Coordinates = coordinates;
            PrewCoordinates = Coordinates;
            _random = new Random();
        }

        public virtual void Move()
        {
            var direction = (Direction)_random.Next(0, 4);
            int steps = _random.Next(1, 10);

            PrewCoordinates.X = Coordinates.X;
            PrewCoordinates.Y = Coordinates.Y;

            //for (int i = 0; i < steps; i++)
            //{
                switch (direction)
                {
                    case Direction.Up:
                        _ = Coordinates.Y - 1 >= 1 ? Coordinates.Y -= 1 : Coordinates.Y += 1;
                        break;
                    case Direction.Down:
                        _ = Coordinates.Y + 1 <= Console.WindowHeight - 1 ? Coordinates.Y += 1 : Coordinates.Y -= 1;
                        break;
                    case Direction.Left:
                        _ = Coordinates.X - 1 >= 1 ? Coordinates.X -= 1 : Coordinates.X += 1;
                        break;
                    case Direction.Right:
                        _ = Coordinates.X + 1 <= Console.WindowWidth - 1 ? Coordinates.X += 1 : Coordinates.X -= 1;
                        break;
                    default:
                        break;
                }
            //}
        }

        public virtual void RunToBase()
        {
            throw new NotImplementedException();
        }

        public virtual void DoWork()
        {
            throw new NotImplementedException();
        }
    }

    public class AntWorker : Ant
    {
        public AntWorker(Coordinates coordinates) : base(AntType.Worker, coordinates)
        {

        }

        public override void DoWork()
        {
            Coordinates.X = _random.Next(100);
            Coordinates.Y = _random.Next(100);

            if (_random.Next(100) < 5)
            {
                Console.WriteLine("found food");
                RunToBase();
            }
        }

        public override void RunToBase()
        {
            Coordinates.X = 5;
            Coordinates.Y = 5;
        }
    }

    class AntSoldier : Ant
    {
        public AntSoldier(Coordinates coordinates) : base(AntType.Soldier, coordinates)
        {

        }

        public override void RunToBase()
        {
            Coordinates.X = 5;
            Coordinates.Y = 5;

            Coordinates.Y += (int)Direction.Up;
            for (int i = 0; i < 2; i++)
            {
                Coordinates.X += (int)Direction.Right;
                Coordinates.Y += (int)Direction.Down;
                Coordinates.Y += (int)Direction.Down;
                Coordinates.X += (int)Direction.Left;
                Coordinates.X += (int)Direction.Left;
                Coordinates.Y += (int)Direction.Up;
                Coordinates.Y += (int)Direction.Up;
                Coordinates.X += (int)Direction.Right;
            }
        }
    }
}