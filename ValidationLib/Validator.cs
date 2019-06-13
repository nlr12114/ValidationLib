using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Murach.Validation

    // this is a validator class that tests for valid data such as is it present 
{
    public static class Validator
	{
		private static string title = "Entry Error";

        /// <summary>
        /// this is a title consturctor... ie getter and setter
        /// </summary>

		public static string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}

        /// <summary>
        ///  this checks to make sure that the textbox contains a value
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>true is something is in the text box</returns>

		public static bool IsPresent(TextBox textBox)
		{
			if (textBox.Text == "")
			{
				MessageBox.Show(textBox.Tag + " is a required field.", Title);
				textBox.Focus();
				return false;
			}
			return true;
		}

        /// <summary>
        /// tests for decimal value in textboxes
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>true if textbox contains a decimal</returns>

        public static bool IsDecimal(TextBox textBox)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be a decimal value.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsInt32(TextBox textBox)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

		public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
		{
			decimal number = Convert.ToDecimal(textBox.Text);
			if (number < min || number > max)
			{
				MessageBox.Show(textBox.Tag + " must be between " + min
					+ " and " + max + ".", Title);
				textBox.Focus();
				return false;
			}
			return true;
		}

        public static bool IsValidEmail(TextBox textBox)
        {
            if (textBox.Text.IndexOf("@") == -1 ||
                 textBox.Text.IndexOf(".") == -1)
            {
                MessageBox.Show(textBox.Tag + " must be a valid email address.",
                    Title);
                textBox.Focus();
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
