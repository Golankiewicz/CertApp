
namespace CertApp
{


    public class LocationInFile : LocationBase

    {
       
        private const string fileName = "quantities.txt";
        private string fileNameWithLocationName;
        public LocationInFile(string lane, string row) : base(lane, row)
        {
            fileNameWithLocationName = $"{lane}_{row}_{fileName}.txt";
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

        public override void AddQuantity(int quantity)//metoda dodania ilości w int
        {
            var intAsFloat = (float)quantity;
            this.AddQuantity(intAsFloat);
        }

        public override void AddQuantity(char quantity)//metoda dodania ilości w char
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

        public override void AddQuantity(string quantity)//metoda dodania ilości w stringu
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
            var quantitiesFromFile = this.ReadQuantitiesFromFile();
            var statistics = this.GetStatistics(quantitiesFromFile);
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
        private Statistics GetStatistics(List<float> quantities)
        {
            var statistics = new Statistics();
            foreach (var quant in quantities)
            {
                statistics.AddQuantity(quant);
            }
          
            return statistics;
        }


    }
}








