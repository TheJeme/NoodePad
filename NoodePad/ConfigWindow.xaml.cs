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

namespace NoodePad
{
    /// <summary>
    /// Interaction logic for ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void RadioBlue_Checked(object sender, RoutedEventArgs e)
        {
            (this.Owner as MainWindow).txtEditor.Background = Brushes.DimGray;
        }

        private void RadioRed_Checked(object sender, RoutedEventArgs e)
        {
            (this.Owner as MainWindow).txtEditor.Background = Brushes.Red;
        }
        private void RadioYellow_Checked(object sender, RoutedEventArgs e)
        {
            (this.Owner as MainWindow).txtEditor.Background = Brushes.Yellow;
        }

        private void ItalicBox_Click(object sender, RoutedEventArgs e)
        {
            if (ItalicBox.IsChecked == true)
            {
                (this.Owner as MainWindow).txtEditor.FontStyle = FontStyles.Italic;
            }
            else
            {
                (this.Owner as MainWindow).txtEditor.FontStyle = FontStyles.Normal;
            }
        }

        private void BoldBox_Click(object sender, RoutedEventArgs e)
        {
            if (BoldBox.IsChecked == true)
            {
                (this.Owner as MainWindow).txtEditor.FontWeight = FontWeights.Bold;
            }
            else
            {
                (this.Owner as MainWindow).txtEditor.FontWeight = FontWeights.Normal;
            }
        }

        private void UnderlinedBox_Click(object sender, RoutedEventArgs e)
        {
            if (UnderlinedBox.IsChecked == true)
            {
                (this.Owner as MainWindow).txtEditor.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                (this.Owner as MainWindow).txtEditor.TextDecorations = null;
            }
        }

        private void FontSizeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (this.Owner as MainWindow).txtEditor.FontSize = Convert.ToDouble(FontSizeBox.SelectedItem);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FontFamilyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var font = FontFamilyBox.SelectedValue.ToString();
            (this.Owner as MainWindow).txtEditor.FontFamily = new FontFamily(font);
        }
    }
}
