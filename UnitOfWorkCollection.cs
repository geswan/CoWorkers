using System.Collections;
using System.Collections.Generic;

namespace CoWorkers
{
    public class UnitOfWorkCollection : IEnumerable<IWorker>
    {
        readonly IEnumerable<IWorker> workers;
        public UnitOfWorkCollection(IEnumerable<IWorker> workers)
        {
            this.workers = workers;
        }
        private IEnumerable<IWorker> UnitOfWorkEnumerator(IEnumerable<IWorker> workers)
        {
           
            bool isActive;
            do
            {
                isActive = false;
                foreach (IWorker worker in workers)
                {
                    if (worker.Step())
                    {
                        isActive = true;
                        yield return worker;
                    }
                }

            }
            while (isActive == true);
        }

        public IEnumerator<IWorker> GetEnumerator()
        {
            return UnitOfWorkEnumerator(workers).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return UnitOfWorkEnumerator(workers).GetEnumerator();
        }
    }
}
