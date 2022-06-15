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
    /// Логика взаимодействия для password_recovery.xaml
    /// </summary>
    public partial class password_recovery : Window
    {
        dreamlandEntities4 context;
        public password_recovery()
        {
            InitializeComponent();
            context = new dreamlandEntities4();
          
        }
      
        private void EnterData(object sender, RoutedEventArgs e)
        {

            try
            {
                int tabNum = Convert.ToInt32(Num.Text);
                string name = FIO.Text;
                int position = Convert.ToInt32(Position.Text);
                string dateStartWork = DateEmployment.Text;

                Employer employer = context.Employer.ToList().Find(x => x.tabNum == tabNum);

                if (employer.tabNum.Equals(tabNum)
                    && (employer.name.Equals(name)
                    && (employer.position.Equals(position))))
                  
                {
                    {
                        MessageBox.Show("Ваш пароль ! " + Convert.ToString(employer.password) + " Внимание", " Информация ", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте введеные данные", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            catch
            {
                MessageBox.Show("Неверно введен табельный номер");
            }
            Close();
        }
    }
}
