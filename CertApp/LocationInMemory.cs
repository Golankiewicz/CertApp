
namespace CertApp
{
    public class LocationInMemory : LocationBase
    {
        public LocationInMemory(string lane, string row) : base(lane, row)
        {

        }

        private List<float> quantities = new List<float>();
        public override event QuantityAddedDelegate QuantityAdded;
        public override void AddQuantity(float quantity)
        {
            if (quantity <= 1000 && quantity > 0)
            {
                this.quantities.Add(quantity);

                if (QuantityAdded != null)

                {
                    QuantityAdded(this, new EventArgs());
                }
            }
            else if (quantity > 1000)
            {
                Console.WriteLine("Location overloaded - give smaller quantity");
            }
        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach (var quantity in this.quantities)
            {
                statistics.AddQuantity(quantity);
            }
            return statistics;
        }
    }
}
