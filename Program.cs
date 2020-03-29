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

            foreach (var worker in new UnitOfWorkCollection(workers))
                {
                    Console.Write(worker.ToString() + ", ");
                }

            Console.Write("Finished");
            Console.ReadLine();
        }      
    }
}
