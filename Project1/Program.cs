namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of Employee, Associate, and Manager
            Employee employee1 = new Employee("Truman", "Tiger", "12345", Employee.EmployeeType.Associate);
            Associate associate1 = new Associate("Mickey", "Mouse", "23456", "Sporting Goods", 7500);
            Manager manager1 = new Manager("Elmer", "Fudd", "56789", "Electronics", "Midwest");

            Console.WriteLine("\n-------Employee 1-------------");
            employee1.GetEmployeeInfo();

            Console.WriteLine("\n-------Sales Person 1-------------");
            associate1.GetEmployeeInfo();
            Console.WriteLine($"Sales Level: {associate1.GetSalesLevel()} | Sales: ${associate1.GetTotalSales()}");
            associate1.UpdateSales(5250.70f);
            Console.WriteLine($"Updated Sales Level: {associate1.GetSalesLevel()} | Updated Sales: ${associate1.GetTotalSales()}");

            Console.WriteLine("\n-------Manager 1-------------");
            manager1.GetEmployeeInfo();
            Console.WriteLine($"Dept: {manager1.GetDepartment()} | Region: {manager1.GetRegion()}");
            manager1.SetFirstName("Wiley");
            manager1.SetLastName("Coyote");
            manager1.SetRegion("Southeast");
            manager1.SetDepartment("Automotive");
            Console.WriteLine($"\nNew Name: {manager1.GetFirstName()} {manager1.GetLastName()}");
            Console.WriteLine($"New Dept: {manager1.GetDepartment()} | New Region: {manager1.GetRegion()}");
        }
    }
}
