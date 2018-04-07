
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

    public int ID;


    public string Name;


    public void ListOrders() { //Megrendelések listázása
        OrderingController.ListOrders();
    }

    public void ConfrimOrders() {
        ListOrders();
        Console.Write("Adja meg a jóváhagyni kívánt megrendelés azonosítóját!");
        int ID = Convert.ToInt32(Console.ReadLine());
        
    }

    public void ListDailyTasks() {
        // TODO implement here
    }

    public override string ToString()
    {
        return base.ToString();
    }


}