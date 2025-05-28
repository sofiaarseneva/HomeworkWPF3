using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace HomeworkWPF3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as string);

            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void fontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textBox != null)
            {
                double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as string));

                textBox.FontSize = fontSize;
            }
        }

        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight == FontWeights.Normal)
            {
                textBox.FontWeight = FontWeights.Bold;
            } 
            else
            {
                textBox.FontWeight = FontWeights.Normal;
            }
        }

        private void italicButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Normal)
            {
                textBox.FontStyle = FontStyles.Italic;
            } else
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }

        private void underlineButton_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations.Count == 0)
            {
                textBox.TextDecorations.Add(TextDecorations.Underline);
            }
            else
            {
                textBox.TextDecorations.RemoveAt(0);
            }
        }

        private void blackRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void redRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (fileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(fileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            Uri theme = new Uri(themes.SelectedIndex == 0 ? "LightTheme.xaml" : "DarkTheme.xaml", UriKind.Relative);

            ResourceDictionary themeDictionary = Application.LoadComponent(theme) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(themeDictionary);
        }
    }
}
