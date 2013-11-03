using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.SumNumbersWebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ProcessSumClick(object sender, EventArgs e)
        {
            decimal firstNumber = 0;
            if(!decimal.TryParse(this.tb_firstNumber.Text, out firstNumber)){
                firstNumber = 0;
            }

            decimal secondNumber = 0;
            if (!decimal.TryParse(this.tb_secondNumber.Text, out secondNumber))
            {
                secondNumber = 0;
            }

            decimal sum = firstNumber + secondNumber;
            this.sumResult.Text = sum.ToString();
        }
    }
}