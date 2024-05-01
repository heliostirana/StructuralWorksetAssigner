using System;
using System.Collections;
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
using System.Windows.Forms;

namespace HLO
{
    /// <summary>
    /// Interaction logic for SimpleForm.xaml
    /// </summary>
    public partial class SimpleForm : Window
    {
        public SimpleForm(IEnumerable collection)
        {
            InitializeComponent();
            Box.ItemsSource = collection;
        }
    }
}
