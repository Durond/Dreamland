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
    /// Логика взаимодействия для ToysPage.xaml
    /// </summary>
    public partial class ToysPage : Page
    {

        dreamlandEntities4 context;
        public ToysPage()
        {
            InitializeComponent();
            context = new dreamlandEntities4();
            var listtoys = context.Toy.ToList().Where(x => x.title == Toy.id).ToList();
            listtoys.Insert(0, new Toy() { title = "Все" });
            ToysListView.ItemsSource = context.Toy.ToList();
            mastersBox.ItemsSource = context.Employer.ToList().Where(x => x.position == 1).ToList();
        }

        private void ChangeMaster(object sender, SelectionChangedEventArgs e)
        {
            Employer employer = mastersBox.SelectedItem as Employer;
            if (mastersBox.SelectedIndex !=0)
            {
                ToysListView.ItemsSource = context.Toy.ToList().Where(x => x.title == Toy.id).ToList();
            }
            else
            {
                ToysListView.ItemsSource = context.Toy.ToList();
            }

        }

        private void ClickToListItem(object sender, MouseButtonEventArgs e)
        {
            Toy toy = (sender as Grid).DataContext as Toy;
       //     NavigationService.Navigate(new название страницы которую тоже нужно создать //(context, toy));

        }
    }
}
