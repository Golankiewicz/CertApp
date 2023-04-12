using CertApp;

Console.WriteLine("This is a model of a storage system");


bool exit = false;

while (!exit)
{
    Console.WriteLine("=================================================================");
    Console.WriteLine();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("Change stock quantity and write operation in memory - 1");
    Console.WriteLine("Change stock quantity and write operation in a file .txt - 2");
    Console.WriteLine("Check stock quantity in a file .txt - 3" +
        "");
    Console.WriteLine("Exit application - X");
    var input = Console.ReadLine();
    switch (input)
    {
        case "1":
            AddQuantitiesInMemory();
            break;
        case "2":
            AddQuantitiesInFile();
            break;
        case "3":
            CheckQuantitiesInFile();
            break;
        case "X" or "x":
            exit = true;
            break;
        default:
            Console.WriteLine("Wrong data. Enter 1,2,3 or X");
            break;
    }
}

void LocationQuantityAdded(object sender, EventArgs args)
{
    Console.WriteLine("Quantity added");
}

void AddQuantitiesInMemory()
{
    Console.WriteLine("Enter storage lane. Possible A, B, or C ");
    string lane = Console.ReadLine();
    Console.WriteLine("Enter storage row. Possible 1,2, till 10");
    string row = Console.ReadLine();


    string[] laneOptions = { "A", "B", "C" };//dostępne alejki
    string[] rowOptions = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };//dostępne rzędy
    if ((Array.IndexOf(laneOptions, lane) != -1) && (Array.IndexOf(rowOptions, row) != -1))
    {
        var locationInMemory = new LocationInMemory(lane, row);
        locationInMemory.QuantityAdded += LocationQuantityAdded;
        EnterQuantity(locationInMemory);
        locationInMemory.GetStatistics();
        var stat = locationInMemory.GetStatistics();
        Console.WriteLine($"Stock level of location {lane}{row}: {stat.Sum} kg is - {stat.Level}");


    }
    else
    {
        Console.WriteLine("You have to enter correct location's lane and row");
    }

}


//======================================================================================

void AddQuantitiesInFile()
{
    Console.WriteLine("Enter storage lane. Possible A, B, or C ");
    string laneLo = Console.ReadLine();
    string lane = laneLo.ToUpper();//zamiana oznaczenia alejek na dużą literę /jeżeli potrzeba/
    Console.WriteLine("Enter storage row. Possible 1,2, till 10");
    string row = Console.ReadLine();

    string[] laneOptions = { "A", "B", "C" };//dostępne alejki
    string[] rowOptions = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };//dostępne rzędy
    if ((Array.IndexOf(laneOptions, lane) != -1) && (Array.IndexOf(rowOptions, row) != -1))
    {
        var locationInFile = new LocationInFile(lane, row);
        locationInFile.QuantityAdded += LocationQuantityAdded;
        EnterQuantity(locationInFile);
        locationInFile.GetStatistics();
        var stat = locationInFile.GetStatistics();
        Console.WriteLine($"Stock level of location {lane}{row}: {stat.Sum} kg is - {stat.Level}");


    }
    else
    {
        Console.WriteLine("You have to enter correct location's lane and row");
    }

}

static void EnterQuantity(ILocation location)
{
    while (true)
    {
        Console.WriteLine($"Enter quantity for location: {location.Lane}{location.Row}" +
            $" between 0-1000 (kg) or w (worek 25kg) or k (karton 10 kg). To quit press q");
        var input = Console.ReadLine();
        if (input == "q" || input == "Q")
        {
            break;
        }
        try
        {
            location.AddQuantity(input);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

}

//=====================================================================================


void CheckQuantitiesInFile()
{
    Console.WriteLine("Enter storage lane. Possible A, B, or C ");
    string laneLo = Console.ReadLine();
    string lane = laneLo.ToUpper();//zamiana oznaczenia alejek na dużą literę /jeżeli potrzeba/
    
    Console.WriteLine("Enter storage row. Possible 1,2, till 10");
    string row = Console.ReadLine();

    string[] laneOptions = { "A", "B", "C" };//dostępne alejki
    string[] rowOptions = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };//dostępne rzędy
    if ((Array.IndexOf(laneOptions, lane) != -1) && (Array.IndexOf(rowOptions, row) != -1))
    {
        var locationInFile = new LocationInFile(lane, row);
        var stat = locationInFile.GetStatistics();
        Console.WriteLine(stat.Sum);
        Console.WriteLine($"Stock level of location {lane}{row}: {stat.Sum} kg is - {stat.Level}");


    }
    else
    {
        Console.WriteLine("You have to enter correct location's lane and row");
    }

}






