using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        static List<string> Commands = new List<string>() { "+", "-", "x", "/", "Sqrt", "=" };
        static List<string> Numbers = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

        public string ResultPlaceHolder { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ResultPlaceHolder = this.HiddenFieldPreviousValue.Value;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.LiteralPreviousValue.Text = ResultPlaceHolder;
        }

        protected void OnCommand(object sender, CommandEventArgs e)
        {
            try
            {
                string commandName = e.CommandName.ToString();

                if (Commands.Contains(commandName))
                {
                    this.ProcessCommand(commandName);
                }
                else if (commandName == "Clear")
                {
                    this.HiddenFieldOperation.Value = string.Empty;
                    this.HiddenFieldPreviousValue.Value = string.Empty;
                    this.TextBoxResult.Text = string.Empty;
                    this.ResultPlaceHolder = string.Empty;
                }
                else if (Numbers.Contains(commandName))
                {
                    this.TextBoxResult.Text += commandName;
                }
                else
                {
                    throw new InvalidOperationException("Invalide operation!");
                }
            }
            catch (InvalidOperationException ex)
            {
                this.ResultPlaceHolder = ex.Message;
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException || ex is ArgumentException || ex is DivideByZeroException)
                {
                    this.ResultPlaceHolder = ex.Message;

                    this.TextBoxResult.Text = string.Empty;
                    this.HiddenFieldOperation.Value = string.Empty;
                    this.HiddenFieldPreviousValue.Value = string.Empty;
                    return;
                }

                throw;
            }
        }

        protected void ProcessCommand(string commandName)
        {
            decimal currentValue = 0;

            if (this.TextBoxResult.Text.Trim() == string.Empty)
            {
                currentValue = 0;
            }
            else if (!decimal.TryParse(this.TextBoxResult.Text, out currentValue))
            {
                throw new ArgumentException("Invalid current value!");
            }

            decimal result = currentValue;

            if (this.HiddenFieldOperation.Value != string.Empty)
            {
                decimal previousValue = 0;
                if (!decimal.TryParse(this.HiddenFieldPreviousValue.Value, out previousValue))
                {
                    throw new ArgumentException("Invalid previous value!");
                }

                string previousOperation = this.HiddenFieldOperation.Value;

                switch (previousOperation)
                {
                    case "+":
                        result = previousValue + currentValue;
                        break;
                    case "-":
                        result = previousValue - currentValue;
                        break;
                    case "x":
                        result = previousValue * currentValue;
                        break;
                    case "/":
                        result = previousValue / currentValue;
                        break;
                    case "Sqrt":
                        break;
                    case "=":
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation!");
                }
            }

            if (commandName == "Sqrt")
            {
                if (result < 0)
                {
                    throw new InvalidOperationException("Invalid operation!");
                }

                result = (decimal)Math.Sqrt((double)result);
            }

            if (commandName == "=" || commandName == "Sqrt")
            {
                this.ResultPlaceHolder = string.Empty;
                this.TextBoxResult.Text = result.ToString();
                this.HiddenFieldOperation.Value = string.Empty;
                this.HiddenFieldPreviousValue.Value = string.Empty;
            }
            else
            {
                this.ResultPlaceHolder = result.ToString();
                this.TextBoxResult.Text = string.Empty;
                this.HiddenFieldOperation.Value = commandName;
                this.HiddenFieldPreviousValue.Value = result.ToString();
            }
        }
    }
}