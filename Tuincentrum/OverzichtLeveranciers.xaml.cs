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
    /// Interaction logic for OverzichtLeveranciers.xaml
    /// </summary>
    public partial class OverzichtLeveranciers : Window
    {
        private CollectionViewSource leverancierViewSource;
        
        public OverzichtLeveranciers()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulGrid();            
        }

        private void VulGrid()
        {
            leverancierViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("leverancierViewSource")));
            var manager = new TuinManager();
            leverancierViewSource.Source = manager.GetLeveranciers(textBoxZoeken.Text);
        }

        private void buttonZoeken_Click(object sender, RoutedEventArgs e)
        {
            VulGrid();
        }

        private void goUpdate()
        {
            if (leverancierViewSource.View.CurrentPosition == 0)
            {
                buttonGoToPrevious.IsEnabled = false;
                buttonGoToFirst.IsEnabled = false;
                buttonGoNext.IsEnabled = true;
                buttonGoToLast.IsEnabled = true;
            }
            else if (leverancierViewSource.View.CurrentPosition == leverancierDataGrid.Items.Count - 1)
            {
                buttonGoNext.IsEnabled = false;
                buttonGoToLast.IsEnabled = false;
                buttonGoToPrevious.IsEnabled = true;
                buttonGoToFirst.IsEnabled = true;
            }
            else
            {
                buttonGoToPrevious.IsEnabled = true;
                buttonGoToFirst.IsEnabled = true;
                buttonGoNext.IsEnabled = true;
                buttonGoToLast.IsEnabled = true;
            }
            if (leverancierDataGrid.Items.Count != 0)
            {
                if (leverancierDataGrid.SelectedItem!=null)
                leverancierDataGrid.ScrollIntoView(leverancierDataGrid.SelectedItem);
            }
        }

        private void buttonGoToFirst_Click(object sender, RoutedEventArgs e)
        {
            leverancierViewSource.View.MoveCurrentToFirst();
            goUpdate();
        }

        private void buttonGoToPrevious_Click(object sender, RoutedEventArgs e)
        {
            leverancierViewSource.View.MoveCurrentToPrevious();
            goUpdate();
        }

        private void buttonGoNext_Click(object sender, RoutedEventArgs e)
        {
            leverancierViewSource.View.MoveCurrentToNext();
            goUpdate();
        }

        private void buttonGoToLast_Click(object sender, RoutedEventArgs e)
        {
            leverancierViewSource.View.MoveCurrentToLast();
            goUpdate();
        }
    }
}
