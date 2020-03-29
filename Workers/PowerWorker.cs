using System.Collections;

namespace CoWorkers
{
    public class PowerWorker : IWorker
    {
        private bool isActive = true;
        public int Number { get; set; } = 0;
        public int Exponent { get; set; } = 0;
        private int result = 1;
        int iteration = 0;
        public bool Step()
        {
            if (!isActive) return false;
            result *= Number;
            iteration += 1;
            isActive = iteration == Exponent ? false : isActive;
            return true;
        }
        public override string ToString() => result.ToString();

        public IEnumerator GetEnumerator() => new GenericStepEnumerator<PowerWorker>(this);
        public void Reset()
        {
            isActive = true;
            result = 1;
            iteration = 0;

        }
    }
}
