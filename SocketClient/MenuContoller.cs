using System;

internal class MenuContoller
{
    private static string[] CustomerStringMenu = { "Megrendelés hozzáadása", "Megrendelések listázása", "Kilépés" };
    private enum CustomerEnumMenu{zeromenu,ordering,listorders,exit};

    private static string[] DispatcherStringMenu = { "Napi feladatok összeállítása","Megrendelések módosítása", "Megrendelések listázása", "Kilépés" };

    private enum DispatcherEnumMenu { zeromenu,manageDailtyTasks, editOrders, listorders, exit };


    //TODO: DispatcherString és Enum Menu és static void Start(Dispatcher dispatcher)

    internal static void Start(Customer customer)
    {

        Console.WriteLine("Válasszon az alábbi lehetőségek közül: ");
        int option = 0;
            while (option!=(int)CustomerEnumMenu.exit)
            {
            
            for (int i = 0; i < CustomerStringMenu.Length; i++)
            {
                Console.WriteLine("(" + (i + 1) + ")" + CustomerStringMenu[i]);
            }
            Console.Write("Választott opció: ");
            option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
                switch (option)
                {

                    case (int)CustomerEnumMenu.ordering:
                    customer.Ordering();
                        break;
                    case (int)CustomerEnumMenu.listorders:
                    customer.ListOrders();
                        break;
                    case (int)CustomerEnumMenu.exit:
                        break;

                    default:
                        Console.WriteLine("Ilyen menüpont nem létezik");
                        break;
                }
            }
        }

    internal static void Start(Dispatcher dispatcher)
    {

        Console.WriteLine("Válasszon az alábbi lehetőségek közül: ");
        int option = 0;
        while (option != (int)DispatcherEnumMenu.exit)
        {

            for (int i = 0; i < DispatcherStringMenu.Length; i++)
            {
                Console.WriteLine("(" + (i + 1) + ")" + DispatcherStringMenu[i]);
            }
            Console.Write("Választott opció: ");
            option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (option)
            {
                case (int)DispatcherEnumMenu.manageDailtyTasks:
                    dispatcher.ManageDailyTasks();
                    break;
                case (int)DispatcherEnumMenu.editOrders:
                    dispatcher.EditOrders();
                    break;
                case (int)DispatcherEnumMenu.listorders:
                    dispatcher.ListOrders();
                    break;
                case (int)DispatcherEnumMenu.exit:
                    break;

                default:
                    Console.WriteLine("Ilyen menüpont nem létezik");
                    break;
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }

}