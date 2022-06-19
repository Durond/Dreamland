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
            var listtoys = context.Toy.ToList();
            listtoys.Insert(0, new Toy() { title = "Все" });
            ToysListView.ItemsSource = context.Toy.ToList();
            materialBox.ItemsSource = context.Employer.ToList().Where(x => x.position == 1).ToList();
        }







        private void ClickToListItem(object sender, MouseButtonEventArgs e)
        {
            Toy toy = (sender as Grid).DataContext as Toy;
               NavigationService.Navigate(new ToysMaterialPage (context, toy));

        }



        private void ChangeMaterial(object sender, SelectionChangedEventArgs e)
        {

            ToyMaterial toyMaterial =materialBox.SelectedItem as ToyMaterial;
            if (materialBox.SelectedIndex != 0)
            {
                      ToysListView.ItemsSource = context.ToyMaterial.ToList().Where(x=>x.idMaterial==toyMaterial.idMaterial).ToList();
            }
            else
            {
                ToysListView.ItemsSource = context.ToyMaterial.ToList();
            }


        }



    }
    }

