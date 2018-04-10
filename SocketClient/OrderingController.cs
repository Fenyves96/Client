using AsynchronousClient;
using Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class OrderingController
{
    private static List<Order> Orders = new List<Order>();
    

    



    public static void MakeSomeOrder() //Itt csak csináltam pár Ordert, hogy ne kézzel kelljen megadni
    {
        Order o1 = new Order(2, "2018-02-03", "2018-04-05", 21, true, "Köszöntem");
        Order o2 = new Order(2, "2018-02-03", "2018-04-05", 21, true, "Ketteske");
        Order o3 = new Order(2, "2018-02-03", "2018-04-05", 21, true, "Hármaska");
        Orders.Add(o1);
        Orders.Add(o2);
        Orders.Add(o3);

    }

    internal static void setOrders(List<Order> orders)
    {
        Orders = orders;
    }

    public static void ListOrders(int CustomerID) //orderek listázása Customereknek
    {
        foreach (Order o in Orders)
        {
            if (o.ID == CustomerID)
                o.Print();
        }
    }

    public static void ListOrders() //összes Order listázása
    {
        foreach (Order o in Orders)
        {
            
                o.Print();
        }
    }

    public static void editTerminal(int ID, int terminal) //adott id-ű order jóváhagyása
    {
        if (ID > 0 && ID <= Orders.Count && terminal>0 && terminal <=Storage.Terminal)
            Orders.Find(x => x.ID == ID).Terminal = terminal;

        else
            Console.WriteLine("Nincs ilyen ID vagy kocsiszín");
    }

    public static void ConfirmOrder(int ID) //adott id-ű order jóváhagyása
    {
        if (ID > 0 && ID <= Orders.Count)
            Orders.Find(x => x.ID == ID).Confirmed = true;
        else
            Console.WriteLine("Nincs ilyen ID");
    }
    //Order küldése a serverre
    public static void AddOrder(int customerID, string datein, string dateout, int quantity, bool cooled, string comment)
    {
       
        Order order = new Order(customerID, datein, dateout, quantity, cooled,comment);
        Orders.Add(order);
        Console.Write(order.Cooled);
        Task<Order> tsResponse = SocketClient.SendRequest(order);
       // Console.WriteLine("Üzenet továbbítva a szerverre, kérem várjon!");
        Order dResponse = tsResponse.Result;
        //Console.WriteLine(dResponse);
       // Console.WriteLine("------------------------------------------------------------------------------------");
  
    }
}