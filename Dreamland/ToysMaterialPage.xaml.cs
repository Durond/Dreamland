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
    /// Логика взаимодействия для ToysMaterialPage.xaml
    /// </summary>
    public partial class ToysMaterialPage : Page
    {
        dreamlandEntities4 context;
        public ToysMaterialPage(dreamlandEntities4 context, Toy toy )
        {
            InitializeComponent();
            this.context = context;
            MaterialTable.ItemsSource = context.ToyMaterial.ToList().Where(x => x.idToy == toy.id);
        }
    }
}
