
using Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
public class Storage {


    public Storage() {
    }
    public static List<Order> Orders { get; set; }
    public static List<Customer> customers { get; set; }
    public static List<Dispatcher> dispatchers { get; set; }

    public static int NormalCapacity=3000; 


    public static int CooledCapacity=800;
    internal static readonly int Terminal=10;
}