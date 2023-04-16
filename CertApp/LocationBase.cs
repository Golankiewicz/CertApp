
namespace CertApp
{
    public abstract class LocationBase : ILocation
    {
        public delegate void QuantityAddedDelegate(object sender, EventArgs args);
        public abstract event QuantityAddedDelegate QuantityAdded;

        public LocationBase(string lane, string row)
        {
            this.Lane = lane;
            this.Row = row;
        }
        public string Lane { get; private set; }
        public string Row { get; private set; }

        public abstract void AddQuantity(float quantity);
        //public abstract void AddQuantity(int quantity);
        public void AddQuantity(int quantity)
        {
            var intAsFloat=(float)quantity;
            this.AddQuantity(intAsFloat);
        }
        //public abstract void AddQuantity(string quantity);
        public void AddQuantity(char quantity)
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
        //public abstract void AddQuantity(char quantity);
        public void AddQuantity(string quantity)
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

        public abstract Statistics GetStatistics();

    }
}
