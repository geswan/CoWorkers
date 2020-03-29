using System.Collections;

namespace CoWorkers
{
    public class MultiplyWorker : IWorker
    {
        private bool isActive = true;
        public int Multiplier { get; set; } = 0;
        public int Result { get; private set; } = 1;
        Direction countDirection = Direction.Up;
        int counter = 0;
        public bool Step()
        {
            if (!isActive) return false;
            counter += 1 * (int)countDirection;
            Result = counter * Multiplier;
            countDirection = counter == 5 ? Direction.Down : countDirection;
            //clear 'isActive' when on the last iteration
            isActive = counter == 1 && countDirection == Direction.Down ? false : isActive;
            return true;
        }
        public override string ToString() => Result.ToString();

        public IEnumerator GetEnumerator() => new GenericStepEnumerator<MultiplyWorker>(this);
        public void Reset()
        {
            isActive = true;
            Result = 1;
            countDirection = Direction.Up;
            counter = 0;
        }
    }
}
