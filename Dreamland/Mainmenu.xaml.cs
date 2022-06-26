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
using System.Windows.Shapes;

namespace Dreamland
{
    /// <summary>
    /// Логика взаимодействия для Mainmenu.xaml
    /// </summary>
    public partial class Mainmenu : Window
    {
        MainWindow window;
        public Mainmenu(Employer employer, MainWindow window)
        {
            InitializeComponent();
            if (employer.position==1)
            {
                MasterButton.Visibility = Visibility.Collapsed;
                ClientButton.Visibility = Visibility.Collapsed;
                ToysButton.Visibility = Visibility.Collapsed;
                
            }
            window.Visibility = Visibility.Collapsed;
            this.window = window;
        }

        private void ShowMasters(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new EmployerPage());
        }

        private void ShowClient(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new ClientPage());
        }

        private void ShowToys(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new ToysPage());
        }

        private void ShowMaterial(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new MaterialPage());
        }

        private void ShowOrders(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new OrdersPage());
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            window.Close();
        }

    
    }
}
