using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            var enumerators = workers.Select(w => w.GetEnumerator());
            bool isActive;
            do
            {
                isActive = false;
                foreach (var enumerator in enumerators)
                {
                    if (enumerator.MoveNext())
                    {
                        isActive = true;
                        yield return (IWorker)enumerator.Current;
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
