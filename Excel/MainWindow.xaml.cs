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

        public void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".qcv";
            dlg.Filter = "Text documents (.qcv)|*.qcv";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                
              
            }

        }

        private void BtnGo_Click(object sender, RoutedEventArgs e, string filename)
        {
            var data = new List<Items>();
            var lineParser = new ItemsConvert();
            foreach (string line in File.ReadAllLines(@"" + filename + ""))
            {
                if (line.StartsWith("FlatNet")) continue;
                var objTmp = lineParser.ParseLine(line);
                if (objTmp != null) data.Add(objTmp);
            }
        }

        class Items
        {
            public string Signal { get; set; }
            public int Testpoints { get; set; }
            public string Connections { get; set; }
   
          
        }

        class ItemsConvert
        {
            public Items ParseLine(string line)
            {
                Items result = null;
                var tmp = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (tmp.Length == 7)
                {
                    result = new Items
                    {
                        Signal = tmp[0],
                        Testpoints = Convert.ToInt32(tmp[1]),
                        Connections = tmp[2],                      
                    };
                }
                return result;
            }
        }

   
}
}
