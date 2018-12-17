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
            string msg = "COUNT ALL TESTPOINTS ('MPxx-1') FROM DxDESIGNER PINLIST." + Environment.NewLine + " " + Environment.NewLine + "In xDM (new DxDesigner): File --> Export --> Quick Connection View" + Environment.NewLine + "* General" + Environment.NewLine + "--> select 'board'" + Environment.NewLine + "* Display" + Environment.NewLine + "--> select 'Display Nets', 'Flat Mode', 'Compress Flatnets'" + Environment.NewLine + "'Single Line per Net'" + Environment.NewLine + "'Single Line per Net'" + Environment.NewLine + "* Advanced" + Environment.NewLine + "--> select 'Exclude Special Components'" + Environment.NewLine + "Sort = None, Filter = None" + Environment.NewLine + " " + Environment.NewLine + "Leave other boxes un-checked." + Environment.NewLine + " " + Environment.NewLine + "Click 'Browse'"
               + Environment.NewLine + "Click GO!" + Environment.NewLine + " " + Environment.NewLine + " " + Environment.NewLine + "Features:" + Environment.NewLine + "- count all occurrences of 'MP' of '_MP' from the netlist" + Environment.NewLine + "- then sort on number of testpoints";
            MessageBox.Show(msg);
        }

        

        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnHelp_Click(object sender, RoutedEventArgs e)
        {
            string msg = "COUNT ALL TESTPOINTS ('MPxx-1') FROM DxDESIGNER PINLIST." + Environment.NewLine + " " + Environment.NewLine + "In xDM (new DxDesigner): File --> Export --> Quick Connection View" + Environment.NewLine + "* General" + Environment.NewLine + "--> select 'board'" + Environment.NewLine + "* Display" + Environment.NewLine + "--> select 'Display Nets', 'Flat Mode', 'Compress Flatnets'" + Environment.NewLine + "'Single Line per Net'" + Environment.NewLine + "'Single Line per Net'" + Environment.NewLine + "* Advanced" + Environment.NewLine + "--> select 'Exclude Special Components'" + Environment.NewLine + "Sort = None, Filter = None" + Environment.NewLine + " " + Environment.NewLine + "Leave other boxes un-checked." + Environment.NewLine + " " + Environment.NewLine + "Click 'Browse'"
                + Environment.NewLine + "Click GO!" + Environment.NewLine + " " + Environment.NewLine + " " + Environment.NewLine + "Features:" + Environment.NewLine + "- count all occurrences of 'MP' of '_MP' from the netlist" + Environment.NewLine + "- then sort on number of testpoints";


             MessageBox.Show(msg);
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
                        StackPanel spItems = new StackPanel() { Orientation = Orientation.Horizontal };
                        spItems.Children.Add(new TextBlock() { Text = signal.Remove(0, 9), Width = 400 });
                        spItems.Children.Add(new TextBlock() { Text = testpoint,   Width = 200, TextAlignment = TextAlignment.Center, Name = "tbtest" });
                        spItems.Children.Add(new TextBlock() { Text = line.Remove(0, 9), Width = 400 });
                        spItems.Children.Add(new TextBlock() { Text = testpoint, Width = 75, TextAlignment = TextAlignment.Center });
                        lvItems.Items.Add(spItems);
                        int test = int.Parse(testpoint);
                        if (test <= 0)
                        {
                            TextBlock tbtest = spItems.Children.OfType<TextBlock>().Where(b => b.Name.Equals("tbtest")).FirstOrDefault();
                            tbtest.Background = Brushes.Red;
                        }
                        else if (test == 1)
                        {
                            TextBlock tbtest = spItems.Children.OfType<TextBlock>().Where(b => b.Name.Equals("tbtest")).FirstOrDefault();
                            tbtest.Background = Brushes.LimeGreen;
                        }
                        else
                        {
                            TextBlock tbtest = spItems.Children.OfType<TextBlock>().Where(b => b.Name.Equals("tbtest")).FirstOrDefault();
                            tbtest.Background = Brushes.Orange;
                        }
                    }
                }
            }
        }
    }
}
