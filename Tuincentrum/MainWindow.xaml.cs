using TuincentrumBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tuincentrum
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

        private void buttonTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new TuinDbManager();
                using (var conTuin = manager.GetConnection())
                {
                    conTuin.Open();
                    labelStatus.Content = "Tuincentrum geopend";
                }
                
            }
            catch (Exception ex)
            {
                labelStatus.Content = "Probleem met verbinding database : " + ex.Message;                
            }
        }
    }
}
