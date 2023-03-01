
using System;
using System.Threading;

namespace Race
{
    public abstract class RaceAnimal
    {
        private char[] track = new char[70];
        private char symbol;
        public int position;
        private string name;

        public RaceAnimal(string name, char symbol)
        {
            this.name = name;
            this.symbol = symbol;
            for (int i = 0; i < track.Length; i++)
                track[i] = '-';
            track[0] = symbol;
        }

        public override string ToString()
        {
            string trackString = "";
            for (int i = 0; i < track.Length; i++)
                trackString += track[i];
            return trackString;
        }

        public void ChangePos(int steps)
        {
            track[position] = '-';
            if (position + steps < 0)
                position = 0;
            else if (position + steps > 69)
                position = 69;
            else
                position += steps;
            track[position] = symbol;
        }

        public abstract void Move();
    }


    public class Hare : RaceAnimal
    {
        public Hare() : base("Hare", 'H') { }

        public override void Move()
        {
            Random rand = new Random();
            int num = rand.Next(1, 11);
            if (num < 5)
                ChangePos(9);
            else if (num < 8)
                ChangePos(-4);
            else
                ChangePos(1);
        }
    }

    public class Tortoise : RaceAnimal
    {
        public Tortoise() : base("Tortoise", 'T') { }

        public override void Move()
        {
            Random rand = new Random();
            int num = rand.Next(1, 11);
            if (num < 5)
                ChangePos(9);
            else if (num < 8)
                ChangePos(-4);
            else
                ChangePos(1);
        }
    }

    public class Race
    {
        public void simulate()
        {
            Hare hare = new Hare();
            Tortoise tortoise = new Tortoise();
            while (hare.position != 69 && tortoise.position != 69)
            {
                Console.Clear();
                hare.Move();
                tortoise.Move();
                Console.WriteLine(hare.ToString());
                Console.WriteLine(tortoise.ToString());
                Thread.Sleep(100);

            }
            Console.WriteLine("*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*");
            if (hare.position == 69)
                Console.WriteLine("The Hare won the Race!");
            else
                Console.WriteLine("The Tortoise won the Race!");
            Console.WriteLine("*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*~~*");
        }

        public static void Main(string[] args)
        {

            Race r = new Race();
            r.simulate();
        }
    }

}

