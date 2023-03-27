
using CertApp;

var location = new LocationInMemory("A", 2);


location.AddQuantity(10);



Console.WriteLine($"Lokacja {location.Lane}{location.Row} quantity {location.Quantity}");