using System.Collections;

namespace CoWorkers
{
    public interface IWorker
    {
        IEnumerator GetEnumerator();
        void Reset();
        bool Step();
    }
}
