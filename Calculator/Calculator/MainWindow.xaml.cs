using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public List<Equation> history = new List<Equation>(new Equation[100]);

        public class Equation
        {
            public string equation { get; set; }
            public int ID { get; set; }
        }

        double varA;
        double varB;
        string currentSign;
        int historyId = 0;
        public delegate void Delegate();
        bool isMatSignClicked = false;
        Delegate calculate;


        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (textView.Text.Length != 0 && calculate != null)
            {
                varB = double.Parse(textView.Text);

                if (historyId == 100)
                {
                    historyId = 0;
                }
                Equation eq = new Equation();
                eq.equation = varA.ToString() + currentSign + varB.ToString();

                calculate();

                eq.equation += " = " + textView.Text;
                eq.ID = historyId;
                history[historyId] = eq;
                historyId++;
                isMatSignClicked = false;
            }
        }

        public void Add()
        {
            if (textView.Text.Length != 0)
            {
                varA = varA + varB;
                textView.Text = varA.ToString();
            }
        }
        public void Substract()
        {
            if (textView.Text.Length != 0)
            {
                varA = varA - varB;
                textView.Text = varA.ToString();
            }
        }
        public void Multiply()
        {
            if (textView.Text.Length != 0)
            {
                varA = varA * varB;
                textView.Text = varA.ToString();
            }
        }
        public void Divide()
        {
            if (textView.Text.Length != 0)
            {
                if (varB != 0)
                {
                    varA = varA / varB;
                    textView.Text = varA.ToString();
                }
                else
                {
                    throw new DivideByZeroException();
                }
            }
        }
        public void Power()
        {
            if (textView.Text.Length != 0)
            {
                varA = Math.Pow(varA, varB);
                textView.Text = varA.ToString();
            }
        }
        public void Root()
        {
            if (textView.Text.Length != 0)
            {
                varA = Math.Pow(varA, 1.0 / varB);
                textView.Text = varA.ToString();
            }
        }

        private void varButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (isMatSignClicked == false)
            {
                textView.Text = textView.Text + btn.Content.ToString();
                isMatSignClicked = false;
            }
            else
            {
                textView.Text = btn.Content.ToString();
                isMatSignClicked = false;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textView.Clear();
            varA = 0;
            varB = 0;
            currentSign = "";
        }
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            calculate = Add;
            MathSignClicked(sender);
        }
        private void buttonMinus_Click(object sender, EventArgs e)
        {

            if (textView.Text.Length == 0)
            {
                textView.Text = "-";
            }
            else
            {
                calculate = Substract;
                MathSignClicked(sender);
            }
        }

        void MathSignClicked(object sender)
        {
            currentSign = ((Button)sender).Content.ToString();
            if (textView.Text.Length != 0)
            {
                isMatSignClicked = true;
                if (textView.Text[textView.Text.Length - 1] == ',')
                {
                    textView.Text += "0";
                }
                varA = double.Parse(textView.Text);

            }

        }
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            calculate = Multiply;
            MathSignClicked(sender);
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            calculate = Divide;
            MathSignClicked(sender);
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            textView.Text += ",";
        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {
            calculate = Root;
            MathSignClicked(sender);
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            calculate = Power;
            MathSignClicked(sender);
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (textView.Text.Length != 0)
            {
                textView.Text = textView.Text.Remove(textView.Text.Length - 1, 1);
            }

        }

        private void showHistory_Clicked(object sender, RoutedEventArgs e)
        {
            HistoryWindow window = new HistoryWindow(history);
            window.Show();
        }
    }
}
