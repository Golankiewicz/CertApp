
namespace CertApp
{
    public interface ILocation
    {
        string Lane { get; }
        int Row { get; }
        void AddQuantity(int quantity);
        void AddQuantity(string quantity);
        public Statistics GetStatistics();
    }
}
