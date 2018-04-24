using System;
using System.Collections.Generic;

public class CustomerController
{
    
    public static void setCustomers(List<Customer> result)
    {
        Storage.customers = result;
    }

    public static bool Exists(string name)
    {
        Customer c = Storage.customers.Find(x => x.Name == name);
        if (c != null)
        {
            return true;
        }
        else
            return false;
    }

    public static User GetCustomer(string name)
    {
        Customer c = Storage.customers.Find(x => x.Name == name);
        return c;
    }
}