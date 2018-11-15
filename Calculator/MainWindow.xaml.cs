using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string leftOper = "";
        string rightOper = "";
        string operation = "";
        public MainWindow()
        {
            InitializeComponent();            

            foreach (UIElement c in grid.Children)
            {
                if(c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }            
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            txt2.Text += str;
            txt1.Text += str;

            int number = 0;
            bool result = Int32.TryParse(str, out number);

            if(result == true)
            {
                if (operation == "")
                    leftOper += str;
                rightOper += str;
            }
            else
            {
                if (str == "=")
                {
                    UpDateRightOper();
                    txt2.Text += rightOper;
                    txt1.Text += rightOper;
                    operation = "";
                }
                else if (str == "CE")
                {
                    txt2.Text = "";
                    txt2.Clear();
                    rightOper = "";
                }
                else if (str == "C")
                {
                    txt2.Text = "";
                    txt2.Clear();

                    txt1.Text = "";
                    txt1.Clear();
                    rightOper = "";
                    leftOper = "";
                    operation = "";
                }
                else
                {
                    if(rightOper != "")
                    {
                        UpDateRightOper();
                        leftOper = rightOper;
                        rightOper = "";
                    }
                    operation = str;
                }
            }     

        }

        public void UpDateRightOper()
        {
            int num1 = Int32.Parse(leftOper);
            int num2 = Int32.Parse(rightOper);

            switch(operation)
            {
                case "+":
                    rightOper = (num1 + num2).ToString();
                    break;
                case "-":
                    rightOper = (num1 - num2).ToString();
                    break;
                case "*":
                    rightOper = (num1 * num2).ToString();
                    break;
                case "/":
                    rightOper = (num1 / num2).ToString();
                    break;
            }
        }


    }
}
