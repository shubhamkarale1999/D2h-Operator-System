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

namespace D2h_Operator_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Double Value = 0; // Store Decimal and Int Values if needed
        /* String Operand; // Store the Operand - Will Determine the Maths
         Boolean OperandPressed;

         public MainWindow()
         {
             InitializeComponent();
             ClearAll();
         }
         public void ClearAll()
         {

             ShowNumber = 0;
             Result = 0;
             FirstNumber = 0;
             SecondNumber = 0;
             IsSecond = false;
             IsDecimal = false;
             DecimalValue = 1;
             Operand = string.Empty;
         }

         private double _showNumber;

         public double ShowNumber
         {
             get { return _showNumber; }
             set
             {
                 _showNumber = value;
                 Display.Content = ShowNumber.ToString();
             }
         }

         private double _firstNumber;

         public double FirstNumber
         {
             get { return _firstNumber; }
             set { _firstNumber = value; }
         }

         public double SecondNumber { get; set; }


         public double Result { get; set; }

         public bool IsSecond { get; set; }

         public bool IsDecimal { get; set; }

         public int DecimalValue { get; set; }
         private void Clear_Click(object sender, RoutedEventArgs e)
         {
             ClearAll();
         }

         private void CE_Click(object sender, RoutedEventArgs e)
         {
             if (Operand != "")
             {
                 if (SecondNumber > 0)
                 {
                     SecondNumber = 0;
                     ShowNumber = SecondNumber;
                     IsDecimal = false;
                     DecimalValue = 1;
                 }
                 else
                 {
                     Operand = "";
                     IsSecond = false;
                 }
             }
             else
             {
                 ClearAll();
             }
             Display.Content = "0";
         }

         private void Button_Click(object sender, RoutedEventArgs e)
         {

             Button B = (Button)sender; // Cast Generic Object To Buttom

             //To Get Rid of the Initial 0 in the Display
             if ((Display.Content.ToString() == "0") || (OperandPressed))
             {
                 Display.Content = " ";
             }

             // If Decimal Point already exsists within the Display then do not add another Dedcimal Point
             if (B.Content.ToString() == ",")
             {
                 IsDecimal = true;
             }
             else
             {
                 if (IsSecond)
                 {
                     if (IsDecimal)
                     {
                         DecimalValue *= 10;
                         SecondNumber += double.Parse(B.Content.ToString()) / DecimalValue;
                     }
                     else
                     {
                         SecondNumber *= 10;
                         SecondNumber += double.Parse(B.Content.ToString());

                     }
                     ShowNumber = SecondNumber;
                 }
                 else
                 {
                     if (IsDecimal)
                     {
                         DecimalValue *= 10;
                         FirstNumber += double.Parse(B.Content.ToString()) / DecimalValue;
                     }
                     else
                     {
                         FirstNumber *= 10;
                         FirstNumber += double.Parse(B.Content.ToString());

                     }

                     ShowNumber = FirstNumber;
                 }


             }

             OperandPressed = false;
         }

         private void Button_Operand(object sender, RoutedEventArgs e)
         {
             Button B = (Button)sender; // Cast Obj to Button
                                        //if you already have 1 operand, do the calculation
                                        //Read in and save somewhere the operand
                                        //otherwise set the shownumber to 0, set IsSecond to True


             if (Operand == "")
             {
                 Operand = B.Content.ToString(); // store operand
                 IsSecond = true;
                 ShowNumber = SecondNumber;
                 IsDecimal = false;
                 DecimalValue = 1;
             }
             else
             {
                 DoCalcuation();
                 Operand = B.Content.ToString();
             }



             //To Do the calculaton:
             //Use your Case statement in Button_Equals,  but use FirstNumber and SecondNumber instead of Value 

             // Continously operate on the current results without having to press equals.


         }


         public void DoCalcuation()
         {
             switch (Operand)
             {
                 case "+":
                     Result = FirstNumber + SecondNumber;
                     ResetAfterCalculation();
                     break;
                 case "-":
                     Result = FirstNumber - SecondNumber;
                     ResetAfterCalculation();
                     break;
                 case "×":
                     Result = FirstNumber * SecondNumber;
                     ResetAfterCalculation();
                     break;
                 case "÷":
                     if (SecondNumber == 0)
                     {
                         MessageBox.Show("Kan inte dela med 0");
                     }
                     else
                     {
                         Result = FirstNumber / SecondNumber;
                         ResetAfterCalculation();
                     }
                     break;
                 default:
                     break;
             }

         }

         public void ResetAfterCalculation()
         {
             FirstNumber = Result;
             ShowNumber = Result;
             SecondNumber = 0;
         }
         private void Button_Equals(object sender, RoutedEventArgs e)
         {
             DoCalcuation();
             Operand = "";
         }

         /*Functionality Added to make the calculator work with Keyboard NumberPad
          When the correct Key is detected it will fire off the corresponding button press*/
        /* private void Window_KeyDownPreview(object sender, KeyEventArgs e)
         {
             bool shift = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
             if (shift == true && e.Key == Key.OemQuestion)
             {
                 Multiply.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
             }
             else if (shift == true && e.Key == Key.Oem7)
             {
                 Divide.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
             }

             switch (e.Key)
             {
                 case Key.D0:
                     Zero.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.D1:
                     One.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.D2:
                     Two.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.D3:
                     Three.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.D4:
                     Four.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.D5:
                     Five.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.D6:
                     Six.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.D7:
                     Seven.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.D8:
                     Eight.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.D9:
                     Nine.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.OemPlus:
                     Plus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.OemMinus:
                     Minus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.Multiply:
                     Multiply.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.Divide:
                     Divide.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break; //bool shift  = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift); case Key.D5: return (shift ? '%' : '5');
                 case Key.Enter:
                     Equals.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;
                 case Key.OemComma:
                     Dot.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                     break;*/

     

        int num1 = 0;
        int table = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void tableprinting(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Enetr Number");
            num1 = Convert.ToInt32(number1.Text);
            String ss = "";
            for (int i = 1; i <= 10; i++)
            {
                table = (num1 * i);
                ss = ss + " " + table;


            }
            Tables.Text = ss;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tables_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}



