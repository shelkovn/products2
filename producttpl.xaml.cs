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
    /// Логика взаимодействия для producttpl.xaml
    /// </summary>
    public partial class producttpl : UserControl
    {


        public string Imgsource
        {
            get { return (string)GetValue(ImgsourceProperty); }
            set { SetValue(ImgsourceProperty, value); }
        }

        public static readonly DependencyProperty ImgsourceProperty =
            DependencyProperty.Register(nameof(Imgsource), typeof(string), typeof(producttpl), new PropertyMetadata("https://pixsector.com/cache/517d8be6/av5c8336583e291842624.png"));

        public string Productname
        {
            get { return (string)GetValue(ProductnameProperty); }
            set { SetValue(ProductnameProperty, value); }
        }

        public static readonly DependencyProperty ProductnameProperty =
            DependencyProperty.Register(nameof(Productname), typeof(string), typeof(producttpl), new PropertyMetadata("Product"));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register(nameof(Description), typeof(string), typeof(producttpl), new PropertyMetadata("..."));

        public string Seller
        {
            get { return (string)GetValue(SellerProperty); }
            set { SetValue(SellerProperty, value); }
        }

        public static readonly DependencyProperty SellerProperty =
            DependencyProperty.Register(nameof(Seller), typeof(string), typeof(producttpl), new PropertyMetadata("..."));

        public float Price
        {
            get { return (float)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register(nameof(Price), typeof(float), typeof(producttpl), new PropertyMetadata(-1f));

        public string Currency
        {
            get { return (string)GetValue(CurrencyProperty); }
            set { SetValue(CurrencyProperty, value); }
        }

        public static readonly DependencyProperty CurrencyProperty =
            DependencyProperty.Register(nameof(Currency), typeof(string), typeof(producttpl), new PropertyMetadata("..."));

        public string Instock
        {
            get { return (string)GetValue(InstockProperty); }
            set { SetValue(InstockProperty, value); }
        }

        public static readonly DependencyProperty InstockProperty =
            DependencyProperty.Register(nameof(Instock), typeof(string), typeof(producttpl), new PropertyMetadata("..."));

        public producttpl()
        {
            InitializeComponent();
        }
    }
}
