
namespace CertApp
{
    public class LocationInFile : LocationBase
    {
        private string fileNameWithLocationName;
        public LocationInFile(string lane, string row) : base(lane, row)
        {
            fileNameWithLocationName = $"{lane}_{row}_quantities.txt.txt";
        }
        public override event QuantityAddedDelegate QuantityAdded;//delegat
        public override void AddQuantity(float quantity)//podstawowa metoda dodania ilości(we float)
        {
            using (var writer = File.AppendText(fileNameWithLocationName))
            {
                writer.WriteLine(quantity);
            }

            if (QuantityAdded != null)
            {
                QuantityAdded(this, new EventArgs());
            }
        }
        public override Statistics GetStatistics()
        {
            var quantitiesFromFile = this.ReadQuantitiesFromFile();
            var statistics = new Statistics();
            foreach (var quant in quantitiesFromFile)
            {
                statistics.AddQuantity(quant);
            }
            return statistics;
        }
        private List<float> ReadQuantitiesFromFile()
        {
            var quantity = new List<float>();
            if (File.Exists(fileNameWithLocationName))
            {
                using (var reader = File.OpenText(fileNameWithLocationName))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        var number = float.Parse(line);

                        quantity.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return quantity;
        }
    }
}








