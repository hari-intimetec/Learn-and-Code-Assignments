public class CustomerSearch
{
    private List<Customer> SearchCustomers(Func<Customer, bool> criteria)
    {
        return dbContext.Customers
                 .Where(criteria)
                 .OrderBy(customer => customer.CustomerID)
                 .ToList();
    }

    public List<Customer> SearchByCountry(string country)
    {
        return SearchCustomers(customer => customer.Country.Contains(country));
    }

    public List<Customer> SearchByCompanyName(string company)
    {
        return SearchCustomers(customer => customer.CompanyName.Contains(company));
    }

    public List<Customer> SearchByContact(string contact)
    {
        return SearchCustomers(customer => customer.ContactName.Contains(contact));
    }

    private string ConvertCustomerToCSV(Customer customer)
    {
        return $"{customer.CustomerID},{customer.CompanyName},{customer.ContactName},{customer.Country}";
    }

    public string ExportToCSV(List<Customer> customerList)
    {
        var sb = new StringBuilder();
        foreach (var customer in customerList)
        {
            sb.AppendLine(ConvertCustomerToCSV(customer));
        }
        return sb.ToString();
    }
}