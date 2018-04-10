
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
        OrderingController.ListOrders();
    }

    public void ConfrimOrders(int ID) {
        OrderingController.ConfirmOrder(ID);
    }

    public void EditOrdersTerminal(int ID)
    {
        //id kiválasztva
        Console.Write("Kiválasztott terminál: ");
        int terminal = Convert.ToInt32(Console.ReadLine());
        OrderingController.editTerminal(ID, terminal);
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
        OrderingController.ListOrders();
        Console.WriteLine("Kiválasztott megrendelés ID-ja: ");
        int ID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Mit szeretne módosítani a megrendelésen?(1-kocsiszín,2-jóváhagyás)");
        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case (int)1:
                EditOrdersTerminal(ID);
                break;
            case (int)2:
                ConfrimOrders(ID);
                break;
            default:
                Console.WriteLine("Nincs ilyen választási lehetőség.");
                break;
        }
    }

    internal void ManageDailyTasks()
    {
        throw new NotImplementedException();
    }
}