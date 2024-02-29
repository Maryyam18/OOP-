using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            Authors a = new Authors("Maryyam", "m39@gmail.com", "female");
            Authors a1 = new Authors("Ayesha1", "a22@gmail.com", "female");
            List<Authors> authorList = new List<Authors>() { a, a1 };
            Books book = new Books("C#", 500F, authorList);

            book.SetAuthorList(a1);
            book.SetAuthorList(a);
            book.SetBookName(book.GetBookName());

            foreach(Authors author in authorList)
            {
                Console.WriteLine(book.GetBookName()+" "+author.GetName()+" "+author.GetEmail()+" "+author.GetGender());
            }

            Console.ReadLine();

             

        }
    }
}
