
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
public class Dispatcher:User {

    /**
     * 
     */
    public Dispatcher(string Name):base(Name){
    }


    public void ListOrders() { //Megrendelések listázása
        OrderController.ListOrders();
    }

    public void ConfrimOrder(int ID) {
        OrderController.ConfirmOrder(ID);
    }

    public void EditOrderTerminal(int ID)
    {
        //id kiválasztva
        Console.Write("Kiválasztott terminál: ");
        int terminal = Convert.ToInt32(Console.ReadLine());
        OrderController.editTerminal(ID, terminal);
    }

    public void ShowStorageState()
    {
        Console.WriteLine("A normál raktárhelyek száma:(Összes Megrendelés alapján)" + OrderController.GetStorageNormalCapacity() + "/3000");
        Console.WriteLine("A hűtött raktárhelyek száma:(Összes Megrendelés alapján)" + OrderController.GetStorageCooledCapacity() + "/800");
        Console.WriteLine("A normál raktárhelyek száma:(Jóváhagyott Megrendelések alapján)" + OrderController.getOccupiedNormalCapacity() + "/3000");
        Console.WriteLine("A hűtött raktárhelyek száma:(Jóváhagyott Megrendelések alapján)" + OrderController.getOccupiedCooledCapacity() + "/800");

    }

    public void ListDailyTasks() {
        // TODO implement here
    }

    public override string ToString()
    {
        return "Dispatcher";
    }

    internal void EditOrders()
    {
        //kiválasztjuk a módosítani kívánt ordert
        OrderController.ListOrders();
        Console.WriteLine("Kiválasztott megrendelés ID-ja: ");
        int ID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Mit szeretne módosítani a megrendelésen?(1-kocsiszín,2-jóváhagyás)");
        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case (int)1:
                EditOrderTerminal(ID);
                break;
            case (int)2:
                ConfrimOrder(ID);
                break;
            default:
                Console.WriteLine("Nincs ilyen választási lehetőség.");
                break;
        }
    }

    internal void ManageDailyTasks()
    {
        Console.Write("Dátum(év-hó-nap): ");
        string date = Console.ReadLine();
        OrderController.ListOrders(date);
    }
}