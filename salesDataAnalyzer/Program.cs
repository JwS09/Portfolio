namespace salesDataAnalyzer;
{
    public class Transaction
{
    public string InvoiceId { get; set; }
    public string Branch { get; set; }
    public string City { get; set; }
    public string CustomerType { get; set; }
    public string Gender { get; set; }
    public string ProductLine { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public string Payment { get; set; }
    public double Rating { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
            {
            Console.WriteLine("Usage: salesDataAnalyzer <inputFilePath> <outputFilePath>");
            return;}

            string inputFilePath = args[0];
            string outputFilePath = args[1];

            List<Transaction> transactions = new List<Transaction>();

            //read sales data and parse
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                reader.ReadLine(); //skip header
                string line;
                while ((line = reader.ReadLine()) != null)
                    {
                        string[] data =line.Split(',');
                        if (data.Length == 11)
                            {
                                Transaction transaction = new Transaction
                                    {
                                    InvoiceId = data[0],
                                    Branch = data[1],
                                    City = data[2],
                                    CustomerType = data[3],
                                    Gender = data[4],
                                    ProductLine = data[5],
                                    UnitPrice = decimal.Parse(data[6]),
                                    Quantity = int.Parse(data[7]),
                                    Date = DateTime.Parse(data[8]),
                                    Payment = data[9],
                                    Rating = double.Parse(data[10])
                                    };

                                    salesDataAnalyzer.Add(transaction);
                            }
                    }
            }
    }
}