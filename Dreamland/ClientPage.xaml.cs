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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        dreamlandEntities4 context;
        public ClientPage()
        {
            InitializeComponent();
            context = new dreamlandEntities4();
            Clienttable.ItemsSource = context.Client.ToList();
            
        }

        private void EditClient(object sender, RoutedEventArgs e)
        {
            Client client = Clienttable.SelectedItem as Client;
            NavigationService.Navigate(new Addclient(context,client));
            context.SaveChanges();
        }

        public void RefreshData()
        {
            var list = context.Client.ToList();

            if (!string.IsNullOrWhiteSpace(fioBox.Text))
            {
                list = list.Where(x => x.name.ToLower().Contains(fioBox.Text.ToLower())).ToList();

               
            }
            Clienttable.ItemsSource = list;
        }

        private void ChangesFio(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }
    }
}

