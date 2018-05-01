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
        asderino(asd);
    }

    public void asderino(int orderid)
    {
        DeliveryNoteController.AddDeliveryNote(true, ID, orderid);
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