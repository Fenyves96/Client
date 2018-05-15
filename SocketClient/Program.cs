using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AsynchronousClient;
using Communication;

public class Program
{
    public static void Main(String[] args)
    {

        Storage.CooledPlaces = new  bool[800];
        Storage.NormalPlaces = new bool[3000];

        //Order o = new Order();
        //o.PalletQuantity = 200;
        //o.Confirmed = true;
        //o.ID = 3;
        //o.Cooled = true;
        //Storage.Orders = new List<Order>();
        //Storage.Orders.Add(o);
        //OrderController.AddOccupiedPlaces(o.ID, o.PalletQuantity);
        //o.Print();

        



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
            Task<List<DeliveryNote>> tsResponseDeliveryNotes = SocketClient.LoadDeliveryNotes();
            DeliveryNoteController.setDeliveryNotes(tsResponseDeliveryNotes.Result);


            //int sum=0;
            //int q;
            //Console.WriteLine(Storage.CooledCapacity + " " + Storage.NormalCapacity);
            //foreach(Order o in Storage.Orders)
            //{
            //    if (o.Cooled) {
            //        Storage.CooledCapacity -= o.PalletQuantity;
            //    }
            //    else { Storage.NormalCapacity -= o.PalletQuantity; }
                
            //}

            //Console.WriteLine(Storage.CooledCapacity + " " + Storage.NormalCapacity);


        }
        catch (Exception e)
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