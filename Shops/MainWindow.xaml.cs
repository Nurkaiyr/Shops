using System;
using System.Collections.Generic;
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

namespace Shops
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Connection helper = new Connection();

            switch (ComboBox.SelectedIndex)
            {
                case 0: Table.ItemsSource = helper.GetCustomers(); break;
                case 1: Table.ItemsSource = helper.GetSellers(); break;
                case 2: Table.ItemsSource = helper.GetOrders(); break;
            }

        }
    }
}
