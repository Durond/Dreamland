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
        dreamlandEntities2 context;
        public Addclient(dreamlandEntities2 con)
        {
            InitializeComponent();
            context = con;

        }

      

        private void SaveClient(object sender, RoutedEventArgs e)
        {
          
            {
                Client client = new Client()
                {
                    num = Convert.ToInt32(TabBox.Text),
                    name = fioBox.Text,
                    passport = passpBox.Text
                };
                context.Client.Add(client);
                context.SaveChanges();
                NavigationService.Navigate(new ClientPage());
            }

            }
        }
    }
















