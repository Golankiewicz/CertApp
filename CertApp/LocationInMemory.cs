
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
        public override void AddQuantity(int quantity)
        {
            var intAsFloat = (float)quantity;
            this.AddQuantity(intAsFloat);
        }
        public override void AddQuantity(char quantity)
        {
            switch (quantity)
            {
                case 'w':
                    AddQuantity(25);
                    break;
                case 'k':
                    AddQuantity(10);
                    break;
                default:
                    throw new Exception("Wrong letter");
            }
        }
        public override void AddQuantity(string quantity)
        {
            if (float.TryParse(quantity, out float result))
            {
                this.AddQuantity(result);
            }
            else if (char.TryParse(quantity, out char Letter))
            {
                this.AddQuantity(Letter);
            }
            else
            {
                throw new Exception("String is not a float");
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
