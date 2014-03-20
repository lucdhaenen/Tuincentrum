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
    /// Interaction logic for ZoekPlanten.xaml
    /// </summary>
    public partial class ZoekPlanten : Window
    {
        public ZoekPlanten()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var tuinManager = new TuinManager();
                var alleSoorten = tuinManager.GetSoorten();
                foreach (var eenSoort in alleSoorten)
                { comboBoxSoorten.Items.Add(eenSoort); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void comboBoxSoorten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                labelNummer.Content = string.Empty;
                labelLeverancier.Content = string.Empty;
                labelVerkoopPrijs.Content = string.Empty;
                labelKleur.Content = string.Empty;
                listBoxPlanten.Items.Clear();
                var soortNr = ((Soort)comboBoxSoorten.SelectedItem).SoortNr;
                var tuinManager = new TuinManager();
                var allePlanten = tuinManager.GetPlanten(soortNr);
                foreach (var eenPlant in allePlanten)
                { listBoxPlanten.Items.Add(eenPlant); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void listBoxPlanten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxPlanten.SelectedItem != null)
            {
                var plant = (Plant)listBoxPlanten.SelectedItem;
                labelNummer.Content = plant.PlantNr.ToString();
                labelLeverancier.Content = plant.LevNr.ToString();
                labelVerkoopPrijs.Content = String.Format("{0:C}", plant.Prijs);
                labelKleur.Content = plant.Kleur;
            }
            
        }        
    }
}
