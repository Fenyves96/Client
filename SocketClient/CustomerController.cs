using System;
using System.Collections.Generic;

public class CustomerController
{
    public static List<Customer> customers { get; set; }
    public static void setCustomers(List<Customer> result)
    {
        customers = result;
    }

    public static bool Exists(string name)
    {
        Customer c = customers.Find(x => x.Name == name);
        if (c != null)
        {
            return true;
        }
        else
            return false;
    }

    public static User GetCustomer(string name)
    {
        Customer c = customers.Find(x => x.Name == name);
        return c;
    }
}