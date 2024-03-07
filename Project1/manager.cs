//manager.cs

//define inherited class
public class Manager : Employee
{
    //private properties
    private string department;
    private string region;

    public Manager(string firstName, string lastName, string id, string department, string region)
    : base(firstName, lastName, id, EmployeeType.Manager) //set empType in the base class constructor
    {
        this.department = department;
        this.region = region;
    }

    //get and set department via method
    public string GetDepartment()
    {return department;}

    public void SetDepartment(string newDepartment)
    {department = newDepartment;}

    //get and set region via method
    public string GetRegion()
    {return region;}

    public void SetRegion(string newRegion)
    {region = newRegion;}
}