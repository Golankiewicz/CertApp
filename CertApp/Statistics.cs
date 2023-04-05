
namespace CertApp
{
    public class Statistics
    {
        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public int Count { get; private set; }
        public string Level
        {
            get
            {
                switch (this.Sum)
                {
                    case var sum when sum >= 800:
                        return "High";
                    case var sum when sum >= 400:
                        return "Medium";
                    default:
                        return "Low";
                }
            }
        }
        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = float.MinValue;

        }
        public void AddQuantity(float quantity)
        {
            this.Count++;

            this.Sum += quantity;

            this.Max = Math.Max(this.Max, quantity);
        }

    }
}
