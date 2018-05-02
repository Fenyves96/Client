using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsynchronousClient;
using Communication;
using System.Xml.Serialization;

/**
 * 
 */
public class Foreman : User
{

    /**
     * 
     */
    public Foreman(string Name) : base(Name)
    {
    }


    public void ListOrders()
    { 
        OrderController.ListOrders();
    }

    public void ListDeliveryNotes()
    {
        DeliveryNoteController.ListDeliveryNotes();
    }

    public void GenerateDeliveryNote()
    {
        OrderController.ListOrders();
        Console.WriteLine("Adja meg a rendelés számot!");
        int asd = Convert.ToInt32(Console.ReadLine());
        CallingTheDeliveryAdder(asd);                    //ez hívja meg az ez alattit
    }

    public void CallingTheDeliveryAdder(int orderid)    //nem tudtam jobb nevet adni, a lényeg, hogy muszáj voltam két fv-el megcsinálni,
    {                                                   //mert a menü controllerben csak paraméter nélküli függvény lehet (asszem)
        DeliveryNoteController.AddDeliveryNote(false, ID, orderid);
    }

    public void EditDeliveryNotes()
    {
        if (Storage.deliverynotes.Count >= 1)
        {
            ListDeliveryNotes();
            Console.WriteLine("Adja meg az ID-t!");
            int value = Convert.ToInt32(Console.ReadLine());
            DeliveryNoteController.EditDeliveryNote(value);
        }
        else Console.WriteLine("Üres a lista!");
        
    }

    public void ShowStorageState()
    {
        Console.WriteLine("A normál raktárhelyek száma: " + OrderController.GetStorageNormalCapacity() + "/3000");
        Console.WriteLine("A hűtött raktárhelyek száma: " + OrderController.GetStorageCooledCapacity() + "/800");
    }

    public override string ToString()
    {
        return "Foreman";
    }

    internal void ManageDailyTasks()
    {
        Console.Write("Dátum(év-hó-nap): ");
        string date = Console.ReadLine();
        OrderController.ListOrders(date);
    }
}