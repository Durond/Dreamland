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
        public Mainmenu()
        {
            InitializeComponent();
            
        }

        private void ShowMasters(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new EmployerPage());
        }

        private void ShowClient(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new ClientPage());
        }
    }
}
