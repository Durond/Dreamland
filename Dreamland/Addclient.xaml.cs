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
    /// Логика взаимодействия для Addclient.xaml
    /// </summary>
    public partial class Addclient : Page
    {
        dreamlandEntities5 context;
        public Addclient(dreamlandEntities5 cont)
        {
            InitializeComponent();
            context = cont;

        }


        Client client1;
        private void SaveClient(object sender, RoutedEventArgs e)
        {



            context.Client.Find(client1.num).name = fioBox.Text;
            context.Client.Find(client1.num).passport = passpBox.Text;
            context.SaveChanges();
            NavigationService.Navigate(new ClientPage());

        }
        public Addclient(dreamlandEntities5 cont, Client client)
        {
            InitializeComponent();
            context = cont;
            client1 = client;
            TabBox.Text = client.num.ToString();
            fioBox.Text = client.name;
            passpBox.Text = client.passport;



        }




    }




}

















