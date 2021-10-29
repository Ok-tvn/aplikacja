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

namespace aplikacja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int N = 20;
        int[] d = new int[N];
        int i, j, x;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void radiobox_1_Checked(object sender, RoutedEventArgs e)
        {
            var rand = new Random();

            for (int g = 0; g < 20; g++)
            {
                d[g] = rand.Next(0, 30);
            }
            /*for (int m = 0; m < 20; m++)
            {
                this.wynik.Text += d[m].ToString() + " ";
            }*/

        }

        private void radiobox_2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radiobox_3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void jeden_Click(object sender, RoutedEventArgs e)
        {
            for (j = N - 2; j >= 0; j--)
            {   
                x = d[j];
                i = j + 1;
                while ((i < N) && (x > d[i]))
                {
                    d[i - 1] = d[i];
                    i++;
                }
                d[i - 1] = x;
            }
            this.wynik.Clear();
            for (int m = 0; m < 20; m++)
            {
               this.wynik.Text += d[m].ToString() + " ";
            }
        }

        private void wynik_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
