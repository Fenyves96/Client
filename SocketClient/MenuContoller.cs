using System;

internal class MenuContoller
{
    private static string[] CustomerStringMenu = { "Megrendelés hozzáadása", "Megrendelések listázása", "Kilépés" };
    private enum CustomerEnumMenu{zeromenu,ordering,listorders,exit};
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
    
}