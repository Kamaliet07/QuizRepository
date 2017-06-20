using Quiz.Logging;
using Quiz.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;

namespace Quiz
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

        /// <summary>
        /// Button event to validate the input string is Palindrome
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">route event</param>
        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("Validate button was clicked.");
                // Read string from input file.
                string inputString = txtPelend.Text;
                // Validate string is empty of null
                if (!string.IsNullOrEmpty(inputString))
                {
                    // Get status of Input string is valid Palindrome
                    bool status = PalindromeValidator.PalindromeDeterminer(inputString);
                    if (status)
                    {
                        lblMesage.Content = "True- Input string is Palindrome";
                    }
                    else
                    {
                        lblMesage.Content = "False - Input is not a Palindrome";
                    }
                }
                else
                {
                    MessageBox.Show("Please provide inputs. ");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogMessage(TraceEventType.Error, "The Palindrome Validation failed. The exception has been logged in another message.");
                LogHelper.LogException(string.Empty, ex);
                Environment.Exit(1);
            }
        }
    }
}
