using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB_6
{
    internal class Authors
    {
        private string Name;
        private string Email;
        private string Gender;

        public Authors(string Name, string Email, string Gender)
        {
            this.Name = Name;
            this.Email = Email;
            this.Gender = Gender;
        }

        public void SetName(string Name)
        {
            this.Name = Name;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetEmail(string Email)
        {
            this.Email = Email;
        }
        public string GetEmail()
        {
            return this.Email;
        }
        public void SetGender(string Gender)
        {
            this.Gender = Gender;
        }
        public string GetGender()
        {
            return this.Gender;
        }
    }
}
