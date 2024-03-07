namespace expenseReport;

class Program
{
    static void Main(string[] args)
    {
    List<List<string>> expenses = ReadCsvFile("credit_card.csv");

        decimal totalCost = CalculateTotalCost(expenses);
        int numberOfPurchases = expenses.Count;

        Dictionary<string, decimal> categoryCosts = CalculateCategoryCosts(expenses);
        Dictionary<string, int> categoryCounts = CalculateCategoryCounts(expenses);

        List<List<string>> mostExpensive = FindMostExpensive(expenses, totalCost);
        List<List<string>> leastExpensive = FindLeastExpensive(expenses, totalCost);

        decimal averageCost = CalculateAverageCost(totalCost, numberOfPurchases);

        GenerateExpenseReport("expense_report.txt", totalCost, numberOfPurchases, categoryCosts, categoryCounts, mostExpensive, leastExpensive, averageCost);

        Console.WriteLine("Expense report generated successfully.");
    }

   static List<List<string>> ReadCsvFile(string filePath)
{
    List<List<string>> expenses = new List<List<string>>();
    
        using (StreamReader reader = new StreamReader(filePath))
        
        {string line;

        while ((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            {
                List<string> expense = new List<string>
                {
                    parts[0].Trim(),
                    parts[1].Trim()
                };
                expenses.Add(expense);
    }}}

    return expenses;}

    static decimal CalculateTotalCost(List<List<string>> expenses)
    {
        decimal totalCost = 0;
        for (int i = 0; i < expenses.Count; i++)
        {
            if (decimal.TryParse(expenses[i][1], out decimal cost))
            {
                totalCost += cost;}}
        return totalCost;}

    static Dictionary<string, decimal> CalculateCategoryCosts(List<List<string>> expenses)
    {
        var categoryCosts = new Dictionary<string, decimal>();

        for (int i = 0; i < expenses.Count; i++)
        {
            string category = expenses[i][0];
            if (decimal.TryParse(expenses[i][1], out decimal cost))
            {
                if (categoryCosts.ContainsKey(category))
                {
                    categoryCosts[category] += cost;
                }
                else
                {
                    categoryCosts[category] = cost;
                }}}

        return categoryCosts;}

    static Dictionary<string, int> CalculateCategoryCounts(List<List<string>> expenses)
    {
        var categoryCounts = new Dictionary<string, int>();

        for (int i = 0; i < expenses.Count; i++)
        {
            string category = expenses[i][0];
            if (categoryCounts.ContainsKey(category))
            {
                categoryCounts[category]++;}
            else
            {
                categoryCounts[category] = 1;}
        }

        return categoryCounts;}

    static List<List<string>> FindMostExpensive(List<List<string>> expenses, decimal totalCost)
    {
        decimal maxCost = decimal.MinValue;
        List<List<string>> mostExpensive = new List<List<string>>();

        for (int i = 0; i < expenses.Count; i++)
        {
            if (decimal.TryParse(expenses[i][1], out decimal cost))
            {
                if (cost > maxCost)
                {
                    maxCost = cost;
                    mostExpensive.Clear();
                }
                if (cost == maxCost)
                {
                    mostExpensive.Add(expenses[i]);
                    }}}

        return mostExpensive;}

    static List<List<string>> FindLeastExpensive(List<List<string>> expenses, decimal totalCost)
    {
        decimal minCost = decimal.MaxValue;
        List<List<string>> leastExpensive = new List<List<string>>();

        for (int i = 0; i < expenses.Count; i++)
        {
            if (decimal.TryParse(expenses[i][1], out decimal cost))
            {
                if (cost < minCost)
                {
                    minCost = cost;
                    leastExpensive.Clear();
                }
                if (cost == minCost)
                {
                    leastExpensive.Add(expenses[i]);
                }}}

        return leastExpensive;}

    static decimal CalculateAverageCost(decimal totalCost, int numberOfPurchases)
    {return totalCost / numberOfPurchases;}

    static void GenerateExpenseReport(string fileName, decimal totalCost, int numberOfPurchases, Dictionary<string, decimal> categoryCosts, Dictionary<string, int> categoryCounts, List<List<string>> mostExpensive, List<List<string>> leastExpensive, decimal averageCost)
{using (StreamWriter writer = new StreamWriter(fileName))
    {
        writer.WriteLine("Expense Report");
        writer.WriteLine("---------------------------");
        writer.WriteLine($"Total Cost of Purchases: ${totalCost:F2}");
        writer.WriteLine($"Number of Purchases: {numberOfPurchases}");
        writer.WriteLine();

        foreach (var category in categoryCosts)
        {
            writer.WriteLine($"{category.Key}:");
            writer.WriteLine($"  Total Cost: ${category.Value:F2}");
            writer.WriteLine($"  Number of Purchases: {categoryCounts[category.Key]}");
            writer.WriteLine();}

        writer.WriteLine("Most Expensive Purchases:");
        foreach (var expense in mostExpensive)
        {
            writer.WriteLine($"  {expense[0]}: ${expense[1]}");}
        writer.WriteLine();

        writer.WriteLine("Least Expensive Purchases:");
        foreach (var expense in leastExpensive)
        {
            writer.WriteLine($"  {expense[0]}: ${expense[1]}");}

        writer.WriteLine($"Average Purchase Cost: ${averageCost:F2}");
    }}}