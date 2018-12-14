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
            Jokeinfo();
        }


        private void Jokeinfo()
        {

            

            StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
            sp.Children.Add(new TextBlock() { Text = "Signal Name", Width = 300 });
            sp.Children.Add(new TextBlock() { Text = "Numer of testpoints ('MPxx')", Width = 300 });
            sp.Children.Add(new TextBlock() { Text = "Connection list", Width = 500 });
            sp.Children.Add(new TextBlock() { Text = "CNT", Width = 100 });
            lvItems.Items.Add(sp);
           
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
                    // Load the text line by line
                    string line = string.Empty;
                    while ((line = textReader.ReadLine()) != null)
                    {
                        // Append
                        lvItems.Items.Add(line);
                    }
                }
            }
        }
    }
}
