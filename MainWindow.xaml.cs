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
        List<producttpl> filtered = new List<producttpl>();
        List<string> sellers = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

            sellers.Add("All");
            foreach (producttpl elem in stack.Items)
            {
                elements.Add(elem);
                sellers.Add(elem.Seller);
            }
            
            displayed = elements;
            filtered = elements;
            stack.Items.Clear();
            stack.ItemsSource = displayed;
            cmb.ItemsSource = sellers;
            
        }

        private void refreshdisp()
        {
            //stack.Items.Clear();
            stack.ItemsSource = displayed;
        }

        private void filtermanager()
        {
            filtered = elements;
            cmbcheck();
            qcheck();
            pricecheck();
            displayed = filtered;
            refreshdisp();
        }

        private void cmbcheck()
        {
            if (cmb.SelectedItem != null)
            {
                if (cmb.SelectedItem.ToString() != "All")
                {
                    filtered = filtered.Where(n => n.Seller == cmb.SelectedItem as string).ToList();
                }
                else
                {
                    filtered = elements;
                }
            }
        }
        private void qcheck()
        {
            if (query.Text != null)
            {
                filtered = filtered.Where(n => (n.Productname.Contains(query.Text) || n.Description.Contains(query.Text))).ToList();
            }
        }

        private void pricecheck()
        {
            if (int.TryParse(price.Text, out int p))
            {
                filtered = filtered.Where(n => n.Price <= p).ToList();
            }
        }

        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filtermanager();
        }

        private void query_TextChanged(object sender, TextChangedEventArgs e)
        {
            filtermanager();
        }

        private void price_TextChanged(object sender, TextChangedEventArgs e)
        {
            filtermanager();
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
