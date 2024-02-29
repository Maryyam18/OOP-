using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_6
{
    internal class Books
    {
        private string BookName;
        private float BookPrice;
        private List<Authors> authorList = new List<Authors>();


        public Books(string BookName, float BookPrice, List<Authors> authorList)
        {
            this.BookName = BookName;
            this.BookPrice = BookPrice;

        }

        public void SetBookName(string BookName)
        {
            this.BookName = BookName;
        }
        public string GetBookName()
        {
            return this.BookName;

        }
        public void SetBookPrice(float BookPrice)
        {
            this.BookPrice = BookPrice;
        }
        public float GetBookPrice()
        {
            return this.BookPrice;

        }
        public void SetAuthorList(Authors author)
        {
            authorList.Add(author);
        }
        public List<Authors> GetAuthorList()
        {
            return authorList;
        }


    }
}
