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

        dreamlandEntities5 context;
        public ToysPage()
        {
            InitializeComponent();
            context = new dreamlandEntities5();
            var listMaterials = context.Material.ToList().Where(x => x.id > 0).ToList();
            listMaterials.Insert(0, new Material() { title = "все" });
            ToysListView.ItemsSource = context.Toy.ToList();
            materialBox.ItemsSource = context.Material.ToList();
        }







        private void ClickToListItem(object sender, MouseButtonEventArgs e)
        {
            Toy toy = (sender as Grid).DataContext as Toy;
               NavigationService.Navigate(new ToysMaterialPage (context, toy));

        }



        private void ChangeMaterial(object sender, SelectionChangedEventArgs e)
        {

            Material material =materialBox.SelectedItem as Material;
            var listMaterials = context.Toy.First().Material;
            if (materialBox.SelectedIndex != 0)
            {
                      ToysListView.ItemsSource = context.Toy.ToList().Where(x=>x.Material.Contains(material)).ToList();
            }
            else
            {
                ToysListView.ItemsSource = context.Toy.ToList();
            }


        }



    }
    }

