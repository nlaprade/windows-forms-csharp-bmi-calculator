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
using BMICalculator.models;
using System.IO;

namespace BMICalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Loading Text file to read to ListBox.
            LoadTextFile("filereader.txt");
        }

        private bool measurement;
        private void CalculateEvent(object sender, RoutedEventArgs e)
        {
            // Try and Catch for errors if user doesn't input any values and presses "Calculate".
            try
            {
                double bmi = 0;
                // Simple Metric BMI conversion formula.
                if (measurement == true)
                {
                    // If set to metric uses metric converion.
                    double weight, height;
                    weight = double.Parse(WeightTextBox.Text);
                    height = double.Parse(HeightTextBox.Text);
                    // The height / 100 is to make the inputed "CM" to meters to make the conversion easier.
                    height = height / 100;
                    bmi = weight / (height * height);
                }
                else
                {
                    // If set to imperial uses imperial conversion.
                    double weight, height;
                    weight = double.Parse(WeightTextBox.Text);
                    height = double.Parse(HeightTextBox.Text);
                    bmi = weight / (height * height) * 703;
                }

                // This gives the user their BMI number and also the "category".
                string category;
                if (bmi < 18.5)
                {
                    category = "Underweight";
                    BMITextBlock.Text = string.Format($"BMI {bmi:F2} {category}");
                }
                else if (bmi < 24.9)
                {
                    category = "Normal";
                    BMITextBlock.Text = string.Format($"BMI {bmi:F2} {category}");
                }
                else if (bmi < 29.9)
                {
                    category = "Overweight";
                    BMITextBlock.Text = string.Format($"BMI {bmi:F2} {category}");
                }
                else if (bmi < 34.9)
                {
                    category = "Obesity (Class 1)";
                    BMITextBlock.Text = string.Format($"BMI {bmi:F2} {category}");
                }
                else if (bmi < 39.9)
                {
                    category = "Obesity (Class 2)";
                    BMITextBlock.Text = string.Format($"BMI {bmi:F2} {category}");
                }
                else
                {
                    category = "Extreme Obesity";
                    BMITextBlock.Text = string.Format($"BMI {bmi:F2} {category}");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }

        private void ResetButton(object sender, RoutedEventArgs e)
        {
            // Doing a simple set all text boxes to blank when user resets.
            BMITextBlock.Text = "";
            WeightTextBox.Text = "";
            HeightTextBox.Text = "";
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // This radio button is for Metric.
            measurement = true;
            metricW.Content = "Weight: KG";
            metricH.Content = "Height: CM";
        }
        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {
            // This radio button is for Imperial.
            measurement = false;
            metricW.Content = "Weight: LBS";
            metricH.Content = "Height: IN";
        }

        private void LoadTextFile(string filename)
        {
            // Method to load the text file and display it to the listBox.
            // A try and catch are included incase of errors.
            try
            {
                // Creating a string array and using it to create a stack and reversing it.
                string[] lines = File.ReadAllLines(filename);
                Stack<string> myStack = new Stack<string>(lines.Reverse());
                // Simple foreach statement to output the text file contents.
                foreach (var item in myStack)
                {
                    listBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error... {ex.Message}");
            }
        }
    }
}