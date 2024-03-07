//employee.cs

//define inherited class
public class Employee
{
    //define an enumerated type for empType
    public enum EmployeeType
    {
        Associate,
        Manager,
        Production
    }

    //private properties
    private string firstName;
    private string lastName;
    private string id;
    private EmployeeType empType;

    //constructor to initialize an employee
    public Employee(string firstName, string lastName, string id, EmployeeType empType)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.id = id;
        this.empType = empType;
    }
 //get employee information via method
    public void GetEmployeeInfo()
    {
        Console.WriteLine($"Name: {firstName} {lastName}");
        Console.WriteLine($"Employee ID: {id}");
        Console.WriteLine($"Employee Type: {empType}");
    }

    //get and set first name and last name via method
    public string GetFirstName()
    {return firstName;}

    public string GetLastName()
    {return lastName;}

    public void SetFirstName(string newFirstName)
    {firstName = newFirstName;}

    public void SetLastName(string newLastName)
    {lastName = newLastName;}
}
