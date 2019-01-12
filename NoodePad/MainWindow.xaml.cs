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
        string currentFileNameTab1 = null;
        string currentPathNameTab1 = null;
        string currentFileNameTab2 = null;
        string currentPathNameTab2 = null;
        string currentFileNameTab3 = null;
        string currentPathNameTab3 = null;
        string currentFileNameTab4 = null;
        string currentPathNameTab4 = null;

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
                        if (FirstTab.IsSelected == true)
                        {
                            currentPathNameTab1 = OpenFile.FileName;
                            currentFileNameTab1 = Path.GetFileNameWithoutExtension(OpenFile.FileName);
                            txtEditor.Text = sr.ReadToEnd();
                            FirstTabName.Text = currentFileNameTab1;
                            isDataDirty = false;
                        }
                        else if (SecondTab.IsSelected == true)
                        {
                            currentPathNameTab2 = OpenFile.FileName;
                            currentFileNameTab2 = Path.GetFileNameWithoutExtension(OpenFile.FileName);
                            txtEditor2.Text = sr.ReadToEnd();
                            SecondTabName.Text = currentFileNameTab2;
                            isDataDirty = false;
                        }
                        else if (ThirdTab.IsSelected == true)
                        {
                            currentPathNameTab3 = OpenFile.FileName;
                            currentFileNameTab3 = Path.GetFileNameWithoutExtension(OpenFile.FileName);
                            txtEditor3.Text = sr.ReadToEnd();
                            ThirdTabName.Text = currentFileNameTab3;
                            isDataDirty = false;
                        }
                        else if (FourthTab.IsSelected == true)
                        {
                            currentPathNameTab4 = OpenFile.FileName;
                            currentFileNameTab4 = Path.GetFileNameWithoutExtension(OpenFile.FileName);
                            txtEditor4.Text = sr.ReadToEnd();
                            FourthTabName.Text = currentFileNameTab4;
                            isDataDirty = false;
                        }
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
                    if (FirstTab.IsSelected == true)
                    {
                        currentPathNameTab1 = OpenFile.FileName;
                        currentFileNameTab1 = Path.GetFileNameWithoutExtension(OpenFile.FileName);
                        txtEditor.Text = sr.ReadToEnd();
                        FirstTabName.Text = currentFileNameTab1;
                        isDataDirty = false;
                    }
                    else if (SecondTab.IsSelected == true)
                    {
                        currentPathNameTab2 = OpenFile.FileName;
                        currentFileNameTab2 = Path.GetFileNameWithoutExtension(OpenFile.FileName);
                        txtEditor2.Text = sr.ReadToEnd();
                        SecondTabName.Text = currentFileNameTab2;
                        isDataDirty = false;
                    }
                    else if (ThirdTab.IsSelected == true)
                    {
                        currentPathNameTab3 = OpenFile.FileName;
                        currentFileNameTab3 = Path.GetFileNameWithoutExtension(OpenFile.FileName);
                        txtEditor3.Text = sr.ReadToEnd();
                        ThirdTabName.Text = currentFileNameTab3;
                        isDataDirty = false;
                    }
                    else if (FourthTab.IsSelected == true)
                    {
                        currentPathNameTab4 = OpenFile.FileName;
                        currentFileNameTab4 = Path.GetFileNameWithoutExtension(OpenFile.FileName);
                        txtEditor4.Text = sr.ReadToEnd();
                        FourthTabName.Text = currentFileNameTab4;
                        isDataDirty = false;
                    }
                }
            }            
        }

        private void SaveCommand_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e) //saves file
        {
            if (currentPathNameTab1 == null && FirstTab.IsSelected == true || currentPathNameTab2 == null && SecondTab.IsSelected == true ||
                currentPathNameTab3 == null && ThirdTab.IsSelected == true || currentPathNameTab4 == null && FourthTab.IsSelected == true)
            {
                SaveFileDialog dialog = new SaveFileDialog()
                {
                    Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
                };

                if (dialog.ShowDialog() == true)
                {
                    if (FirstTab.IsSelected == true)
                    {
                        File.WriteAllText(dialog.FileName, txtEditor.Text);
                        currentPathNameTab1 = dialog.FileName;
                        currentFileNameTab1 = Path.GetFileNameWithoutExtension(dialog.FileName);
                        FirstTabName.Text = currentFileNameTab1;
                    }
                    else if (SecondTab.IsSelected == true)
                    {
                        currentPathNameTab2 = dialog.FileName;
                        currentFileNameTab2 = Path.GetFileNameWithoutExtension(dialog.FileName);
                        File.WriteAllText(dialog.FileName, txtEditor2.Text);
                        SecondTabName.Text = currentFileNameTab2;
                    }
                    else if (ThirdTab.IsSelected == true)
                    {
                        currentPathNameTab3 = dialog.FileName;
                        currentFileNameTab3 = Path.GetFileNameWithoutExtension(dialog.FileName);
                        File.WriteAllText(dialog.FileName, txtEditor3.Text);
                        ThirdTabName.Text = currentFileNameTab3;
                    }
                    else if (FourthTab.IsSelected == true)
                    {
                        currentPathNameTab4 = dialog.FileName;
                        currentFileNameTab4 = Path.GetFileNameWithoutExtension(dialog.FileName);
                        File.WriteAllText(dialog.FileName, txtEditor4.Text);
                        FourthTabName.Text = currentFileNameTab4;
                    }
                }
            }
            else
            {
                if (FirstTab.IsSelected == true)
                {
                    File.WriteAllText(currentPathNameTab1, txtEditor.Text);
                    FirstTabName.Text = currentFileNameTab1;
                }
                else if (SecondTab.IsSelected == true)
                {
                    File.WriteAllText(currentPathNameTab2, txtEditor2.Text);
                    SecondTabName.Text = currentFileNameTab2;
                }
                else if (ThirdTab.IsSelected == true)
                {
                    File.WriteAllText(currentPathNameTab3, txtEditor3.Text);
                    ThirdTabName.Text = currentFileNameTab3;
                }
                else if (FourthTab.IsSelected == true)
                {
                    File.WriteAllText(currentPathNameTab4, txtEditor4.Text);
                    FourthTabName.Text = currentFileNameTab4;
                }
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
                if (FirstTab.IsSelected == true)
                {
                    File.WriteAllText(dialog.FileName, txtEditor.Text);
                    currentPathNameTab1 = dialog.FileName;
                    currentFileNameTab1 = Path.GetFileNameWithoutExtension(dialog.FileName);
                    FirstTabName.Text = currentFileNameTab1;
                }
                else if (SecondTab.IsSelected == true)
                {
                    currentPathNameTab2 = dialog.FileName;
                    currentFileNameTab2 = Path.GetFileNameWithoutExtension(dialog.FileName);
                    File.WriteAllText(dialog.FileName, txtEditor2.Text);
                    SecondTabName.Text = currentFileNameTab2;
                }
                else if (ThirdTab.IsSelected == true)
                {
                    currentPathNameTab3 = dialog.FileName;
                    currentFileNameTab3 = Path.GetFileNameWithoutExtension(dialog.FileName);
                    File.WriteAllText(dialog.FileName, txtEditor3.Text);
                    ThirdTabName.Text = currentFileNameTab3;
                }
                else if (FourthTab.IsSelected == true)
                {
                    currentPathNameTab4 = dialog.FileName;
                    currentFileNameTab4 = Path.GetFileNameWithoutExtension(dialog.FileName);
                    File.WriteAllText(dialog.FileName, txtEditor4.Text);
                    FourthTabName.Text = currentFileNameTab4;
                }

            }
        }

        private void DatetimeMenuItem_Click(object sender, RoutedEventArgs e) //Inserts current Date and time
        {
            DateTime datenow = DateTime.Now;
            if (FirstTab.IsSelected == true)
            {
                txtEditor.SelectedText += datenow;
            }
            else if (SecondTab.IsSelected == true)
            {
                txtEditor2.SelectedText += datenow;
            }
            else if (ThirdTab.IsSelected == true)
            {
                txtEditor3.SelectedText += datenow;
            }
            else if (FourthTab.IsSelected == true)
            {
                txtEditor4.SelectedText += datenow;
            }
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

        private void DeleteCommand_Execute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (FirstTab.IsSelected == true)
            {
                txtEditor.SelectedText = "";
            }
            else if (SecondTab.IsSelected == true)
            {
                txtEditor2.SelectedText = "";
            }
            else if (ThirdTab.IsSelected == true)
            {
                txtEditor3.SelectedText = "";
            }
            else if (FourthTab.IsSelected == true)
            {
                txtEditor4.SelectedText = "";
            }
        }
    }
}
