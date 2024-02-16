using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD_3_Task1
{
    internal class Calculator
    {
        public float number1 { get; set; }
        public float number2 { get; set; }

        public Calculator(float n1 = 10, float n2 = 10)
        {
            number1 = n1;
            number2 = n2;
            
        }
        public float add()
        {
            return number1 + number2;
        }
        public float subtract()
        {
            return number1 - number2;
        }
        public float multiply()
        {
            return number1 * number2;
        }
        public float divide()
        {
            return number1 / number2;
        }
        public float modulo()
        {
           
            return number1 % number2;
        }
    }
}
