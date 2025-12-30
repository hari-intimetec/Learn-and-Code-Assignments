public class Employee
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Department { get; private set; }
    private bool working;

    public Employee(int id, string name, string department, bool working = true)
    {
        Id = id;
        Name = name;
        Department = department;
        this.working = working;
    }

    public bool IsWorking()
    {
        return working;
    }

    public void TerminateEmployee()
    {
        working = false;
    }

    public void SaveEmployeeToDatabase()
    {
        Console.WriteLine($"Saving employee {Name} to database.");
    }

    public void PrintEmployeeDetailReportCSV()
    {
        Console.WriteLine($"{Id},{Name},{Department},{(working ? "Working" : "Terminated")}");
    }

    public void PrintEmployeeDetailReportXML()
    {
        Console.WriteLine($"<Employee>\n" +
                          $"  <ID>{Id}</ID>\n" +
                          $"  <Status>{(working ? "Working" : "Terminated")}</Status>\n" +
                          $"</Employee>");
    }
}

public class Program
{
    public static void Main()
    {
        Employee emp = new Employee(101, "John Doe", "IT");

        emp.SaveEmployeeToDatabase();
        emp.PrintEmployeeDetailReportCSV();
        emp.PrintEmployeeDetailReportXML();

        emp.TerminateEmployee();
        Console.WriteLine($"Is working? {emp.IsWorking()}");
    }
}