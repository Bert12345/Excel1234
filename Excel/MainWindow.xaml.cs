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

namespace Excel
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

        

        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Hey mey men", "Help", MessageBoxButton.OK, MessageBoxImage.Information);



        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.qcv)|*.qcv";
            if (openFileDialog.ShowDialog() == true)
            {
                // Clear listview
                lvItems.Items.Clear();

                // Load text
                using (TextReader textReader = new StreamReader(openFileDialog.FileName))
                {

                    StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
                    sp.Children.Add(new TextBlock() { Text = "SIGNAL NAME", Width = 400, TextAlignment = TextAlignment.Center });
                    sp.Children.Add(new TextBlock() { Text = "NUMER OF TESTPOINTS ('MPxx')", Width = 200, TextAlignment = TextAlignment.Center });
                    sp.Children.Add(new TextBlock() { Text = "CONNECTION LIST", Width = 400, TextAlignment = TextAlignment.Center });
                    sp.Children.Add(new TextBlock() { Text = "CNT", Width = 75, TextAlignment = TextAlignment.Center });
                    lvItems.Items.Add(sp);
                    // Load the text line by line
                    string line = string.Empty;

                    while ((line = textReader.ReadLine()) != null)
                    {
                        string signal = line;
                        string connection = line;
                        string testpoint = "0";
                        StackPanel spForeCast = new StackPanel() { Orientation = Orientation.Horizontal };
                        spForeCast.Children.Add(new TextBlock() { Text = signal.Remove(0, 9), Width = 400 });
                        spForeCast.Children.Add(new TextBlock() { Text = testpoint,   Width = 200, TextAlignment = TextAlignment.Center, Name = "tbtest" });
                        spForeCast.Children.Add(new TextBlock() { Text = line.Remove(0, 9), Width = 400 });
                        spForeCast.Children.Add(new TextBlock() { Text = testpoint, Width = 75, TextAlignment = TextAlignment.Center });
                        lvItems.Items.Add(spForeCast);
                        int test = int.Parse(testpoint);
                        if (test <= 0)
                        {
                            TextBlock tbtest = spForeCast.Children.OfType<TextBlock>().Where(b => b.Name.Equals("tbtest")).FirstOrDefault();
                            tbtest.Background = Brushes.Red;
                        }
                    }
                }
            }
        }
    }
}
