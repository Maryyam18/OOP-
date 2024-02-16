using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD_3_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Calculator c = null;
            while (true)
            {
                Console.Clear();
                int option;
                Console.WriteLine("Menu....");
                Console.WriteLine("Select one of the following option...");
                Console.WriteLine("1. Create the a Single Object of Calculator");
                Console.WriteLine("2. Change Values of Attributes");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Subtract");
                Console.WriteLine("5. Multiply");
                Console.WriteLine("6. Divide");
                Console.WriteLine("7. Modulo");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    c = new Calculator();
                    Console.WriteLine("Calculator object created");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (option == 2)
                    {
                       if(c != null) { 
                        Console.Clear();
                        Console.Write("Enter the new value for number1: ");
                        float num1 = float.Parse(Console.ReadLine());

                        Console.Write("Enter the new value for number2: ");
                        float num2 = float.Parse(Console.ReadLine());

                        c.number1 = num1;
                        c.number2 = num2;
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }


                    else
                    {
                        Console.WriteLine("Calculator object not created. Please create one first.");
                        Console.WriteLine("Press any key to contibue");
                        Console.ReadKey();
                    }
                 

                }
                else if(option == 3)
                {
                    if (c != null)
                    {
                        Console.WriteLine("Addition: " + c.add());
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("Calculator object not created. Please create one first.");
                        Console.WriteLine("Press any key to contibue");
                        Console.ReadKey();
                    }
                }
                else if (option == 4)
                {
                    if (c != null)
                    {
                        Console.WriteLine("Subtarction: " + c.subtract());
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("Calculator object not created. Please create one first.");
                    }
                }
                else if (option == 5)
                {
                    if (c != null)
                    {
                        Console.WriteLine("Multiplication: " + c.multiply());
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("Calculator object not created. Please create one first.");
                        Console.WriteLine("Press any key to contibue");
                        Console.ReadKey();
                    }
                }
                else if (option == 6)
                {
                    if (c != null)
                    {
                        Console.WriteLine("Division: " + c.divide());
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("Calculator object not created. Please create one first.");
                        Console.WriteLine("Press any key to contibue");
                        Console.ReadKey();
                    }
                }
                else if (option == 7)
                {
                    if (c != null)
                    {
                        Console.WriteLine("Mod: " + c.modulo());
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("Calculator object not created. Please create one first.");
                        Console.WriteLine("Press any key to contibue");
                        Console.ReadKey();
                    }

                }
                else
                {
                    break;
                }
            }


    }
        }
    }

