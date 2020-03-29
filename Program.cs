using System;
using System.Collections.Generic;

namespace CoWorkers
{

    class Program
    {

        static void Main()
        {
            List<IWorker> workers = new List<IWorker> {new UpDownCounterWorker(7),
                                                       new MultiplyWorker { Multiplier =10 },
                                                       new PowerWorker{Number=3,Exponent=4}
                                                       };
            using var cr = new UnitOfWorkCollection(workers).GetEnumerator();
            while (cr.MoveNext())
            {
                Console.Write(cr.Current.ToString() + ", ");
            }
            Console.Write("Finished");
            Console.ReadLine();
        }


    }
}
