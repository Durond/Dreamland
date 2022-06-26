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

namespace Dreamland
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        dreamlandEntities5 context;
        public OrdersPage()
        {
            context = new dreamlandEntities5();
            InitializeComponent();
            Orderstable.ItemsSource = context.Order.ToList();
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddOrderPage(context));
        }

        private void EditOrders(object sender, RoutedEventArgs e)
        {
            Order order = Orderstable.SelectedItem as Order;
            NavigationService.Navigate(new AddOrderPage(context,order));
        }

        private void DeleteOrders(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Удалить данный заказ?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Order order = Orderstable.SelectedItem as Order;

                    context.Order.Remove(order);
                    context.SaveChanges();
                    NavigationService.Navigate(new OrdersPage());
                }
                catch
                {
                    MessageBox.Show("ошибка в удалении данного заказа");
                }
            }
        }

    }
}
