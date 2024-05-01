using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();


            equalAssignButton.Click += EqualAssignButton_Click;
            decimalButton.Click += DecimalButton_Click;
            percentButton.Click += PercentButton_Click;
            acButton.Click += AcButton_Click;
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {

            double tempNumber;
            if(double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                 resultLabel.Content = tempNumber.ToString();

            }
        
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {

            if (resultLabel.Content.ToString().Contains("."))
            {
                // Do nothing
            } else
            {

                resultLabel.Content = $"{resultLabel.Content}.";

            }
        
        }

        private void EqualAssignButton_Click(object sender, RoutedEventArgs e)
        {

            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {

                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Substraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiplication(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Division(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OperationButton_Click(object sender, RoutedEventArgs e) 
        { 
                if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
                {
                    resultLabel.Content = "0";
              
                }

            if (sender == multiplyButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divideButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == substractionButton)
                selectedOperator = SelectedOperator.Substraction;

        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {

            int selectedValue = int.Parse((sender as Button).Content.ToString());

           

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else 
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }

       

      

      
    }

    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Substraction(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Division(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Diviosn by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                   return 0;
            }

            return n1 / n2;
        }
        public static double Multiplication(double n1, double n2)
        {
            return n1 * n2;
        }
    }

}