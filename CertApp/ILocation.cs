
namespace CertApp
{
    public interface ILocation
    {
        string Lane { get; }
        string Row { get; }
        void AddQuantity(int quantity);
        void AddQuantity(float quantity);
        void AddQuantity(string quantity);
        void AddQuantity(char quantity);
        public Statistics GetStatistics();
    }
}
