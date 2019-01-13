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
                (this.Owner as MainWindow).txtEditor2.FontStyle = FontStyles.Italic;
                (this.Owner as MainWindow).txtEditor3.FontStyle = FontStyles.Italic;
                (this.Owner as MainWindow).txtEditor4.FontStyle = FontStyles.Italic;
            }
            else
            {
                (this.Owner as MainWindow).txtEditor.FontStyle = FontStyles.Normal;
                (this.Owner as MainWindow).txtEditor2.FontStyle = FontStyles.Normal;
                (this.Owner as MainWindow).txtEditor3.FontStyle = FontStyles.Normal;
                (this.Owner as MainWindow).txtEditor4.FontStyle = FontStyles.Normal;
            }
        }

        private void BoldBox_Click(object sender, RoutedEventArgs e)
        {
            if (BoldBox.IsChecked == true)
            {
                (this.Owner as MainWindow).txtEditor.FontWeight = FontWeights.Bold;
                (this.Owner as MainWindow).txtEditor2.FontWeight = FontWeights.Bold;
                (this.Owner as MainWindow).txtEditor3.FontWeight = FontWeights.Bold;
                (this.Owner as MainWindow).txtEditor4.FontWeight = FontWeights.Bold;
            }
            else
            {
                (this.Owner as MainWindow).txtEditor.FontWeight = FontWeights.Normal;
                (this.Owner as MainWindow).txtEditor2.FontWeight = FontWeights.Normal;
                (this.Owner as MainWindow).txtEditor3.FontWeight = FontWeights.Normal;
                (this.Owner as MainWindow).txtEditor4.FontWeight = FontWeights.Normal;
            }
        }

        private void UnderlinedBox_Click(object sender, RoutedEventArgs e)
        {
            if (UnderlinedBox.IsChecked == true)
            {
                (this.Owner as MainWindow).txtEditor.TextDecorations = TextDecorations.Underline;
                (this.Owner as MainWindow).txtEditor2.TextDecorations = TextDecorations.Underline;
                (this.Owner as MainWindow).txtEditor3.TextDecorations = TextDecorations.Underline;
                (this.Owner as MainWindow).txtEditor4.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                (this.Owner as MainWindow).txtEditor.TextDecorations = null;
                (this.Owner as MainWindow).txtEditor2.TextDecorations = null;
                (this.Owner as MainWindow).txtEditor3.TextDecorations = null;
                (this.Owner as MainWindow).txtEditor4.TextDecorations = null;
            }
        }

        private void FontSizeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (this.Owner as MainWindow).txtEditor.FontSize = Convert.ToDouble(FontSizeBox.SelectedItem);
            (this.Owner as MainWindow).txtEditor2.FontSize = Convert.ToDouble(FontSizeBox.SelectedItem);
            (this.Owner as MainWindow).txtEditor3.FontSize = Convert.ToDouble(FontSizeBox.SelectedItem);
            (this.Owner as MainWindow).txtEditor4.FontSize = Convert.ToDouble(FontSizeBox.SelectedItem);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FontFamilyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var font = FontFamilyBox.SelectedValue.ToString();
            (this.Owner as MainWindow).txtEditor.FontFamily = new FontFamily(font);
            (this.Owner as MainWindow).txtEditor2.FontFamily = new FontFamily(font);
            (this.Owner as MainWindow).txtEditor3.FontFamily = new FontFamily(font);
            (this.Owner as MainWindow).txtEditor4.FontFamily = new FontFamily(font);
        }
    }
}
