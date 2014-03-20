using TuincentrumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tuincentrum
{
    /// <summary>
    /// Interaction logic for GemiddeldeSoort.xaml
    /// </summary>
    public partial class GemiddeldeSoort : Window
    {
        public GemiddeldeSoort()
        {
            InitializeComponent();
        }

        private void buttonBereken_Click(object sender, RoutedEventArgs e)
        {
            var manager = new TuinManager();
            try
            {
                labelStatus.Content = manager.BerekenGemiddeldePrijs(textBoxSoort.Text) + " €";
            }
            catch (Exception ex)
            {
                labelStatus.Content = ex.Message;
            }
        }
    }
}
