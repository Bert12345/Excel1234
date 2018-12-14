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
                    sp.Children.Add(new TextBlock() { Text = "SIGNAL NAME", Width = 400 });
                    sp.Children.Add(new TextBlock() { Text = "NUMER OF TESTPOINTS ('MPxx')", Width = 200 });
                    sp.Children.Add(new TextBlock() { Text = "CONNECTION LIST", Width = 400 });
                    sp.Children.Add(new TextBlock() { Text = "CNT", Width = 75 });
                    lvItems.Items.Add(sp);
                    // Load the text line by line
                    string line = string.Empty;
                    string test = "test";
                    while ((line = textReader.ReadLine()) != null)
                    {
                        StackPanel spForeCast = new StackPanel() { Orientation = Orientation.Horizontal };
                        spForeCast.Children.Add(new TextBlock() { Text = line, Width = 400 });
                        spForeCast.Children.Add(new TextBlock() { Text = test, Width = 200 });
                        spForeCast.Children.Add(new TextBlock() { Text = test, Width = 400 });
                        spForeCast.Children.Add(new TextBlock() { Text = test, Width = 75 });
                        lvItems.Items.Add(spForeCast);
                    }
                }
            }
        }
    }
}
