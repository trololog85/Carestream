using System;
using System.Windows;
using System.Windows.Controls;

namespace MigraPle.Windows.Search
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class CalendarPeriodo : Window
    {
        public DateTime FechaPeriodo { get; set; }

        public CalendarPeriodo()
        {
            InitializeComponent();
        }

        private void clPeriodo_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            GetPeriodo();
        }
    }
}
