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

namespace VWS.LV.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Image> Images { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Images = new List<Image>();
            TestLoadImages();
        }

        public void TestLoadImages()
        {
            LoadImage(@"C:\Users\Kennebel\Dropbox\Gaming\Factorio\screenshots\20160402162657_1.jpg");
            LoadImage(@"C:\Users\Kennebel\Dropbox\Gaming\Factorio\screenshots\20160402163226_1.jpg");
        }

        public void LoadImage(string filename)
        {
            Image i = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(filename, UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            i.Source = src;
            i.Stretch = Stretch.Uniform;
            ImageHolder.Children.Add(i);

            Images.Add(i);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Panel.GetZIndex(Images[0]) == 1)
            {
                Panel.SetZIndex(Images[0], 2);
                Panel.SetZIndex(Images[1], 1);
            }
            else
            {
                Panel.SetZIndex(Images[0], 1);
                Panel.SetZIndex(Images[1], 2);
            }
        }
    }
}
