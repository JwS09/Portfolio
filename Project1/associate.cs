//associate.cs

//define inherited class
public class Associate : Employee
{
    //define an enumerated type
    public enum SalesLevel
    {
        Bronze,
        Silver,
        Gold,
        Diamond,
        Platinum
    }

    //private properties
    private string department;
    private float totalSales;

    //constructor for associate class
    public Associate(string firstName, string lastName, string id, string department, float sales)
    : base(firstName, lastName, id, Employee.EmployeeType.Associate)
    {
        this.department = department;
        totalSales = sales;
    }

    //update and determine sales level via total sales (method)
    public void UpdateSales(float salesToAdd)
    {totalSales += salesToAdd;}

    

    public SalesLevel GetSalesLevel()
    {
        if (totalSales < 10000)
            return SalesLevel.Bronze;
        else if (totalSales < 20000)
            return SalesLevel.Silver;
        else if (totalSales < 30000)
            return SalesLevel.Gold;
        else if (totalSales < 40000)
            return SalesLevel.Diamond;
        else
            return SalesLevel.Platinum;
    }


//methods for total sales and department 
    public float GetTotalSales()
    {return totalSales;}

    public string GetDepartment()
    {return department;}
}
