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

namespace products
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<producttpl> elements = new List<producttpl>();
        List<producttpl> displayed = new List<producttpl>();
        public MainWindow()
        {
            InitializeComponent();

            
            foreach(producttpl elem in stack.Items)
            {
                elements.Add(elem);
            }

            displayed = elements;
            stack.Items.Clear();
            stack.ItemsSource = displayed;
            cmb.ItemsSource = elements.Select(elem => elem.Seller);
        }

        private void refreshdisp()
        {
            //stack.Items.Clear();
            stack.ItemsSource = displayed;
        }

        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            displayed = elements.Where(n => n.Seller == e.AddedItems[0] as string).ToList();  
            refreshdisp();
        }

        private void query_TextChanged(object sender, TextChangedEventArgs e)
        {
            displayed = elements.Where(n => (n.Productname.Contains((sender as TextBox).Text) || n.Description.Contains((sender as TextBox).Text))).ToList();
            refreshdisp();
        }

        private void price_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse((sender as TextBox).Text, out int p))
            {
                displayed = elements.Where(n => n.Price <= p).ToList();
                refreshdisp();
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            displayed = displayed.OrderBy(n => n.Price).ToList();
            refreshdisp();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            displayed = displayed.OrderByDescending(n => n.Price).ToList();
            refreshdisp();
        }
    }
}
