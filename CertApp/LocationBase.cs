
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

        public float Quantity { get; set; }


        public abstract void AddQuantity(float quantity);
        public abstract void AddQuantity(int quantity);

        public abstract void AddQuantity(string quantity);
        public abstract void AddQuantity(char quantity);

        public abstract Statistics GetStatistics();
        

               
    }
}
