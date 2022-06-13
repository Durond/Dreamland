﻿using System;
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
using System.Threading;

namespace Dreamland
{
   
    public partial class MainWindow : Window
    {
        dreamlandEntities context;
        public MainWindow()
        {

            InitializeComponent();
            context = new dreamlandEntities();

        }
        int tries = 3;
        private void EnterClick(object sender, RoutedEventArgs e)
        {

            tries--;

            if (tries == 0)
            {
                e.Source = Buttonbox.Visibility = Visibility.Visible;


            }
            try
            {
                int tabNum = Convert.ToInt32(login.Text);
                string pass = password.Text;
                Employer employer = context.Employer.ToList().Find(x => x.tabNum == tabNum);


                if (employer == null)
                {
                    MessageBox.Show("Сотрудник не найден,Осталось " + tries + " попытки", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                   if (employer.password.Equals(pass))
                {
                    MessageBox.Show("Успешная авторизация!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Mainmenu mm1 = new Mainmenu();
                    mm1.ShowDialog();
              


                }
                else
                {
                    MessageBox.Show("пароль не верен!" + tries + " попытки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Данного сотрудника не существует неверные данные " + tries + " попытки", "Внимание", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }

            catch
            {
                MessageBox.Show("Ошибка" + tries + " попытки", "ошибка", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }


        private void EnterRecovery(object sender, RoutedEventArgs e)
        {
            password_recovery ps2 = new password_recovery();
            ps2.ShowDialog();
        }

        
    }

}













