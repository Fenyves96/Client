using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsynchronousClient;
using Communication;

public class Program
{
    public static void Main(String[] args)
    {
        
        SocketClient.StartClient();
        //OrderingController.AddOrder(3, "2018-04-04", "2018-05-05", 3, true, "comment");
        //OrderController.MakeSomeOrder();
        //OrderingController.ListOrders();
        //OrderingController.ConfirmOrder(0);
        //OrderingController.ListOrders();
        try
        {
            Task<List<Order>> tsResponseOrders = SocketClient.LoadOrders();
            OrderController.setOrders(tsResponseOrders.Result);
            Task<List<Customer>> tsResponseUsers = SocketClient.LoadCustomers();
            CustomerController.setCustomers(tsResponseUsers.Result);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }


        User user=LoginController.Login();
        if (user != null)
        {
            Type t = user.GetType();
        
            if (t.Equals(typeof(Customer)))
            {

                Customer customer = (Customer)user;
                MenuContoller.Start(customer);
            }
            else if (t.Equals(typeof(Dispatcher)))
            {
                Dispatcher dispatcher = (Dispatcher)user;
                MenuContoller.Start(dispatcher);
            }
            else if (t.Equals(typeof(Foreman)))
            {
                Foreman foreman = (Foreman)user;
                MenuContoller.Start(foreman);
            }
        }
        

        
        //Process process = new Process();
        //process.ReadAndWrite();
        //SocketClient.Close();
    }
}