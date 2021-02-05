using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nainformatykę
{
    public partial class Form1 : Form
    {
        public static string DecimalToArbitrarySystem(long decimalNumber, int radix)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("Base must be bigger than 2 and lower than 36");

            if (decimalNumber == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new String(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }
        public Form1()
        {
            InitializeComponent();
        }



        private void Submit_Click_1(object sender, EventArgs e)
        {
            long i = 0;
            int bases = 0;
            try
            {
                i = Int32.Parse(textBox1.Text);
                bases = Int32.Parse(textBox2.Text);
            }
            catch
            {
                Output.Text = "error";
            }
            finally
            {
                Output.Text = DecimalToArbitrarySystem(i, bases);
            }
        }

    }
}
