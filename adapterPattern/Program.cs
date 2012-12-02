using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adapterPattern
{
    public interface Duck
    {
        void quack();
        void fly();
    }

    public interface Turkey
    {
        void gobble();
        void fly();
    }

    public class MallardDuck : Duck
    {
        public void quack()
        {
            Console.WriteLine("QUACK!");
        }
        public void fly()
        {
            Console.WriteLine("FLY!");
        }
    }

    public class WildTurkey : Turkey
    {
        public void gobble()
        {
            Console.WriteLine("Gobble gobble!");
        }
        public void fly()
        {
            Console.WriteLine("FLY BAD!");
        }
    }

    public class TurkeyAdapter : Duck
    {
        Turkey mTurkey;

        public TurkeyAdapter(Turkey pTurkey)
        {
            this.mTurkey = pTurkey;
        }

        public void quack()
        {
            mTurkey.gobble();
        }
        public void fly()
        {
            for (int i = 0; i < 5; i++)
            {
                mTurkey.fly();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MallardDuck myDuck = new MallardDuck();
            WildTurkey myTurkey = new WildTurkey();

            Duck TurkeyAdapter = new TurkeyAdapter(myTurkey);

            myTurkey.gobble();
            myTurkey.fly();
            myDuck.quack();
            myDuck.fly();

            testduck(TurkeyAdapter);
            Console.ReadLine();
        }

        static void testduck(Duck pduck)
        {
            pduck.quack();
            pduck.fly();
        }
    }
}
