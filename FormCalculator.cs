using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            string text = (sender as Button).Text;

            if (labelDown.Text == "0" && text == "0")
                return;
            else if (labelDown.Text != "0")
                labelDown.Text += text;
            else
                labelDown.Text = text;
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            if (!labelDown.Text.Contains(","))
                labelDown.Text += ",";
            else
                return;
        }

        private void buttonSeparator_Click(object sender, EventArgs e)
        {
            string textSeparator = (sender as Button).Text;

            buttonResult_Click(this, null);

            labelUp.Text = labelDown.Text;
            labelDown.Text = "0";
            labelSeparator.Text = textSeparator;
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            if (labelUp.Text == "" && labelSeparator.Text == "")
                return;

            try
            {
                double firstNum = Convert.ToDouble(labelUp.Text);
                double secondNum = Convert.ToDouble(labelDown.Text);

                if (labelSeparator.Text == "+")
                    labelDown.Text = Convert.ToString(firstNum + secondNum);
                else if (labelSeparator.Text == "-")
                    labelDown.Text = Convert.ToString(firstNum - secondNum);
                else if (labelSeparator.Text == "*")
                    labelDown.Text = Convert.ToString(firstNum * secondNum);
                else if (labelSeparator.Text == "/")
                    labelDown.Text = Convert.ToString(firstNum / secondNum);

                labelUp.Text = "";
                labelSeparator.Text = "";
            } catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения" + ex.Message, "Ошибка!");
                return;
            }
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (labelDown.Text.Length != 1)
                labelDown.Text = labelDown.Text.Substring(0, labelDown.Text.Length - 1);
            else labelDown.Text = "0";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            labelDown.Text = "0";
            labelUp.Text = "";
            labelSeparator.Text = "";
        }

        private void buttonClearDown_Click(object sender, EventArgs e)
        {
            labelDown.Text = "0";
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            if (labelSeparator.Text != "")
                if (labelSeparator.Text == "+")
                    labelSeparator.Text = "-";
                else if (labelSeparator.Text == "-")
                    labelSeparator.Text = "+";
        }
    }
}
