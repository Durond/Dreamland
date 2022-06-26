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
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        dreamlandEntities5 context;

        public AddOrderPage(dreamlandEntities5 context)
        {
            InitializeComponent();
            positionBox.ItemsSource = context.State.ToList();
            flag = true;
        }
        bool flag;

        private void SaveOrder(object sender, RoutedEventArgs e)
        {
            if (flag==true)
            {
                Order order = new Order()
                {
                    id = Convert.ToInt32(NumBox.Text),
                    idClent = Convert.ToInt32(tabBox.Text),
                    nameclient = fioBox.Text,
                    date = Convert.ToDateTime(dateBox.Text),
                    state = (positionBox.SelectedItem as State).id
                };
                context.Order.Add(order);
                context.SaveChanges();
                NavigationService.Navigate(new OrdersPage());
            }
            else
            {
                Order order = new Order();
                context.Order.Find(order.id).idClent =Convert.ToInt32( tabBox.Text);
                context.Order.Find(order.id).date = Convert.ToDateTime(dateBox.Text);
                context.Order.Find(order.id).state = (positionBox.SelectedItem as State).id;
                context.SaveChanges();
                NavigationService.Navigate(new OrdersPage());

            }
        }

        Order ord;
        public AddOrderPage(dreamlandEntities5 context,Order order)
        {
            InitializeComponent();
            this.context = context;
            positionBox.ItemsSource = context.State.ToList();
            ord = order;
            tabBox.Text = order.idClent.ToString();
            NumBox.Text = order.id.ToString();
            fioBox.Text = order.nameclient;
            dateBox.SelectedDate = order.date;

            flag = false;
        }
    }
}



