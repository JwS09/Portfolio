class Automobile
{
    private string make;
    private string model;
    private string vin;
    private string color;
    private int year;
    private string vehicleType;

    //initialize the class fields
    public Automobile(string make, string model, int year, string vin, string color, string vehicleType)
    {
        //use "this" to refer to the class fields
        this.make = make;
        this.model = model;
        this.year = year;
        this.vin = vin;
        this.color = color;
        this.vehicleType = vehicleType;
    }

    public string getMake()
    {return make;}

    public string getModel()
    {return model;}

    public string getVin()
    {return vin;}

    public string getColor()
    {return color;}

    //set the color of the automobile
    public void setColor(string newColor)
    {color = newColor;}

    public int getYear()
    {return year;}

    public string getVehicleType()
    {return vehicleType;}

    //calculate and return the age of the automobile
    public int getAutoAge()
    {int currentYear = DateTime.Now.Year;
    return currentYear - year;}
}

class Program
{
    static void Main()
    {
        Console.WriteLine("\nCreating the first Automobile\n---------------");

        //instance of the Automobile class and initializing it with data
        Automobile auto1 = new Automobile("Tesla", "Model X", 2020, "12345", "blue", "Sedan");

        //print information about the first automobile
        Console.WriteLine($"Make: {auto1.getMake()}\nModel: {auto1.getModel()}\nYear: {auto1.getYear()}\nType: {auto1.getVehicleType()}\nVIN: {auto1.getVin()}");
        Console.WriteLine($"Color: {auto1.getColor()}");

        Console.WriteLine("\nChanging the Colour\n---------------");

        //set the color of the first automobile
        auto1.setColor("black");

        //print the updated color of the first automobile
        Console.WriteLine($"Color: {auto1.getColor()}");

        Console.WriteLine("\nCreating the second Automobile\n---------------");

        //second instance of the Automobile class
        Automobile auto2 = new Automobile("Mercedes", "G-Wagon", 2017, "24578", "silver", "SUV");

        //print information about the second automobile
        Console.WriteLine($"Make: {auto2.getMake()}\nModel: {auto2.getModel()}\nYear: {auto2.getYear()}\nType: {auto2.getVehicleType()}\nVIN: {auto2.getVin()}");

        Console.WriteLine("\nPrinting Automobile Ages\n---------------");

        //print the ages of both automobiles
        Console.WriteLine($"Auto1 Age: {auto1.getAutoAge()} years");
        Console.WriteLine($"Auto2 Age: {auto2.getAutoAge()} years");
    }
}
