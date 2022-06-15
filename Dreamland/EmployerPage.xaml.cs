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
    /// Логика взаимодействия для EmployerPage.xaml
    /// </summary>
    public partial class EmployerPage : Page
    {
        dreamlandEntities4 context;
        public EmployerPage()
        {
            InitializeComponent();
           
            context = new dreamlandEntities4();
            Employertable.ItemsSource = context.Employer.ToList().Where(x => x.position == 1).ToList();
            positionBox.ItemsSource = context.Position.ToList();




            var statuslist = context.Status.ToList();
            statuslist.Insert(0, new Status() { statusname = "Все", id = 0 });
            positionBox.ItemsSource = statuslist;
        }

        public void RefreshData()
        {
            var list = context.Employer.ToList().Where(x => x.position == 1).ToList();
            if (positionBox.SelectedIndex >0)
            {
                Status stat = positionBox.SelectedItem as Status;
                list = list.Where(x => x.Status1 == stat).ToList().Where(x=>x.position==1).ToList();
            }

            if (!string.IsNullOrWhiteSpace(fioBox.Text))
            {
                list = list.Where(x => x.name.ToLower().Contains(fioBox.Text.ToLower())).ToList();

               
             

            }

            Employertable.ItemsSource = list;

        }

        private void change(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }

        private void ChangeFio(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void AddMaster(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddMaster(context));
        }

        private void EditEmployer(object sender, RoutedEventArgs e)
        {
            Employer employer = Employertable.SelectedItem as Employer;
            NavigationService.Navigate(new AddMaster(context, employer));
        }

        private void DeleteEmployer(object sender, RoutedEventArgs e)
        {
           MessageBoxResult res  = MessageBox.Show("Удалить данную запись ?","Подтверждение",MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes )
            {
                try {
                Employer employer = Employertable.SelectedItem as Employer;
                 
                context.Employer.Remove(employer);
                context.SaveChanges();
                    NavigationService.Navigate(new EmployerPage());
                    }
               catch  
                {
                    MessageBox.Show("ошибка,удалите данного работника");
                }
            }
        }

        private void changeastatus(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }
    }
}
