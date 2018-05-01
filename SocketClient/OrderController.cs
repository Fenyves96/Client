﻿using AsynchronousClient;
using Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class OrderController
{
    

    public static void MakeSomeOrder() //Itt csak csináltam pár Ordert, hogy ne kézzel kelljen megadni
    {
        Order o1 = new Order(2, "2018-02-03", "2018-04-05", 21, true, "Köszöntem");
        Order o2 = new Order(2, "2018-02-03", "2018-04-05", 21, true, "Ketteske");
        Order o3 = new Order(2, "2018-02-03", "2018-04-05", 21, true, "Hármaska");
        Storage.Orders.Add(o1);
        Storage.Orders.Add(o2);
        Storage.Orders.Add(o3);

    }

    internal static void setOrders(List<Order> orders)
    {
        Storage.Orders = orders;
    }

    public static void ListOrders(int CustomerID) //orderek listázása Customereknek
    {
        foreach (Order o in Storage.Orders)
        {
            if (o.CustomerID == CustomerID)
            { //TODO:bug
                o.Print();
            }
        }
    }

    public static void ListOrders() //összes Order listázása
    {
        foreach (Order o in Storage.Orders)
        {
            
                o.Print();
        }
    }

    public static void editTerminal(int ID, int terminal) //adott id-ű order jóváhagyása
    {
        try
        {
            if (ID > 0 && terminal > 0 && terminal <= Storage.Terminal)
            {
                Storage.Orders.Find(x => x.ID == ID).Terminal = terminal;
                Console.WriteLine("Kocsiszín sikeresen módosítva.");
            }
            else
            {
                Console.WriteLine("Nincs ilyen ID vagy kocsiszín");
            }
        }

        catch (Exception e) {
            Console.WriteLine("Nincs ilyen ID vagy kocsiszín");
        }
    }

    public static void ListOrders(string date)
    {
        
        foreach(Order o in Storage.Orders)
        {
            if (date.Equals(o.DateIn.ToString("yyyy-MM-dd")))
            {
                Console.WriteLine();
                o.Print();
            }
            if (date.Equals(o.DateOut.ToString("yyyy-MM-dd")))
            {
                Console.WriteLine();
                o.Print();
            }

        }
    }

    public static void ConfirmOrder(int ID) //adott id-ű order jóváhagyása
    {
            try
            {
            Storage.Orders.Find(x => x.ID == ID).Confirmed = true;
                Console.WriteLine("Sikeresen jóváhagyva a " + ID + " ID-val rendelkező megrendelés.");
            }
            catch (Exception e) { Console.WriteLine("Nincs ilyen ID"); }  
    }

    public static int GetStorageNormalCapacity()
    {
        return Storage.NormalCapacity;
    }

    public static int GetStorageCooledCapacity()
    {
        return Storage.CooledCapacity;
    }
    //Order küldése a serverre
    public static void AddOrder(int customerID, string datein, string dateout, int quantity, bool cooled, string comment)
    {
        
        int ID= GetNextID();
        Order order = new Order(ID,customerID, datein, dateout, quantity, cooled,comment);
        Storage.Orders.Add(order);
        Task<Order> tsResponse = SocketClient.SendRequest(order);
       // Console.WriteLine("Üzenet továbbítva a szerverre, kérem várjon!");
        Order dResponse = tsResponse.Result;
        //Console.WriteLine(dResponse);
       // Console.WriteLine("------------------------------------------------------------------------------------");
  
    }

    private static int GetNextID()
    {
        return (Storage.Orders.Count + 1);
    }
}