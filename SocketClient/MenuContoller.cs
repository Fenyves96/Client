using System;
internal class MenuContoller
{
    private static string[] CustomerStringMenu = { "Megrendelés hozzáadása", "Megrendelések listázása", "Raktár állapotának lekérése", "Kilépés" };
    private enum CustomerEnumMenu{zeromenu, ordering, listorders, showStorageState, exit};

    private static string[] DispatcherStringMenu = { "Napi feladatok összeállítása","Megrendelések módosítása", "Megrendelések listázása", "Raktár állapotának lekérése", "Kilépés" };

    private enum DispatcherEnumMenu { zeromenu, manageDailyTasks, editOrders, listorders, showStorageState, exit };

    private static string[] ForemanStringMenu = { "Megrendelések listázása", "Napi feladatok összeállítása", "Szállítólevelek listázása", "Szállítólevél létrehozása", "Szállítólevél módosítása", "Raktár állapotának lekérése", "Kilépés" };
    private enum ForemanEnumMenu { zeromenu, listorders, manageDailyTasks, listDeliveryNotes, generateDeliveryNote, editDeliveryNote, showStorageState, exit };


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
                    case (int)CustomerEnumMenu.showStorageState:
                        customer.ShowCapacity();
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
                case (int)DispatcherEnumMenu.manageDailyTasks:
                    dispatcher.ManageDailyTasks();
                    break;
                case (int)DispatcherEnumMenu.editOrders:
                    dispatcher.EditOrders();
                    break;
                case (int)DispatcherEnumMenu.listorders:
                    dispatcher.ListOrders();
                    break;
                case (int)DispatcherEnumMenu.showStorageState:
                    dispatcher.ShowStorageState();
                    break;
                case (int)DispatcherEnumMenu.exit:
                    break;

                default:
                    Console.WriteLine("Ilyen menüpont nem létezik");
                    break;
            }
        }
    }

    internal static void Start(Foreman foreman)
    {

        Console.WriteLine("Válasszon az alábbi lehetőségek közül: ");
        int option = 0;
        while (option != (int)ForemanEnumMenu.exit)
        {

            for (int i = 0; i < ForemanStringMenu.Length; i++)
            {
                Console.WriteLine("(" + (i + 1) + ")" + ForemanStringMenu[i]);
            }
            Console.Write("Választott opció: ");
            option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (option)
            {
                case (int)ForemanEnumMenu.listorders:
                    foreman.ListOrders();
                    break;
                case (int)ForemanEnumMenu.manageDailyTasks:
                    foreman.ManageDailyTasks();
                    break;
                case (int)ForemanEnumMenu.listDeliveryNotes:
                    foreman.ListDeliveryNotes();
                    break;
                case (int)ForemanEnumMenu.generateDeliveryNote:
                    foreman.GenerateDeliveryNote();
                    break;
                case (int)ForemanEnumMenu.editDeliveryNote:
                    foreman.EditDeliveryNotes();
                    break;
                case (int)ForemanEnumMenu.showStorageState:
                    foreman.ShowStorageState();
                    break;
                case (int)ForemanEnumMenu.exit:
                    break;

                default:
                    Console.WriteLine("Ilyen menüpont nem létezik");
                    break;
            }
        }
    }

}