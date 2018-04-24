using System;
//Login kezelése
internal class LoginController
{
    enum Users {zeroUser,customer,dispatcher } //zeroUser csak azért van, hogy 1-től induljon a számozás
    static string[] users = { "Megrendelő", "Diszpécser" };
    public static User Login()
    {
        Console.WriteLine("Bejelentkezés");
        for (int i = 0; i < users.Length; i++)
        {
            Console.WriteLine("(" + (i + 1) + ")" +users[i]);
        }
        Console.Write("Választott felhasználó: ");
        int user = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        string name="";
        switch (user)
        {
            case (int)Users.customer:
                Console.Write("Név: ");
                name = Console.ReadLine();
                Console.WriteLine();
                if (CustomerController.Exists(name))
                {

                    return CustomerController.GetCustomer(name);
                }
                else
                {
                    Console.WriteLine("Nincs ilyen felhasználó.");
                    return null;
                }
            case (int)Users.dispatcher:
                Console.Write("Név: ");
                name = Console.ReadLine();
                Console.WriteLine();
                return new Dispatcher(name);
            default:
                Console.WriteLine("Nem létezik ilyen felhasználó!");
                return null;
        }
    }
}