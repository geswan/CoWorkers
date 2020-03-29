using System.Collections;

namespace CoWorkers
{
    public enum Direction
    {
        Up = 1,
        Down = -1,
    }
    public class UpDownCounterWorker : IWorker, IEnumerable
    {
        public UpDownCounterWorker(int upTo)
        {
            UpTo = upTo;
        }
        private int result = 0;
        private Direction CountDirection = Direction.Up;
        private bool IsActive = true;
        public int UpTo { get; set; }
        public void Reset()
        {
            IsActive = true;
            result = 0;
            CountDirection = Direction.Up;

        }
        public bool Step()
        {
            if (!IsActive) return false;
            result += 1 * (int)CountDirection;
            CountDirection = result == UpTo ? Direction.Down : CountDirection;
            //clear the IsActive flag on the last iteration
            IsActive = result == 1 && CountDirection == Direction.Down ? false : IsActive;
            return true;
        }
        public IEnumerator GetEnumerator() => new GenericStepEnumerator<UpDownCounterWorker>(this);
        public override string ToString() => result.ToString();
    }
}
