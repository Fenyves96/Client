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
        OrderingController.MakeSomeOrder();
        //OrderingController.ListOrders();
        //OrderingController.ConfirmOrder(0);
        //OrderingController.ListOrders();
        try
        {
            Task<List<Order>> tsResponse = SocketClient.Load();
            OrderingController.setOrders(tsResponse.Result);
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }


        User user=LoginController.Login();
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
        

        
        //Process process = new Process();
        //process.ReadAndWrite();
        //SocketClient.Close();
    }
}