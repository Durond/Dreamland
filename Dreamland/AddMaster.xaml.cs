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
    /// Логика взаимодействия для AddMaster.xaml
    /// </summary>
    public partial class AddMaster : Page
    {
        dreamlandEntities5 context;
        public AddMaster(dreamlandEntities5 cont)
        {
            InitializeComponent();
            context = cont;
            positionBox.ItemsSource = context.Status.ToList();
            posBox.ItemsSource = context.Position.ToList();
            flag = true;
        }

        bool flag;
      

        private void SaveEmployer(object sender, RoutedEventArgs e)
        {

            if (flag == true)
            {
                Employer employer = new Employer()
                {
                    tabNum = Convert.ToInt32(TabBox.Text),
                    name = fioBox.Text,
                    dateStartWork = Convert.ToDateTime(dateBox.Text),
                    salary = Convert.ToDecimal(salaryBox.Text),
                    status = (positionBox.SelectedItem as Status).id,
                    position = (posBox.SelectedItem as Position).id,
                    password = PassBox.Text

                };
                context.Employer.Add(employer);
                context.SaveChanges();
                NavigationService.Navigate(new EmployerPage());

            }

            else
            {
                Employer employer = new Employer();
                context.Employer.Find(employer.tabNum).name = fioBox.Text;
                context.Employer.Find(employer.tabNum).dateStartWork = Convert.ToDateTime(dateBox.Text);
                context.Employer.Find(employer.tabNum).salary = Convert.ToDecimal(salaryBox.Text);
                context.Employer.Find(employer.tabNum).status = (positionBox.SelectedItem as Status).id;
                context.Employer.Find(employer.tabNum).position = (posBox.SelectedItem as Position).id;
                context.Employer.Find(employer.tabNum).password = PassBox.Text;
                context.SaveChanges();
                NavigationService.Navigate(new EmployerPage());






            }

        }

        Employer work;
        public AddMaster(dreamlandEntities5 cont, Employer employer)
        {
            InitializeComponent();
            context = cont;
            positionBox.ItemsSource = context.Position.ToList();
            work = employer;
            TabBox.Text = employer.tabNum.ToString();
            fioBox.Text = employer.name;
            dateBox.SelectedDate = employer.dateStartWork;
            salaryBox.Text = employer.salary.ToString();
            positionBox.SelectedItem = employer.Status1;
            posBox.SelectedItem = employer.Position1;
            PassBox.Text = employer.password;



            flag = false;
        }
    }
}
