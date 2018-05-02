
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/**
 * 
 */
public class Customer : User {


    public int StorageNormalCapacity { get; set; }


    public int StorageCooledCapacity { get; set; }

    public string GetName()
    {
        return Name;
    }
    public Customer() { }

    public Customer(string Name):base(Name)
    {
        
        StorageNormalCapacity = Storage.NormalCapacity;
        StorageCooledCapacity = Storage.CooledCapacity;
    }
    

    //itt még nincs lekezelve a user hülyesége
    public void Ordering() {
        StorageNormalCapacity = OrderController.GetStorageNormalCapacity();
        StorageCooledCapacity = OrderController.GetStorageCooledCapacity();
        // TODO implement here
        Console.Write("Beszállítás időpontja(év-hó-nap): ");
        string datein = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Kiszállítás időpontja(év-hó-nap): ");
        string dateout = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Beszállítandó mennyiség: ");
        int quantity = 0;
        try
        {
            quantity = Convert.ToInt32(Console.ReadLine()); //hány raklapot szeretnék beszállítani
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        Console.WriteLine();
        Console.Write("Hűtött áru:(igen/nem): ");
        string cooledString = "";
        bool cooled=false;
        while (!cooledString.Equals("nem") && !cooledString.Equals("igen"))
        {
            cooledString = Console.ReadLine();
            if (cooledString.Equals("igen"))
            {
                cooled = true;
            }
            else if (cooledString.Equals("nem"))
            {
                cooled = false;
            }
            else
            {
                Console.WriteLine("helytelen bevitel");
                Console.Write("Hűtött áru:(igen/nem): ");
                cooledString = Console.ReadLine();
            }
        }
        Console.WriteLine();

        if (cooled)
        {
            //rendelkezésre álló helyek vizsgálata
            if (StorageNormalCapacity < quantity)
            {
                Console.WriteLine("Nincs elegendő hely");
                return;
            }
            else
            {
                StorageNormalCapacity -= quantity;
            }
        }
        else
        {
            if (StorageCooledCapacity < quantity)
            {
                Console.WriteLine("Nincs elegendő hely");
                return;
            }
            else
            {
                StorageNormalCapacity -= quantity;
            }
        }
        Console.Write("Megjegyzés: ");
        string comment=Console.ReadLine();

        if (!comment.Equals(""))
        {
            Console.WriteLine("Megjegyzés elmentve");
        }

        try
        {
            OrderController.AddOrder(ID, datein, dateout, quantity, cooled, comment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


    }
    //ez kilistázza az ordereket, ami az adott Customerhez tartozik
    public void ListOrders() {
        OrderController.ListOrders(ID);
    }

    public override string ToString()
    {
        return "Customer";
    }

    public void ShowCapacity()
    {
        Console.WriteLine("A normál raktárhelyek száma: " + OrderController.GetStorageNormalCapacity() + "/3000");
        Console.WriteLine("A hűtött raktárhelyek száma: " + OrderController.GetStorageCooledCapacity() + "/800");
    }
}