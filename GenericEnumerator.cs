using System.Collections;
using System.Collections.Generic;

namespace CoWorkers
{
    public sealed class GenericStepEnumerator<T> : IEnumerator<T> where T : IWorker
    {
        public GenericStepEnumerator(T worker) => Current = worker;

        public T Current { get; }
        T IEnumerator<T>.Current => Current;

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext() => Current.Step();

        public void Reset() => Current.Reset();
    }
}
