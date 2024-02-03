using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bsuiness
{
    internal class Program
    {


        static void Main(string[] args)
        {
            int usersCount = 0;
            const int userArrSize = 10;                   // Constant array size
            string[] users = new string[userArrSize];       // Array for names
            string[] passwords = new string[userArrSize];   // Array for passwords
            string[] roles = new string[userArrSize];       // Array for roles
            int del = 0;
            const int productLimit = 100;

            // data structs
            string[] products = new string[productLimit];
            string[] brands = new string[productLimit];
            int[] quantity = new int[productLimit];
            float[] prices = new float[productLimit];

            // initializing first 10 values
            string[] intialize1 = { "A.C.", "Laptop", "Headphones", "Smartphones", "Digital Cameras", "Smartwatch", "Tablets", "UPS", "LED", "Printers" };
            string[] initialize2 = { "Haier", "HP", "Sony", "Samsung", "Canon", "LG", "Apple", "Belkin", "MaxLite", "Dell" };
            int[] initialize3 = { 10, 14, 15, 17, 16, 11, 9, 8, 14, 7 };
            float[] initialize4 = { 200000, 100000, 45000, 100000, 50000, 35000, 80000, 150000, 120000, 60000 };
            // initializing with loop first 10 vals
            for (int i = 0; i < 10; i++)
            {
                products[i] = intialize1[i];
                brands[i] = initialize2[i];
                quantity[i] = initialize3[i];
                prices[i] = initialize4[i];
            }
            int productsCount = 10;                             /// product count ///

            string[] feedbackCount = new string[productLimit];                           ///feedback array ///
            int feedbackiteration = 0;
            string adminPassword = "shop";             /// admin password ///


            int cartCount = 0;
            const int maxCartSize = 10;
            string[] cartProducts = new string[maxCartSize];
            string[] cartBrands = new string[maxCartSize];
            int[] cartQuantities = new int[maxCartSize];
            float[] cartPrices = new float[maxCartSize];
            float totalAmount = 0.0F;








            string loginOption = "0";
            while (loginOption != "4")             // login menu
            {
                topHeader();
                loginOption = loginMenu();
                if (loginOption == "1")         //admin login option 1
                {
                    adminHeader();
                    string password;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("   \t\t\t\t\t\t\t\t\t Enter password: ");
                    password = Console.ReadLine();
                    if (password == adminPassword)
                    {
                        Console.Clear();
                        adminInterface(products, brands, quantity, prices, ref productsCount, ref del, feedbackCount, ref feedbackiteration, ref adminPassword);


                    }
                    else
                    {
                        Console.WriteLine("   \t\t\t\t\t\t\t\t\t Wrong Password");
                        clearScreen();
                    }
                }
                else if (loginOption == "2") // sign in page
                {
                    string name;
                    string password;
                    string role;
                    Console.Clear();
                    topHeader();
                    signInHeader();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("   \t\t\t\t\t\t\t\t\t Enter your Name: ");
                    name = Console.ReadLine();
                    Console.Write("   \t\t\t\t\t\t\t\t\t Enter your Password: ");
                    password = Console.ReadLine();
                    role = SignIn(name, password, users, passwords, roles, ref usersCount);
                    if (role == "User" || role == "user")
                    {
                        Console.Clear();
                        userInterface(products, brands, quantity, prices, ref productsCount, ref del, feedbackCount, ref feedbackiteration, passwords, ref usersCount);
                        

                        
                    }
                    else if (role == "undefined")
                    {
                        Console.WriteLine("   \t\t\t\t\t\t\t\t\t You Entered wrong Credentials");
                        clearScreen();
                    }
                }
                else if (loginOption == "3") // sign up page
                {
                    string name;
                    string password;
                    string role;
                    Console.Clear();
                    topHeader();
                    signUpHeader();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("   \t\t\t\t\t\t\t\t\t Enter your Name: ");
                    name = Console.ReadLine();
                    Console.Write("   \t\t\t\t\t\t\t\t\t Enter your Password: ");
                    password = Console.ReadLine();
                    Console.Write("   \t\t\t\t\t\t\t\t\t Enter your Role: ");
                    role = Console.ReadLine();
                    bool isValid = SignUp(name, password, role, users, passwords, roles, ref usersCount, userArrSize);
                    if (isValid)
                    {
                        Console.WriteLine("   \t\t\t\t\t\t\t\t\t Successfully signed up! ");
                        clearScreen();

                    }
                    if (!isValid)
                    {
                        Console.WriteLine("   \t\t\t\t\t\t\t\t\t Sign-up unsuccessful.!");
                        clearScreen();
                    }


                }
                else if(loginOption == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("   \t\t\t\t\t\t\t\t\t Inavlid Choice");
                    clearScreen();
                }
            }
        }
        static string SignIn(string name, string password, string[] users, string[] passwords, string[] roles, ref int usersCount)
        {
            for (int index = 0; index < usersCount; index++)
            {
                if (users[index] == name && passwords[index] == password) // check username ane password
                {
                    return roles[index];
                }
            }
            return "undefined";
        }
        static bool SignUp(string name, string password, string role, string[] users, string[] passwords, string[] roles, ref int usersCount, int userArrSize)
        {
            bool isPresent = false;

            for (int index = 0; index < usersCount; index++)
            {
                if (users[index] == name && passwords[index] == password)
                {
                    isPresent = true;
                    break;
                }
            }
            if (isPresent == true)
            {
                return false;
            }
            else if (usersCount < userArrSize)
            {
                users[usersCount] = name;
                passwords[usersCount] = password;
                roles[usersCount] = role;
                usersCount++;
                return true;
            }
            else
            {
                return false;
            }
        }
        static void clearScreen()
        {
            Console.WriteLine();
            Console.WriteLine(" \t\t\t\t\t\t\t\t\t Press Any Key to Continue..");
            Console.ReadKey();
            Console.Clear();
        }

        static string loginMenu()
        {
            string option;

            Console.WriteLine("   \t\t\t\t\t\t\t\t\t $$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t $$                      $$");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t $$    1. Admin Login.   $$");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t $$    2. Sign In.       $$");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t $$    3. Sign Up.       $$");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t $$    4. Exit.          $$");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t $$                      $$");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t $$$$$$$$$$$$$$$$$$$$$$$$$$");


            Console.WriteLine();
            Console.Write("   \t\t\t\t\t\t\t\t\t Enter the Option Number: ");
            option = Console.ReadLine();
            return option;
        }
        static void topHeader()
        {
            Console.Clear();
            Console.WriteLine(@"             /$$$$$$$$ /$$                       /$$                                   /$$                            /$$$$$$  /$$                                ");
            Console.WriteLine(@"            | $$_____/| $$                      | $$                                  |__/                           /$$__  $$| $$                                ");
            Console.WriteLine(@"            | $$      | $$  /$$$$$$   /$$$$$$$ /$$$$$$    /$$$$$$   /$$$$$$  /$$$$$$$  /$$  /$$$$$$$  /$$$$$$$      | $$  \__/| $$$$$$$   /$$$$$$   /$$$$$$       ");
            Console.WriteLine(@"            | $$$$$   | $$ /$$__  $$ /$$_____/|_  $$_/   /$$__  $$ /$$__  $$| $$__  $$| $$ /$$_____/ /$$_____/      |  $$$$$$ | $$__  $$ /$$__  $$ /$$__  $$      ");
            Console.WriteLine(@"            | $$__/   | $$| $$$$$$$$| $$        | $$    | $$  \__/| $$  \ $$| $$  \ $$| $$| $$      |  $$$$$$        \____  $$| $$  \ $$| $$  \ $$| $$  \ $$      ");
            Console.WriteLine(@"            | $$      | $$| $$_____/| $$        | $$ /$$| $$      | $$  | $$| $$  | $$| $$| $$       \____  $$       /$$  \ $$| $$  | $$| $$  | $$| $$  | $$      ");
            Console.WriteLine(@"            | $$$$$$$$| $$|  $$$$$$$|  $$$$$$$  |  $$$$/| $$      |  $$$$$$/| $$  | $$| $$|  $$$$$$$ /$$$$$$$/      |  $$$$$$/| $$  | $$|  $$$$$$/| $$$$$$$/      ");
            Console.WriteLine(@"            |________/|__/ \_______/ \_______/   \___/  |__/       \______/ |__/  |__/|__/ \_______/|_______/        \______/ |__/  |__/ \______/ | $$____/       ");
            Console.WriteLine(@"                                                                                                                                                  | $$            ");
            Console.WriteLine(@"                                                                                                                                                  | $$            ");
            Console.WriteLine(@"                                                                                                                                                  |__/            ");
            Console.WriteLine(@"           $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$       ");
            Console.WriteLine();
            Console.WriteLine();
        }


        static void adminHeader()
        {
            Console.Clear();
            topHeader();
            Console.WriteLine(@"                                                                 _           _          _                 _         ");
            Console.WriteLine(@"                                                        /\      | |         (_)        | |               (_)          ");
            Console.WriteLine(@"                                                       /  \   __| |_ __ ___  _ _ __    | |     ___   __ _ _ _ __       ");
            Console.WriteLine(@"                                                      / /\ \ / _` | '_ ` _ \| | '_ \   | |    / _ \ / _` | | '_ \                ");
            Console.WriteLine(@"                                                     / ____ \ (_| | | | | | | | | | |  | |___| (_) | (_| | | | | |    ");
            Console.WriteLine(@"                                                    /_/    \_\__,_|_| |_| |_|_|_| |_|  |______\___/ \__, |_|_| |_|     ");
            Console.WriteLine(@"                                                                                                     __/ |             ");
            Console.WriteLine(@"                                                                                                    |___/               ");
            Console.WriteLine("                                                   ---------------------------------------------------------------");
        }

        static void signInHeader()
        {
            Console.WriteLine(@"                                                                     _____ _                 _____            ");
            Console.WriteLine(@"                                                                    / ____(_)               |_   _|           ");
            Console.WriteLine(@"                                                                   | (___  _  __ _ _ __       | |  _ __       ");
            Console.WriteLine(@"                                                                    \___ \| |/ _` | '_ \      | | | '_ \      ");
            Console.WriteLine(@"                                                                    ____) | | (_| | | | |    _| |_| | | |     ");
            Console.WriteLine(@"                                                                   |_____/|_|\__, |_| |_|   |_____|_| |_|     ");
            Console.WriteLine(@"                                                                              __/ |                           ");
            Console.WriteLine(@"                                                                             |___/                            ");
            Console.WriteLine("                                                                  ----------------------------------------");
        }
        static void signUpHeader()
        {
            Console.WriteLine(@"                                                                      _____ _                 _    _            ");
            Console.WriteLine(@"                                                                     / ____(_)               | |  | |           ");
            Console.WriteLine(@"                                                                    | (___  _  __ _ _ __     | |  | |_ __       ");
            Console.WriteLine(@"                                                                     \___ \| |/ _` | '_ \    | |  | | '_ \      ");
            Console.WriteLine(@"                                                                     ____) | | (_| | | | |   | |__| | |_) |     ");
            Console.WriteLine(@"                                                                    |_____/|_|\__, |_| |_|    \____/| .__/      ");
            Console.WriteLine(@"                                                                               __/ |                | |         ");
            Console.WriteLine(@"                                                                              |___/                 |_|         ");
            Console.WriteLine("                                                                     ---------------------------------------");
        }
        static int adminInterface(string[] products, string[] brands, int[] quantity, float[] prices, ref int productsCount, ref int del, string[] feedbackCount, ref int feedbackiteration, ref string adminPassword)
        {
            string adminOption = "0";
            while (adminOption != "9")
            {

                topHeader();
                adminOption = adminPage();
                if (adminOption == "1")
                {
                    viewShopProducts(products, brands, quantity, prices, ref productsCount, ref del);
                    clearScreen();
                }
                else if (adminOption == "2")
                {
                    viewShopProducts(products, brands, quantity, prices, ref productsCount, ref del);
                    addProduct(products, brands, quantity, prices, ref productsCount);
                    clearScreen();
                }
                else if (adminOption == "3")
                {
                    viewShopProducts(products, brands, quantity, prices, ref productsCount, ref del);
                    deleteOldItem(products, brands, quantity, prices, ref productsCount);
                    clearScreen();
                }
                else if (adminOption == "4")
                {
                    viewShopProducts(products, brands, quantity, prices, ref productsCount, ref del);
                    updateProduct(products, brands, quantity, prices, ref productsCount);
                    clearScreen();
                }
                else if (adminOption == "5")
                {
                    viewRevenue(prices, quantity, ref productsCount);
                    clearScreen();
                }
                else if (adminOption == "6")
                {
                    viewTopSellingProducts(products, quantity, ref productsCount);
                    clearScreen();
                }
                else if (adminOption == "7")
                {
                    viewFeedback(feedbackCount, ref feedbackiteration);
                    clearScreen(); ;
                }
                else if (adminOption == "8")
                {
                    changePassword(ref adminPassword);
                    clearScreen();
                }
                else if (adminOption == "9")
                {
                    return 0;
                }
                else
                {
                    Console.WriteLine("   \t\t\t\t\t\t\t\t\t  Inavlid Choice");
                    clearScreen();
                }
            }
            return 0;
        }


        static int userInterface(string[] products, string[] brands, int[] quantity, float[] prices, ref int productsCount, ref int del, string[] feedbackCount, ref int feedbackiteration, string[] passwords, ref int usersCount)
        {
            int cartCount = 0;
            int maxCartSize = 10;
            string[] cartProducts = new string[maxCartSize];
            string[] cartBrands = new string[maxCartSize];
            int[] cartQuantities = new int[maxCartSize];
            float[] cartPrices = new float[maxCartSize];
            float totalAmount = 0.0F;
            string userOption = "0";

            //  loadProducts(products, brands,  quantity, prices , productsCount, file1);
            while (userOption != "8")
            {
                topHeader();
                userOption = userPage();
                if (userOption == "1")
                {

                    viewShopProducts(products, brands, quantity, prices, ref productsCount, ref del);
                    clearScreen();
                }
                else if (userOption == "2")
                {
                    viewShopProducts(products, brands, quantity, prices, ref productsCount, ref del);
                    addProductToCart(products, brands, prices, quantity, ref productsCount, cartQuantities, ref cartCount, cartProducts, cartPrices, ref maxCartSize);
                    clearScreen();
                }
                else if (userOption == "3")
                {
                    viewCart(products, brands, quantity, prices, ref cartCount, cartProducts, cartPrices, cartQuantities);
                    clearScreen();
                }
                else if (userOption == "4")
                {
                    viewCart(products, brands, quantity, prices, ref cartCount, cartProducts, cartPrices, cartQuantities);
                    removeProductFromCart(ref cartCount, cartProducts, cartPrices, cartQuantities, products, prices);
                    clearScreen();
                }
                else if (userOption == "5")
                {
                    viewCart(products, brands, quantity, prices, ref cartCount, cartProducts, cartPrices, cartQuantities);
                    generateBill(products, cartPrices, cartQuantities, ref cartCount, cartProducts);
                    clearScreen();
                }
                else if (userOption == "6")
                {
                    feedbackCount[feedbackiteration] = feedback();
                    feedbackiteration++;
                    clearScreen();
                }
                else if (userOption == "7")
                {
                    changePasswordOfUser(passwords, ref usersCount);
                    clearScreen();
                }
                else if (userOption == "8")
                {
                    return 0;
                }
                else
                {
                    Console.WriteLine("   \t\t\t\t\t\t\t\t\t Inavlid Choice");
                    clearScreen();
                }

            }
            return 0;
        }


        // / user menu
        static string userPage()
        {
            string userChoice;
            Console.WriteLine(@"                                                             _    _                   __  __                       ");
            Console.WriteLine(@"                                                            | |  | |                 |  \/  |                      ");
            Console.WriteLine(@"                                                            | |  | |___  ___ _ __    | \  / | ___ _ __  _   _      ");
            Console.WriteLine(@"                                                            | |  | / __|/ _ \ '__|   | |\/| |/ _ \ '_ \| | | |     ");
            Console.WriteLine(@"                                                            | |__| \__ \  __/ |      | |  | |  __/ | | | |_| |     ");
            Console.WriteLine(@"                                                             \____/|___/\___|_|      |_|  |_|\___|_| |_|\__,_|     ");
            Console.WriteLine("                                                           ------------------------------------------------- ");
            Console.WriteLine();
            Console.WriteLine("    \t\t\t\t\t\t\t\t Select one of the following options....                                                                    ");
            Console.WriteLine();

            Console.WriteLine("    \t\t\t\t\t\t\t\t 1. View Products of Shop.                            ");
            Console.WriteLine("    \t\t\t\t\t\t\t\t 2. Add Products to Cart.                             ");
            Console.WriteLine("    \t\t\t\t\t\t\t\t 3. View Cart.                                        ");
            Console.WriteLine("    \t\t\t\t\t\t\t\t 4. Remove Products from Cart.                        ");
            Console.WriteLine("    \t\t\t\t\t\t\t\t 5. Display bill.                                     ");
            Console.WriteLine("    \t\t\t\t\t\t\t\t 6. Feedback.                                         ");
            Console.WriteLine("    \t\t\t\t\t\t\t\t 7. Change password                                   ");
            Console.WriteLine("    \t\t\t\t\t\t\t\t 8. Log out                                           ");
            Console.Write("    \t\t\t\t\t\t\t\t Enter your choice: ");
            userChoice = Console.ReadLine();
            return userChoice;
        }

        static void viewCart(string[] products, string[] brands, int[] quantity, float[] prices, ref int cartCount, string[] cartProducts, float[] cartPrices, int[] cartQuantities)
        {
            Console.Clear();
            topHeader();

            if (cartCount == 0)
            {
                Console.WriteLine(" \t\t\t\t\t\t\t Your cart is empty.");
            }
            else
            {
                Console.WriteLine("  \t\t\t\t\t\t\t\t                     Your Cart:");
                Console.WriteLine("  \t\t\t\t\t\t\t\t                    ***********\n");
                Console.WriteLine("\t\t\t\t\t\t\t{0,-5}{1,-20}{2,-20}{3,-15}{4,-15}", "No.", "Products Name", "Brands", "Quantities", "Prices of Single Product");
                Console.WriteLine();

                for (int i = 0; i < cartCount; i++)
                {
                    // Convert product index from string to int using int.TryParse
                    int productIndex;
                    if (int.TryParse(cartProducts[i], out productIndex))
                    {
                        Console.WriteLine(" \t\t\t\t\t\t\t{0,-5}{1,-20}{2,-20}{3,-15}{4,-15}",
                                          i + 1,
                                          products[productIndex - 1],
                                          brands[productIndex - 1],
                                          cartQuantities[i],
                                          cartPrices[i]);
                    }
                    else
                    {
                        Console.WriteLine("Error parsing product index for item {0}.", i + 1);
                    }
                }
            }
        }


        static void generateBill(string[] products, float[] cartPrices, int[] cartQuantities, ref int cartCount, string[] cartProducts)
        {
            Console.Clear();
            topHeader();
            if (cartCount == 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" \t\t\t\t\t\t\t Your cart is empty. No bill generated.");
            }
            else
            {
                Console.WriteLine(" \t\t\t\t\t\t\t ------------------- Your Cart Bill -------------------\n");
                Console.WriteLine(string.Format(" \t\t\t\t\t\t\t{0,-30}{1,-15}{2,-20}", "Product", "Quantity", "Total Price"));
                Console.WriteLine(" \t\t\t\t\t\t\t --------------------------------------------------------\n");

                float totalAmount = 0.0F;

                for (int i = 0; i < cartCount; i++)
                {
                    int productIndex = int.Parse(cartProducts[i]) - 1;
                    Console.WriteLine($" \t\t\t\t\t\t\t {products[productIndex],-30}{cartQuantities[i],-15}{cartPrices[i],-20}");
                    totalAmount += cartPrices[i];
                }
                Console.WriteLine(" \t\t\t\t\t\t\t --------------------------------------------------------\n");
                Console.WriteLine(" \t\t\t\t\t\t\t Total Amount: " + totalAmount + "\n");
                Console.WriteLine(" \t\t\t\t\t\t\t Thank you for shopping with us...!");
            }
        }

        static string feedback()
        {
            clearScreen();
            topHeader();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" \t\t\t\t\t\t\t\t\t     Feedback ");
            Console.WriteLine(" \t\t\t\t\t\t\t\t\t    **********");
            Console.WriteLine();
            Console.WriteLine();
            string comment;
            Console.Write(" \t\t\t\t\t\t\t\t Enter your feedback about shop: ");
            comment = Console.ReadLine();
            return comment;
        }
        static void changePasswordOfUser(string[] passwords, ref int usersCount)
        {
            clearScreen();
            topHeader();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" \t\t\t\t\t\t\t\t\t     Change Password");
            Console.WriteLine(" \t\t\t\t\t\t\t\t\t    *****************");
            Console.WriteLine();
            Console.WriteLine();
            string currentpass;
            Console.Write(" \t\t\t\t\t\t\t\t Enter the current password: ");
            currentpass = Console.ReadLine();

            int index = 0;
            for (int i = 0; i < usersCount; i++)
            {
                if (currentpass == passwords[i])
                {
                    index = i;
                    string newpass;
                    Console.Write(" \t\t\t\t\t\t\t\t Enter the new password: ");
                    newpass = Console.ReadLine();
                    passwords[index] = newpass;

                    Console.WriteLine(" \t\t\t\t\t\t\t\t Your password has been changed successfully!");
                }
                else
                {
                    Console.WriteLine(" \t\t\t\t\t\t\t\t Wrong Curent Password..");
                }
            }
        }
        static string adminPage()
        {
            string adminChoice;
            Console.WriteLine(@"                                                                         _           _         __  __                       ");
            Console.WriteLine(@"                                                                /\      | |         (_)       |  \/  |                      ");
            Console.WriteLine(@"                                                               /  \   __| |_ __ ___  _ _ __   | \  / | ___ _ __  _   _      ");
            Console.WriteLine(@"                                                              / /\ \ / _` | '_ ` _ \| | '_ \  | |\/| |/ _ \ '_ \| | | |     ");
            Console.WriteLine(@"                                                             / ____ \ (_| | | | | | | | | | | | |  | |  __/ | | | |_| |     ");
            Console.WriteLine(@"                                                            /_/    \_\__,_|_| |_| |_|_|_| |_| |_|  |_|\___|_| |_|\__,_|     ");
            Console.WriteLine();
            Console.WriteLine("                                                              -----------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t Select one of the following options....    ");
            Console.WriteLine();
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t 1. View Shop Products.                  ");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t 2. Add a New Products in Shop.          ");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t 3. Delete a Products in Shop.           ");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t 4. Update products of Shop.             ");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t 5. View Revenue of Shop.                ");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t 6. View Top Selling Products in Shop.   ");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t 7. View feedback.   ");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t 8. Change password.   ");
            Console.WriteLine("   \t\t\t\t\t\t\t\t\t 9. Log Out.                         ");
            Console.WriteLine();
            Console.Write("   \t\t\t\t\t\t\t\t\t Enter your choice: ");
            adminChoice = Console.ReadLine();
            return adminChoice;
        }

        static void viewShopProducts(string[] products, string[] brands, int[] quantity, float[] prices, ref int productsCount, ref int del)
        {
            Console.Clear();
            topHeader();
            Console.WriteLine("                                                                                View Products    ");
            Console.WriteLine("                                                                               ***************   ");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t\" {0,-5}{1,-20}{2,-20}{3,-15}{4,-15}", "No.", "Products Name", "Brands", "Quantity", "Prices");
            Console.WriteLine();

            for (int i = 0; i < productsCount; i++)
            {
                if (quantity[i] > 0)
                {
                    Console.WriteLine($"\t\t\t\t\t\t\t{i + 1,-5}{products[i],-20}{brands[i],-20}{quantity[i],-15}{prices[i],-15}");

                }
            }
        }

        static void addProduct(string[] products, string[] brands, int[] quantity, float[] prices, ref int productsCount)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                                               Add a new product");
            Console.WriteLine("                                                                              *******************");
            Console.WriteLine();
            string newProduct;
            string newBrand;
            int newQuantity;
            float newPrice;
            if (productsCount < 100)
            {
                Console.Write("  \t\t\t\t\t\t\t\t Enter the name of the new product: ");
                newProduct = Console.ReadLine();
                Console.Write("  \t\t\t\t\t\t\t\t Enter the brand of the new product: ");
                newBrand = Console.ReadLine();
                Console.Write("  \t\t\t\t\t\t\t\t Enter the quantity of the new product: ");
                newQuantity = int.Parse(Console.ReadLine());
                Console.Write("  \t\t\t\t\t\t\t\t Enter the price of the new product: ");
                newPrice = float.Parse(Console.ReadLine());
                products[productsCount] = newProduct;
                brands[productsCount] = newBrand;
                quantity[productsCount] = newQuantity;
                prices[productsCount] = newPrice;
                productsCount++;
            }
            else
            {
                Console.WriteLine("  \t\t\t\t\t\t\t\t Product limit reached. Cannot add more products.");
            }
        }

        static void deleteOldItem(string[] products, string[] brands, int[] quantity, float[] prices, ref int productsCount)
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("                                                                             Delete a  product");
            Console.WriteLine("                                                                            *******************");
            Console.WriteLine();

            int productIndex;

            Console.Write("  \t\t\t\t\t\t\t\t Enter the product index you want to delete or 0 to finish: ");
            productIndex = int.Parse(Console.ReadLine());

            while (productIndex != 0 && productIndex >= 1 && productIndex <= productsCount)
            {
                if (products[productIndex - 1] != "")
                {
                    // Shift elements to fill the gap
                    for (int i = productIndex - 1; i < productsCount - 1; i++)
                    {
                        products[i] = products[i + 1];
                        brands[i] = brands[i + 1];
                        quantity[i] = quantity[i + 1];
                        prices[i] = prices[i + 1];
                    }

                    // Clear the last element (since it's now duplicated)
                    products[productsCount - 1] = "";
                    brands[productsCount - 1] = "";
                    quantity[productsCount - 1] = 0;
                    prices[productsCount - 1] = 0.0F;

                    // Decrease the product count
                    productsCount--;

                    Console.WriteLine("  \t\t\t\t\t\t\t\t Product deleted.");
                }
                else
                {
                    Console.WriteLine("  \t\t\t\t\t\t\t\t Sorry, the product at index " + productIndex + " is not available.");
                }


                Console.Write("  \t\t\t\t\t\t\t\t Enter another product index or 0 to finish: ");
                productIndex = int.Parse(Console.ReadLine());
            }
        }



        static void updateProduct(string[] products, string[] brands, int[] quantity, float[] prices, ref int productsCount)
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("                                                                               Update Product");
            Console.WriteLine("                                                                              ***************");
            Console.WriteLine();

            int productIndex;
            Console.Write("  \t\t\t\t\t\t\t\t Enter the product index you want to update or 0 to finish: ");
            productIndex = int.Parse(Console.ReadLine());

            string attributeType;
            Console.Write("  \t\t\t\t\t\t\t\t Enter attribute type you want to update (Prices/Brands/Quantities): ");
            attributeType = Console.ReadLine();

            while (productIndex != 0 && productIndex >= 1 && productIndex <= productsCount)
            {
                if (products[productIndex - 1] != "")
                {
                    if (attributeType == "prices")

                    {
                        Console.WriteLine("  \t\t\t\t\t\t\t\t Current " + attributeType + ": " + prices[productIndex - 1]);
                        Console.Write("  \t\t\t\t\t\t\t\t Enter new " + attributeType + ": ");
                        prices[productIndex - 1] = int.Parse(Console.ReadLine());
                    }
                    else if (attributeType == "brands")
                    {
                        Console.WriteLine("  \t\t\t\t\t\t\t\t Current " + attributeType + ": " + brands[productIndex - 1]);
                        Console.Write("  \t\t\t\t\t\t\t\t Enter new " + attributeType + ": ");
                        brands[productIndex - 1] = Console.ReadLine();
                    }
                    else if (attributeType == "quantities")
                    {
                        Console.WriteLine("  \t\t\t\t\t\t\t\t Current " + attributeType + ": " + quantity[productIndex - 1]);
                        Console.Write("  \t\t\t\t\t\t\t\t Enter new " + attributeType + ": ");
                        quantity[productIndex - 1] = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("  \t\t\t\t\t\t\t  Invalid ");
                    }
                    Console.Write("  \t\t\t\t\t\t\t\t Enter the next product index you want to update or 0 to finish: ");
                    productIndex = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("  \t\t\t\t\t\t\t\t Sorry, the product at index " + productIndex + " is not available.");
                    Console.Write("  \t\t\t\t\t\t\t\t Enter another product index or 0 to finish: ");
                    productIndex = int.Parse(Console.ReadLine());
                }
            }
        }
        static void viewFeedback(string[] feedbackCount, ref int feedbackiteration)
        {
            Console.Clear();
            topHeader();

            Console.WriteLine("                                                                               View Feedback ");
            Console.WriteLine("                                                                              ***************");
            int count = 0;
            for (int i = 0; i < feedbackiteration; i++)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                                                     Feedback from the user is: " + feedbackCount[i]);
                Console.WriteLine();
                Console.WriteLine();
                count++;
            }
        }
        static void viewRevenue(float[] prices, int[] quantity, ref int productsCount)

        {
            Console.Clear();
            topHeader();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("                                                                                  View Revenue");
            Console.WriteLine("                                                                                 **************");
            Console.WriteLine();
            float totalRevenue = 0.0F;
            // Calculate total revenue
            for (int i = 0; i < productsCount; i++)
            {
                totalRevenue += prices[i] * quantity[i];
            }
            Console.WriteLine();
            Console.WriteLine("                                                                           Total Revenue: $" + totalRevenue);
            Console.WriteLine();
            Console.WriteLine();
        }
        static void viewTopSellingProducts(string[] products, int[] quantity, ref int productsCount)
        {
            Console.Clear();
            topHeader();
            Console.WriteLine("                                                                              View Top Selling Products");
            Console.WriteLine("                                                                             ***************************   ");
            Console.WriteLine();
            int[] tempQuantity = new int[100];  // Temporary array to store quantity values
            for (int i = 0; i < productsCount; i++)
            {
                tempQuantity[i] = quantity[i];
            }
            Console.WriteLine("                                                                         No.  Products Name\tQuantity Sold");
            Console.WriteLine();

            // Display the top-selling products
            for (int i = 0; i < productsCount; i++)
            {
                int maxIndex = 0;

                // Find the product with the maximum quantity
                for (int j = 1; j < productsCount; j++)
                {
                    if (tempQuantity[j] > tempQuantity[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                // Display the product information
                if (tempQuantity[maxIndex] > 0)
                {
                    Console.WriteLine($"                                                                         {i + 1,-5}{products[maxIndex],-20}{tempQuantity[maxIndex],-15}");
                    tempQuantity[maxIndex] = 0;  // Set quantity to 0 after displaying to avoid duplicates
                }
            }
        }

        static void addProductToCart(string[] products, string[] brands, float[] prices, int[] quantity, ref int productsCount, int[] cartQuantities, ref int cartCount, string[] cartProducts, float[] cartPrices, ref int maxCartSize)
        {
            int choice;
            int quantityChoice;
            Console.WriteLine();
            Console.WriteLine(" \t\t\t\t\t\t\t\t\t     Add products                                   ");
            Console.WriteLine(" \t\t\t\t\t\t\t\t\t    **************                                         ");
            Console.WriteLine();
            Console.Write("   \t\t\t\t\t\t\t Enter the product number you want to add to your cart or 0 to finish: ");
            choice = int.Parse(Console.ReadLine());

            while (choice != 0 && cartCoucnt < maxCartSize)
            {
                if (choice >= 1 && choice <= productsCount)
                {
                    Console.Write("   \t\t\t\t\t\t\t Enter the quantity for this product: ");
                    quantityChoice = int.Parse(Console.ReadLine());

                    if (quantityChoice > 0 && quantityChoice <= quantity[choice - 1])
                    {
                        // Adjust the index to access arrays correctly (zero-indexed)
                        int adjustedIndex = choice - 1;

                        // Update the quantity in the main product list
                        quantity[adjustedIndex] -= quantityChoice;

                        // Convert product index from int to string using std::to_string
                        cartProducts[cartCount] = choice.ToString();
                        cartPrices[cartCount] = prices[adjustedIndex] * quantityChoice;
                        cartQuantities[cartCount] = quantityChoice;
                        cartCount++;

                        Console.WriteLine("   \t\t\t\t\t\t\t Product added to your cart.");
                    }
                    else
                    {
                        Console.WriteLine("   \t\t\t\t\t\t\t Invalid quantity choice. Please enter a valid quantity.");
                    }
                }
                else
                {
                    Console.WriteLine("   \t\t\t\t\t\t\t Invalid product choice.");
                }

                // Display the current cart and prompt for the next product
                Console.Write("   \t\t\t\t\t\t\t Enter the next product number you want to add to your cart or enter 0 to finish: ");
                choice = int.Parse(Console.ReadLine());
            }

            if (cartCount >= maxCartSize)
            {
                Console.WriteLine("   \t\t\t\t\t\t\t Your cart is full. Remove items before adding more.");
            }
        }

        static void removeProductFromCart(ref int cartCount, string[] cartProducts, float[] cartPrices, int[] cartQuantities, string[] products, float[] prices)
        {
            Console.WriteLine();
            Console.WriteLine(" \t\t\t\t\t\t\t\t\t     Remove products from cart                                   ");
            Console.WriteLine(" \t\t\t\t\t\t\t\t\t    ***************************                                         ");
            Console.WriteLine();

            if (cartCount == 0)
            {
                Console.WriteLine("   \t\t\t\t\t\t\t Your cart is already empty.");
            }
            else
            {
                int choice;
                Console.Write("   \t\t\t\t\t\t\t Enter the numbers of the products you want to remove from your cart or 0 to finish: ");

                while (true)
                {
                    choice = int.Parse(Console.ReadLine());

                    if (choice == 0)
                    {
                        break; // Exit the loop
                    }
                    if (choice >= 1 && choice <= cartCount)
                    {
                        Console.WriteLine("   \t\t\t\t\t\t\t You have " + cartQuantities[choice - 1] + " units of " + products[int.Parse(cartProducts[choice - 1]) - 1] + "in your cart.");
                        Console.Write("   \t\t\t\t\t\t\t How many units do you want to remove: ");
                        int removeQuantity;
                        removeQuantity = int.Parse(Console.ReadLine());

                        if (removeQuantity > 0 && removeQuantity <= cartQuantities[choice - 1])
                        {
                            // Update the quantity and price in the cart
                            cartQuantities[choice - 1] -= removeQuantity;
                            cartPrices[choice - 1] = prices[int.Parse(cartProducts[choice - 1]) - 1] * cartQuantities[choice - 1];


                            // If the quantity becomes 0, remove the product from the cart
                            if (cartQuantities[choice - 1] == 0)
                            {
                                for (int i = choice - 1; i < cartCount - 1; i++)
                                {
                                    cartProducts[i] = cartProducts[i + 1];
                                    cartPrices[i] = cartPrices[i + 1];
                                    cartQuantities[i] = cartQuantities[i + 1];
                                }
                                cartCount--;
                            }

                            Console.WriteLine("   \t\t\t\t\t\t\t Units removed from your cart.");
                        }
                        else
                        {
                            Console.WriteLine("   \t\t\t\t\t\t\t Invalid quantity. Please enter a valid quantity to remove.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("   \t\t\t\t\t\t\t Invalid product choice.");
                    }

                    Console.Write("   \t\t\t\t\t\t\t Enter another product number to remove or 0 to finish: ");
                }
            }
        }


        static void changePassword(ref string adminPassword)
        {

            Console.Clear();
            topHeader();

            Console.WriteLine("                                                                               Change Password ");
            Console.WriteLine("                                                                              *****************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            string currentPassword;
            Console.Write("                                                                            Enter Current Password: ");
            currentPassword = Console.ReadLine();
            if (adminPassword == currentPassword)
            {
                string newpassword;
                Console.Write("                                                                            Enter New Password: ");
                newpassword = Console.ReadLine();
                adminPassword = newpassword;
            }
            else
            {
                Console.WriteLine("                                                                            Wrong Password! ");
                Console.WriteLine("                                                                            Please Enter Correct Current Password.");
                Console.WriteLine();
                Console.WriteLine();
            }
        }


    }
}
