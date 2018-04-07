using System;
using AsynchronousClient;


public class Program
{
    public static void Main(String[] args)
    {
        
        //SocketClient.StartClient();
        //OrderingController.AddOrder(3, "2018-04-04", "2018-05-05", 3, true, "comment");
        OrderingController.MakeSomeOrder();
        OrderingController.ListOrders();
        OrderingController.ConfirmOrder(0);
        OrderingController.ListOrders();

        User user=LoginController.Login();
        Type t = user.GetType();
        if (t.Equals(typeof(Customer)))
        {
            
            Customer customer = (Customer)user;
            MenuContoller.Start(customer);
        }
        else if (t.Equals(typeof(Dispatcher)))
        {
            
        }
        

        
        //Process process = new Process();
        //process.ReadAndWrite();
        SocketClient.Close();
    }
}