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
using Microsoft.Win32;
using System.IO;

namespace NoodePad
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool isDataDirty = false; //If true shows warning before losing work
        string currentPathName = null;
        string currentFileName = null;
        int tabCount = 1;

        private void CommonCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) //Opens ConfigWindow for settings
        {
            var ConfigWin = new ConfigWindow();
            ConfigWin.Owner = this;
            ConfigWin.Show();
        }

        private void NewCommand_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e) //Creates new empty tab
        {
            switch (tabCount)
            {
                case 1:
                    SecondTab.Visibility = Visibility.Visible;
                    tabCount++;
                    break;
                case 2:
                    ThirdTab.Visibility = Visibility.Visible;
                    tabCount++;
                    break;
                case 3:
                    FourthTab.Visibility = Visibility.Visible;
                    tabCount++;
                    break;
            }   
        }

        private void OpenCommand_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e) //Opens file
        {
            var OpenFile = new OpenFileDialog();
            Nullable<bool> Success;
            if (this.isDataDirty)
            {
                string msg = "You have not saved. Do you want to cancel?";
                MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "NoodePad",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    OpenFile.DefaultExt = ".txt";
                    OpenFile.Filter = "Text documents (.txt)|*.txt";
                    Success = OpenFile.ShowDialog();
                    if (Success.HasValue && Success.Value)
                    {
                        var sr = new StreamReader(OpenFile.FileName, Encoding.GetEncoding(1252));
                        currentPathName = OpenFile.FileName;
                        currentFileName = Path.GetFileNameWithoutExtension(OpenFile.FileName);
                        txtEditor.Text = sr.ReadToEnd();
                        FirstTab.Text = currentFileName;
                        isDataDirty = false;
                    }
                }
            }
            else
            {
                OpenFile.DefaultExt = ".txt";
                OpenFile.Filter = "Text documents (.txt)|*.txt";
                Success = OpenFile.ShowDialog();
                if (Success.HasValue && Success.Value)
                {
                    var sr = new StreamReader(OpenFile.FileName, Encoding.GetEncoding(1252));
                    currentPathName = OpenFile.FileName;
                    currentFileName = Path.GetFileNameWithoutExtension(OpenFile.FileName);
                    txtEditor.Text = sr.ReadToEnd();
                    FirstTab.Text = currentFileName;
                    isDataDirty = false;
                }
            }            
        }

        private void SaveCommand_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e) //saves file
        {
            if (currentPathName == null)
            {
                SaveFileDialog dialog = new SaveFileDialog()
                {
                    Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
                };

                if (dialog.ShowDialog() == true)
                {
                    File.WriteAllText(dialog.FileName, txtEditor.Text);
                    currentPathName = dialog.FileName;
                    currentFileName = Path.GetFileNameWithoutExtension(dialog.FileName);
                    FirstTab.Text = currentFileName;
                }
            }
            else
            {
                File.WriteAllText(currentPathName, txtEditor.Text);
            }

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e) //Exits application
        {
            Application.Current.Shutdown();
        }

        private void SaveAsCommand_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, txtEditor.Text);
            }
        }

        private void DatetimeMenuItem_Click(object sender, RoutedEventArgs e) //Inserts current Date and time
        {
            DateTime datenow = DateTime.Now;
            txtEditor.Text += datenow;
        }

        private void UndoCommand_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void RedoCommand_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RedoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void TxtEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            isDataDirty = true;
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) //if text changed it shows messagebox before exit
        {
            if (this.isDataDirty)
            {
                string msg = "You have not saved. Do you want to exit?";
                MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "NoodePad",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
