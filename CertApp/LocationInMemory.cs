
namespace CertApp
{
    public class LocationInMemory : LocationBase

    {
        public LocationInMemory(string lane, int row) : base(lane, row)
        {
            this.Quantity = 0;
        }

        private List<float> quantities= new List<float>();
        public override event QuantityAddedDelegate QuantityAdded;

        

        public override void AddQuantity(float quantity)
        {
            if (quantity >= 0 && quantity <= 100)
            {
                this.quantities.Add(quantity);
                this.Quantity += quantity;
                if (QuantityAdded != null)
                {
                    QuantityAdded(this, new EventArgs());
                }
            }
            
        }

        public override void AddQuantity(string quantity)
        {
            if(float.TryParse(quantity, out float result))
            {
                this.AddQuantity(result);
            }else if(char.TryParse(quantity, out char Letter)){
                this.AddQuantity(Letter);
            }
            else
            {
                throw new Exception("String is not a float");
            }
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        
    }
}
