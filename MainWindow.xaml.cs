using System;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace TextReplacer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FocusTextbox(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void ReplaceButton_Click(object sender, RoutedEventArgs e)
        {

            // Get Configuration
            Regex separatedBy = new Regex(separatedByTextBox.Text);
            bool useRegex = useRegexCheckBox.IsChecked == true;
            RegexOptions isCaseSensitive = caseSensitiveCheckBox.IsChecked == true ? RegexOptions.None : RegexOptions.IgnoreCase;

            // Get 'Find' and 'Replace'
            string[] find = findTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string[] replace = replaceTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            // Make result equal origin
            resultTextBox.Text = originalTextBox.Text;

            // Run in each 'find' item
            for (int i = 0; i < find.Length; i++)
            {
                // check if not use Regex to escape the regex
                if (!useRegex)
                {
                    find[i] = Regex.Escape(find[i]);
                }

                // Replace
                resultTextBox.Text = Regex.Replace(resultTextBox.Text, find[i], replace[i], isCaseSensitive);
            }
        }
    }
}
